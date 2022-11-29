using Tmds.DBus;
using login1.DBus;

namespace Caffeinate.SleepHandlers;

public class SystemdSleepHandler : ISleepHandler
{
    private Connection systemConnection;
    private CloseSafeHandle handle;
    
    public SystemdSleepHandler()
    {
        systemConnection = Connection.System;
    }

    ~SystemdSleepHandler()
    {
        Dispose();
    }
    
    public void Dispose()
    {
        DisposeAsync().AsTask().Wait();
    }

    public async ValueTask DisposeAsync()
    {
        await AllowSleepAsync();
        
        if (systemConnection != null)
        {
            systemConnection.Dispose();
            systemConnection = null;
        }
    }

    public Task AllowSleepAsync()
    {
        if (handle != null)
        {
            handle.Close();
            handle = null;
        }
        
        return Task.CompletedTask;
    }

    public async Task PreventSleepAsync()
    {
        await AllowSleepAsync();
        
        var manager = systemConnection.CreateProxy<IManager>("org.freedesktop.login1", "/org/freedesktop/login1");
        handle = await manager.InhibitAsync("sleep", "Clcrutch.Caffeinate", "Process is running", "block");
    }
}