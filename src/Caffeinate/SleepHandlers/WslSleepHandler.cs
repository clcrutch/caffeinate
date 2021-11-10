using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffeinate.SleepHandlers
{
    internal class WslSleepHandler : ISleepHandler
    {
        private Process? caffeinateProcess;
        private bool disposedValue;

        public async Task AllowSleepAsync()
        {
            if (caffeinateProcess == null)
            {
                return;
            }

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(10 * 1000); // Kill after 10 seconds

            await caffeinateProcess.StandardInput.WriteAsync(" ");
            await caffeinateProcess.WaitForExitAsync(cancellationTokenSource.Token);

            if (cancellationTokenSource.IsCancellationRequested)
            {
                caffeinateProcess.Kill(); // Kill if the process did not stop within the requested time.
            }

            caffeinateProcess = null;
        }

        public async Task PreventSleepAsync()
        {
            if (caffeinateProcess != null)
            {
                await AllowSleepAsync();
            }

            caffeinateProcess = Process.Start(new ProcessStartInfo
            {
                FileName = "caf.exe",
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                AllowSleepAsync().Wait();
                disposedValue = true;
            }
        }

        ~WslSleepHandler()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await AllowSleepAsync();
            Dispose();
        }
    }
}
