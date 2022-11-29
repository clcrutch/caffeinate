var target = Argument("target", "Push");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    DeleteFiles("**/*.nupkg");
    CleanDirectories(GetDirectories($"./src/*/bin/{configuration}"));
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetBuild("./Caffeinate.sln", new DotNetBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest("./Caffeinate.sln", new DotNetTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
{
    DotNetPack("./Caffeinate.sln", new DotNetPackSettings
    {
        Configuration = configuration,
        NoBuild = true
    });
});

Task("Push")
    .IsDependentOn("Pack")
    .WithCriteria(!string.IsNullOrWhiteSpace(EnvironmentVariable("NUGET_API_KEY")))
    .Does(() =>
{
    var nugetApiKey = EnvironmentVariable("NUGET_API_KEY");

    NuGetPush(GetFiles("**/Clcrutch.Caffeinate.*.nupkg"), new NuGetPushSettings
    {
        ApiKey = nugetApiKey,
        Source = "https://api.nuget.org/v3/index.json"
    });
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);