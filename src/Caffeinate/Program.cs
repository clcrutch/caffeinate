using Caffeinate.SleepHandlers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Caffeinate
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            if (args.Any())
            {
                return RunProgramAsync(args);
            }
            else
            {
                return RunUntilKeyPressAsync();
            }
        }

        static async Task RunProgramAsync(string[] args)
        {
            bool shouldNotify = false;

            IEnumerable<string> arguments = args;
            if (string.Equals(arguments.First(), "--notify", StringComparison.OrdinalIgnoreCase))
            {
                arguments = arguments.Skip(1);
                shouldNotify = true;
            }

            using var sleepHandler = await CreateSleepHandlerAsync();

            await sleepHandler.PreventSleepAsync();
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments = string.Join(" ", args.Skip(1)),
                FileName = arguments.First()
            });

            await (process?.WaitForExitAsync() ?? Task.CompletedTask);

            if (shouldNotify && process != null)
            {
                await Notify(arguments.First(), process);
            }

            await sleepHandler.AllowSleepAsync();
        }

        static async Task RunUntilKeyPressAsync()
        {
            using var sleepHandler = await CreateSleepHandlerAsync();

            await sleepHandler.PreventSleepAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            await sleepHandler.AllowSleepAsync();
        }

        static async Task<ISleepHandler> CreateSleepHandlerAsync()
        {
            if (OperatingSystem.IsWindows())
            {
                return new WindowsSleepHandler();
            }

            if (await IsWslAsync())
            {
                return new WslSleepHandler();
            }

            throw new NotImplementedException();
        }

        static async Task Notify(string processName, Process process)
        {
            var configPath = await GetConfigPathAsync();

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException(configPath);
            }

            using var reader = File.OpenText(configPath);
            var configString = await reader.ReadToEndAsync();

            var config = JsonConvert.DeserializeObject<NotifyConfig>(configString);

            if (config == null)
            {
                throw new ArgumentNullException("Configuration");
            }

            string body = config.SuccessfulBodyTemplate;
            if (process.ExitCode != 0)
            {
                body = config.FailedBodyTemplate;
            }

            body = body
                .Replace("{task_name}", processName)
                .Replace("{exit_code}", process.ExitCode.ToString());

            using var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = GetHttpMethod(config.HttpMethod),
                Content = new StringContent(body),
                RequestUri = new Uri(config.URL)
            };

            if (config.Headers != null)
            {
                foreach (var header in config.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        static async Task<string> GetConfigPathAsync(bool wslFallback = false)
        {
            if (await IsWslAsync() || wslFallback)
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"& echo \\$env:USERPROFILE\"",
                    RedirectStandardOutput = true
                });

                if (process != null && process.ExitCode == 0)
                {
                    await process.WaitForExitAsync();
                    return Path.Join(await process.StandardOutput.ReadToEndAsync(), ".caffeinate");
                }
            }

            return Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".caffeinate");
        }

        static HttpMethod GetHttpMethod(string httpMethod)
        {
            switch (httpMethod)
            {
                case "GET":
                    return HttpMethod.Get;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;

                case "POST":
                default:
                    return HttpMethod.Post;
            }
        }

        static async Task<bool> IsWslAsync()
        {
            if (!OperatingSystem.IsLinux())
            {
                return false;
            }

            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "grep",
                Arguments = "-qEi \"(Microsoft | WSL)\" /proc/version"
            });
            await (process?.WaitForExitAsync() ?? Task.CompletedTask);

            return (process?.ExitCode ?? 1) == 0;
        }
    }
}