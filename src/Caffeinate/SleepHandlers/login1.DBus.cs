using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Tmds.DBus.Connection.DynamicAssemblyName)]
namespace login1.DBus
{
    [DBusInterface("org.freedesktop.login1.Manager")]
    interface IManager : IDBusObject
    {
        Task<ObjectPath> GetSessionAsync(string SessionId);
        Task<ObjectPath> GetSessionByPIDAsync(uint Pid);
        Task<ObjectPath> GetUserAsync(uint Uid);
        Task<ObjectPath> GetUserByPIDAsync(uint Pid);
        Task<ObjectPath> GetSeatAsync(string SeatId);
        Task<(string, uint, string, string, ObjectPath)[]> ListSessionsAsync();
        Task<(uint, string, ObjectPath)[]> ListUsersAsync();
        Task<(string, ObjectPath)[]> ListSeatsAsync();
        Task<(string, string, string, string, uint, uint)[]> ListInhibitorsAsync();
        Task<(string sessionId, ObjectPath objectPath, string runtimePath, CloseSafeHandle fifoFd, uint uid, string seatId, uint vtnr, bool existing)> CreateSessionAsync(uint Uid, uint Pid, string Service, string Type, string Class, string Desktop, string SeatId, uint Vtnr, string Tty, string Display, bool Remote, string RemoteUser, string RemoteHost, (string, object)[] Properties);
        Task ReleaseSessionAsync(string SessionId);
        Task ActivateSessionAsync(string SessionId);
        Task ActivateSessionOnSeatAsync(string SessionId, string SeatId);
        Task LockSessionAsync(string SessionId);
        Task UnlockSessionAsync(string SessionId);
        Task LockSessionsAsync();
        Task UnlockSessionsAsync();
        Task KillSessionAsync(string SessionId, string Who, int SignalNumber);
        Task KillUserAsync(uint Uid, int SignalNumber);
        Task TerminateSessionAsync(string SessionId);
        Task TerminateUserAsync(uint Uid);
        Task TerminateSeatAsync(string SeatId);
        Task SetUserLingerAsync(uint Uid, bool Enable, bool Interactive);
        Task AttachDeviceAsync(string SeatId, string SysfsPath, bool Interactive);
        Task FlushDevicesAsync(bool Interactive);
        Task PowerOffAsync(bool Interactive);
        Task PowerOffWithFlagsAsync(ulong Flags);
        Task RebootAsync(bool Interactive);
        Task RebootWithFlagsAsync(ulong Flags);
        Task HaltAsync(bool Interactive);
        Task HaltWithFlagsAsync(ulong Flags);
        Task SuspendAsync(bool Interactive);
        Task SuspendWithFlagsAsync(ulong Flags);
        Task HibernateAsync(bool Interactive);
        Task HibernateWithFlagsAsync(ulong Flags);
        Task HybridSleepAsync(bool Interactive);
        Task HybridSleepWithFlagsAsync(ulong Flags);
        Task SuspendThenHibernateAsync(bool Interactive);
        Task SuspendThenHibernateWithFlagsAsync(ulong Flags);
        Task<string> CanPowerOffAsync();
        Task<string> CanRebootAsync();
        Task<string> CanHaltAsync();
        Task<string> CanSuspendAsync();
        Task<string> CanHibernateAsync();
        Task<string> CanHybridSleepAsync();
        Task<string> CanSuspendThenHibernateAsync();
        Task ScheduleShutdownAsync(string Type, ulong Usec);
        Task<bool> CancelScheduledShutdownAsync();
        Task<CloseSafeHandle> InhibitAsync(string What, string Who, string Why, string Mode);
        Task<string> CanRebootParameterAsync();
        Task SetRebootParameterAsync(string Parameter);
        Task<string> CanRebootToFirmwareSetupAsync();
        Task SetRebootToFirmwareSetupAsync(bool Enable);
        Task<string> CanRebootToBootLoaderMenuAsync();
        Task SetRebootToBootLoaderMenuAsync(ulong Timeout);
        Task<string> CanRebootToBootLoaderEntryAsync();
        Task SetRebootToBootLoaderEntryAsync(string BootLoaderEntry);
        Task SetWallMessageAsync(string WallMessage, bool Enable);
        Task<IDisposable> WatchSessionNewAsync(Action<(string sessionId, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchSessionRemovedAsync(Action<(string sessionId, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUserNewAsync(Action<(uint uid, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUserRemovedAsync(Action<(uint uid, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchSeatNewAsync(Action<(string seatId, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchSeatRemovedAsync(Action<(string seatId, ObjectPath objectPath)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchPrepareForShutdownAsync(Action<bool> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchPrepareForSleepAsync(Action<bool> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<ManagerProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class ManagerProperties
    {
        private bool _enableWallMessages = default(bool);
        public bool EnableWallMessages
        {
            get
            {
                return _enableWallMessages;
            }

            set
            {
                _enableWallMessages = (value);
            }
        }

        private string _wallMessage = default(string);
        public string WallMessage
        {
            get
            {
                return _wallMessage;
            }

            set
            {
                _wallMessage = (value);
            }
        }

        private uint _nAutoVTs = default(uint);
        public uint NAutoVTs
        {
            get
            {
                return _nAutoVTs;
            }

            set
            {
                _nAutoVTs = (value);
            }
        }

        private string[] _killOnlyUsers = default(string[]);
        public string[] KillOnlyUsers
        {
            get
            {
                return _killOnlyUsers;
            }

            set
            {
                _killOnlyUsers = (value);
            }
        }

        private string[] _killExcludeUsers = default(string[]);
        public string[] KillExcludeUsers
        {
            get
            {
                return _killExcludeUsers;
            }

            set
            {
                _killExcludeUsers = (value);
            }
        }

        private bool _killUserProcesses = default(bool);
        public bool KillUserProcesses
        {
            get
            {
                return _killUserProcesses;
            }

            set
            {
                _killUserProcesses = (value);
            }
        }

        private string _rebootParameter = default(string);
        public string RebootParameter
        {
            get
            {
                return _rebootParameter;
            }

            set
            {
                _rebootParameter = (value);
            }
        }

        private bool _rebootToFirmwareSetup = default(bool);
        public bool RebootToFirmwareSetup
        {
            get
            {
                return _rebootToFirmwareSetup;
            }

            set
            {
                _rebootToFirmwareSetup = (value);
            }
        }

        private ulong _rebootToBootLoaderMenu = default(ulong);
        public ulong RebootToBootLoaderMenu
        {
            get
            {
                return _rebootToBootLoaderMenu;
            }

            set
            {
                _rebootToBootLoaderMenu = (value);
            }
        }

        private string _rebootToBootLoaderEntry = default(string);
        public string RebootToBootLoaderEntry
        {
            get
            {
                return _rebootToBootLoaderEntry;
            }

            set
            {
                _rebootToBootLoaderEntry = (value);
            }
        }

        private string[] _bootLoaderEntries = default(string[]);
        public string[] BootLoaderEntries
        {
            get
            {
                return _bootLoaderEntries;
            }

            set
            {
                _bootLoaderEntries = (value);
            }
        }

        private bool _idleHint = default(bool);
        public bool IdleHint
        {
            get
            {
                return _idleHint;
            }

            set
            {
                _idleHint = (value);
            }
        }

        private ulong _idleSinceHint = default(ulong);
        public ulong IdleSinceHint
        {
            get
            {
                return _idleSinceHint;
            }

            set
            {
                _idleSinceHint = (value);
            }
        }

        private ulong _idleSinceHintMonotonic = default(ulong);
        public ulong IdleSinceHintMonotonic
        {
            get
            {
                return _idleSinceHintMonotonic;
            }

            set
            {
                _idleSinceHintMonotonic = (value);
            }
        }

        private string _blockInhibited = default(string);
        public string BlockInhibited
        {
            get
            {
                return _blockInhibited;
            }

            set
            {
                _blockInhibited = (value);
            }
        }

        private string _delayInhibited = default(string);
        public string DelayInhibited
        {
            get
            {
                return _delayInhibited;
            }

            set
            {
                _delayInhibited = (value);
            }
        }

        private ulong _inhibitDelayMaxUSec = default(ulong);
        public ulong InhibitDelayMaxUSec
        {
            get
            {
                return _inhibitDelayMaxUSec;
            }

            set
            {
                _inhibitDelayMaxUSec = (value);
            }
        }

        private ulong _userStopDelayUSec = default(ulong);
        public ulong UserStopDelayUSec
        {
            get
            {
                return _userStopDelayUSec;
            }

            set
            {
                _userStopDelayUSec = (value);
            }
        }

        private string _handlePowerKey = default(string);
        public string HandlePowerKey
        {
            get
            {
                return _handlePowerKey;
            }

            set
            {
                _handlePowerKey = (value);
            }
        }

        private string _handleSuspendKey = default(string);
        public string HandleSuspendKey
        {
            get
            {
                return _handleSuspendKey;
            }

            set
            {
                _handleSuspendKey = (value);
            }
        }

        private string _handleHibernateKey = default(string);
        public string HandleHibernateKey
        {
            get
            {
                return _handleHibernateKey;
            }

            set
            {
                _handleHibernateKey = (value);
            }
        }

        private string _handleLidSwitch = default(string);
        public string HandleLidSwitch
        {
            get
            {
                return _handleLidSwitch;
            }

            set
            {
                _handleLidSwitch = (value);
            }
        }

        private string _handleLidSwitchExternalPower = default(string);
        public string HandleLidSwitchExternalPower
        {
            get
            {
                return _handleLidSwitchExternalPower;
            }

            set
            {
                _handleLidSwitchExternalPower = (value);
            }
        }

        private string _handleLidSwitchDocked = default(string);
        public string HandleLidSwitchDocked
        {
            get
            {
                return _handleLidSwitchDocked;
            }

            set
            {
                _handleLidSwitchDocked = (value);
            }
        }

        private ulong _holdoffTimeoutUSec = default(ulong);
        public ulong HoldoffTimeoutUSec
        {
            get
            {
                return _holdoffTimeoutUSec;
            }

            set
            {
                _holdoffTimeoutUSec = (value);
            }
        }

        private string _idleAction = default(string);
        public string IdleAction
        {
            get
            {
                return _idleAction;
            }

            set
            {
                _idleAction = (value);
            }
        }

        private ulong _idleActionUSec = default(ulong);
        public ulong IdleActionUSec
        {
            get
            {
                return _idleActionUSec;
            }

            set
            {
                _idleActionUSec = (value);
            }
        }

        private bool _preparingForShutdown = default(bool);
        public bool PreparingForShutdown
        {
            get
            {
                return _preparingForShutdown;
            }

            set
            {
                _preparingForShutdown = (value);
            }
        }

        private bool _preparingForSleep = default(bool);
        public bool PreparingForSleep
        {
            get
            {
                return _preparingForSleep;
            }

            set
            {
                _preparingForSleep = (value);
            }
        }

        private (string, ulong) _scheduledShutdown = default((string, ulong));
        public (string, ulong) ScheduledShutdown
        {
            get
            {
                return _scheduledShutdown;
            }

            set
            {
                _scheduledShutdown = (value);
            }
        }

        private bool _docked = default(bool);
        public bool Docked
        {
            get
            {
                return _docked;
            }

            set
            {
                _docked = (value);
            }
        }

        private bool _lidClosed = default(bool);
        public bool LidClosed
        {
            get
            {
                return _lidClosed;
            }

            set
            {
                _lidClosed = (value);
            }
        }

        private bool _onExternalPower = default(bool);
        public bool OnExternalPower
        {
            get
            {
                return _onExternalPower;
            }

            set
            {
                _onExternalPower = (value);
            }
        }

        private bool _removeIPC = default(bool);
        public bool RemoveIPC
        {
            get
            {
                return _removeIPC;
            }

            set
            {
                _removeIPC = (value);
            }
        }

        private ulong _runtimeDirectorySize = default(ulong);
        public ulong RuntimeDirectorySize
        {
            get
            {
                return _runtimeDirectorySize;
            }

            set
            {
                _runtimeDirectorySize = (value);
            }
        }

        private ulong _runtimeDirectoryInodesMax = default(ulong);
        public ulong RuntimeDirectoryInodesMax
        {
            get
            {
                return _runtimeDirectoryInodesMax;
            }

            set
            {
                _runtimeDirectoryInodesMax = (value);
            }
        }

        private ulong _inhibitorsMax = default(ulong);
        public ulong InhibitorsMax
        {
            get
            {
                return _inhibitorsMax;
            }

            set
            {
                _inhibitorsMax = (value);
            }
        }

        private ulong _nCurrentInhibitors = default(ulong);
        public ulong NCurrentInhibitors
        {
            get
            {
                return _nCurrentInhibitors;
            }

            set
            {
                _nCurrentInhibitors = (value);
            }
        }

        private ulong _sessionsMax = default(ulong);
        public ulong SessionsMax
        {
            get
            {
                return _sessionsMax;
            }

            set
            {
                _sessionsMax = (value);
            }
        }

        private ulong _nCurrentSessions = default(ulong);
        public ulong NCurrentSessions
        {
            get
            {
                return _nCurrentSessions;
            }

            set
            {
                _nCurrentSessions = (value);
            }
        }
    }

    static class ManagerExtensions
    {
        public static Task<bool> GetEnableWallMessagesAsync(this IManager o) => o.GetAsync<bool>("EnableWallMessages");
        public static Task<string> GetWallMessageAsync(this IManager o) => o.GetAsync<string>("WallMessage");
        public static Task<uint> GetNAutoVTsAsync(this IManager o) => o.GetAsync<uint>("NAutoVTs");
        public static Task<string[]> GetKillOnlyUsersAsync(this IManager o) => o.GetAsync<string[]>("KillOnlyUsers");
        public static Task<string[]> GetKillExcludeUsersAsync(this IManager o) => o.GetAsync<string[]>("KillExcludeUsers");
        public static Task<bool> GetKillUserProcessesAsync(this IManager o) => o.GetAsync<bool>("KillUserProcesses");
        public static Task<string> GetRebootParameterAsync(this IManager o) => o.GetAsync<string>("RebootParameter");
        public static Task<bool> GetRebootToFirmwareSetupAsync(this IManager o) => o.GetAsync<bool>("RebootToFirmwareSetup");
        public static Task<ulong> GetRebootToBootLoaderMenuAsync(this IManager o) => o.GetAsync<ulong>("RebootToBootLoaderMenu");
        public static Task<string> GetRebootToBootLoaderEntryAsync(this IManager o) => o.GetAsync<string>("RebootToBootLoaderEntry");
        public static Task<string[]> GetBootLoaderEntriesAsync(this IManager o) => o.GetAsync<string[]>("BootLoaderEntries");
        public static Task<bool> GetIdleHintAsync(this IManager o) => o.GetAsync<bool>("IdleHint");
        public static Task<ulong> GetIdleSinceHintAsync(this IManager o) => o.GetAsync<ulong>("IdleSinceHint");
        public static Task<ulong> GetIdleSinceHintMonotonicAsync(this IManager o) => o.GetAsync<ulong>("IdleSinceHintMonotonic");
        public static Task<string> GetBlockInhibitedAsync(this IManager o) => o.GetAsync<string>("BlockInhibited");
        public static Task<string> GetDelayInhibitedAsync(this IManager o) => o.GetAsync<string>("DelayInhibited");
        public static Task<ulong> GetInhibitDelayMaxUSecAsync(this IManager o) => o.GetAsync<ulong>("InhibitDelayMaxUSec");
        public static Task<ulong> GetUserStopDelayUSecAsync(this IManager o) => o.GetAsync<ulong>("UserStopDelayUSec");
        public static Task<string> GetHandlePowerKeyAsync(this IManager o) => o.GetAsync<string>("HandlePowerKey");
        public static Task<string> GetHandleSuspendKeyAsync(this IManager o) => o.GetAsync<string>("HandleSuspendKey");
        public static Task<string> GetHandleHibernateKeyAsync(this IManager o) => o.GetAsync<string>("HandleHibernateKey");
        public static Task<string> GetHandleLidSwitchAsync(this IManager o) => o.GetAsync<string>("HandleLidSwitch");
        public static Task<string> GetHandleLidSwitchExternalPowerAsync(this IManager o) => o.GetAsync<string>("HandleLidSwitchExternalPower");
        public static Task<string> GetHandleLidSwitchDockedAsync(this IManager o) => o.GetAsync<string>("HandleLidSwitchDocked");
        public static Task<ulong> GetHoldoffTimeoutUSecAsync(this IManager o) => o.GetAsync<ulong>("HoldoffTimeoutUSec");
        public static Task<string> GetIdleActionAsync(this IManager o) => o.GetAsync<string>("IdleAction");
        public static Task<ulong> GetIdleActionUSecAsync(this IManager o) => o.GetAsync<ulong>("IdleActionUSec");
        public static Task<bool> GetPreparingForShutdownAsync(this IManager o) => o.GetAsync<bool>("PreparingForShutdown");
        public static Task<bool> GetPreparingForSleepAsync(this IManager o) => o.GetAsync<bool>("PreparingForSleep");
        public static Task<(string, ulong)> GetScheduledShutdownAsync(this IManager o) => o.GetAsync<(string, ulong)>("ScheduledShutdown");
        public static Task<bool> GetDockedAsync(this IManager o) => o.GetAsync<bool>("Docked");
        public static Task<bool> GetLidClosedAsync(this IManager o) => o.GetAsync<bool>("LidClosed");
        public static Task<bool> GetOnExternalPowerAsync(this IManager o) => o.GetAsync<bool>("OnExternalPower");
        public static Task<bool> GetRemoveIPCAsync(this IManager o) => o.GetAsync<bool>("RemoveIPC");
        public static Task<ulong> GetRuntimeDirectorySizeAsync(this IManager o) => o.GetAsync<ulong>("RuntimeDirectorySize");
        public static Task<ulong> GetRuntimeDirectoryInodesMaxAsync(this IManager o) => o.GetAsync<ulong>("RuntimeDirectoryInodesMax");
        public static Task<ulong> GetInhibitorsMaxAsync(this IManager o) => o.GetAsync<ulong>("InhibitorsMax");
        public static Task<ulong> GetNCurrentInhibitorsAsync(this IManager o) => o.GetAsync<ulong>("NCurrentInhibitors");
        public static Task<ulong> GetSessionsMaxAsync(this IManager o) => o.GetAsync<ulong>("SessionsMax");
        public static Task<ulong> GetNCurrentSessionsAsync(this IManager o) => o.GetAsync<ulong>("NCurrentSessions");
        public static Task SetEnableWallMessagesAsync(this IManager o, bool val) => o.SetAsync("EnableWallMessages", val);
        public static Task SetWallMessageAsync(this IManager o, string val) => o.SetAsync("WallMessage", val);
    }

    [DBusInterface("org.freedesktop.login1.Seat")]
    interface ISeat : IDBusObject
    {
        Task TerminateAsync();
        Task ActivateSessionAsync(string SessionId);
        Task SwitchToAsync(uint Vtnr);
        Task SwitchToNextAsync();
        Task SwitchToPreviousAsync();
        Task<T> GetAsync<T>(string prop);
        Task<SeatProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SeatProperties
    {
        private string _id = default(string);
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = (value);
            }
        }

        private (string, ObjectPath) _activeSession = default((string, ObjectPath));
        public (string, ObjectPath) ActiveSession
        {
            get
            {
                return _activeSession;
            }

            set
            {
                _activeSession = (value);
            }
        }

        private bool _canTTY = default(bool);
        public bool CanTTY
        {
            get
            {
                return _canTTY;
            }

            set
            {
                _canTTY = (value);
            }
        }

        private bool _canGraphical = default(bool);
        public bool CanGraphical
        {
            get
            {
                return _canGraphical;
            }

            set
            {
                _canGraphical = (value);
            }
        }

        private (string, ObjectPath)[] _sessions = default((string, ObjectPath)[]);
        public (string, ObjectPath)[] Sessions
        {
            get
            {
                return _sessions;
            }

            set
            {
                _sessions = (value);
            }
        }

        private bool _idleHint = default(bool);
        public bool IdleHint
        {
            get
            {
                return _idleHint;
            }

            set
            {
                _idleHint = (value);
            }
        }

        private ulong _idleSinceHint = default(ulong);
        public ulong IdleSinceHint
        {
            get
            {
                return _idleSinceHint;
            }

            set
            {
                _idleSinceHint = (value);
            }
        }

        private ulong _idleSinceHintMonotonic = default(ulong);
        public ulong IdleSinceHintMonotonic
        {
            get
            {
                return _idleSinceHintMonotonic;
            }

            set
            {
                _idleSinceHintMonotonic = (value);
            }
        }
    }

    static class SeatExtensions
    {
        public static Task<string> GetIdAsync(this ISeat o) => o.GetAsync<string>("Id");
        public static Task<(string, ObjectPath)> GetActiveSessionAsync(this ISeat o) => o.GetAsync<(string, ObjectPath)>("ActiveSession");
        public static Task<bool> GetCanTTYAsync(this ISeat o) => o.GetAsync<bool>("CanTTY");
        public static Task<bool> GetCanGraphicalAsync(this ISeat o) => o.GetAsync<bool>("CanGraphical");
        public static Task<(string, ObjectPath)[]> GetSessionsAsync(this ISeat o) => o.GetAsync<(string, ObjectPath)[]>("Sessions");
        public static Task<bool> GetIdleHintAsync(this ISeat o) => o.GetAsync<bool>("IdleHint");
        public static Task<ulong> GetIdleSinceHintAsync(this ISeat o) => o.GetAsync<ulong>("IdleSinceHint");
        public static Task<ulong> GetIdleSinceHintMonotonicAsync(this ISeat o) => o.GetAsync<ulong>("IdleSinceHintMonotonic");
    }

    [DBusInterface("org.freedesktop.login1.User")]
    interface IUser : IDBusObject
    {
        Task TerminateAsync();
        Task KillAsync(int SignalNumber);
        Task<T> GetAsync<T>(string prop);
        Task<UserProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class UserProperties
    {
        private uint _uID = default(uint);
        public uint UID
        {
            get
            {
                return _uID;
            }

            set
            {
                _uID = (value);
            }
        }

        private uint _gID = default(uint);
        public uint GID
        {
            get
            {
                return _gID;
            }

            set
            {
                _gID = (value);
            }
        }

        private string _name = default(string);
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = (value);
            }
        }

        private ulong _timestamp = default(ulong);
        public ulong Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = (value);
            }
        }

        private ulong _timestampMonotonic = default(ulong);
        public ulong TimestampMonotonic
        {
            get
            {
                return _timestampMonotonic;
            }

            set
            {
                _timestampMonotonic = (value);
            }
        }

        private string _runtimePath = default(string);
        public string RuntimePath
        {
            get
            {
                return _runtimePath;
            }

            set
            {
                _runtimePath = (value);
            }
        }

        private string _service = default(string);
        public string Service
        {
            get
            {
                return _service;
            }

            set
            {
                _service = (value);
            }
        }

        private string _slice = default(string);
        public string Slice
        {
            get
            {
                return _slice;
            }

            set
            {
                _slice = (value);
            }
        }

        private (string, ObjectPath) _display = default((string, ObjectPath));
        public (string, ObjectPath) Display
        {
            get
            {
                return _display;
            }

            set
            {
                _display = (value);
            }
        }

        private string _state = default(string);
        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = (value);
            }
        }

        private (string, ObjectPath)[] _sessions = default((string, ObjectPath)[]);
        public (string, ObjectPath)[] Sessions
        {
            get
            {
                return _sessions;
            }

            set
            {
                _sessions = (value);
            }
        }

        private bool _idleHint = default(bool);
        public bool IdleHint
        {
            get
            {
                return _idleHint;
            }

            set
            {
                _idleHint = (value);
            }
        }

        private ulong _idleSinceHint = default(ulong);
        public ulong IdleSinceHint
        {
            get
            {
                return _idleSinceHint;
            }

            set
            {
                _idleSinceHint = (value);
            }
        }

        private ulong _idleSinceHintMonotonic = default(ulong);
        public ulong IdleSinceHintMonotonic
        {
            get
            {
                return _idleSinceHintMonotonic;
            }

            set
            {
                _idleSinceHintMonotonic = (value);
            }
        }

        private bool _linger = default(bool);
        public bool Linger
        {
            get
            {
                return _linger;
            }

            set
            {
                _linger = (value);
            }
        }
    }

    static class UserExtensions
    {
        public static Task<uint> GetUIDAsync(this IUser o) => o.GetAsync<uint>("UID");
        public static Task<uint> GetGIDAsync(this IUser o) => o.GetAsync<uint>("GID");
        public static Task<string> GetNameAsync(this IUser o) => o.GetAsync<string>("Name");
        public static Task<ulong> GetTimestampAsync(this IUser o) => o.GetAsync<ulong>("Timestamp");
        public static Task<ulong> GetTimestampMonotonicAsync(this IUser o) => o.GetAsync<ulong>("TimestampMonotonic");
        public static Task<string> GetRuntimePathAsync(this IUser o) => o.GetAsync<string>("RuntimePath");
        public static Task<string> GetServiceAsync(this IUser o) => o.GetAsync<string>("Service");
        public static Task<string> GetSliceAsync(this IUser o) => o.GetAsync<string>("Slice");
        public static Task<(string, ObjectPath)> GetDisplayAsync(this IUser o) => o.GetAsync<(string, ObjectPath)>("Display");
        public static Task<string> GetStateAsync(this IUser o) => o.GetAsync<string>("State");
        public static Task<(string, ObjectPath)[]> GetSessionsAsync(this IUser o) => o.GetAsync<(string, ObjectPath)[]>("Sessions");
        public static Task<bool> GetIdleHintAsync(this IUser o) => o.GetAsync<bool>("IdleHint");
        public static Task<ulong> GetIdleSinceHintAsync(this IUser o) => o.GetAsync<ulong>("IdleSinceHint");
        public static Task<ulong> GetIdleSinceHintMonotonicAsync(this IUser o) => o.GetAsync<ulong>("IdleSinceHintMonotonic");
        public static Task<bool> GetLingerAsync(this IUser o) => o.GetAsync<bool>("Linger");
    }

    [DBusInterface("org.freedesktop.login1.Session")]
    interface ISession : IDBusObject
    {
        Task TerminateAsync();
        Task ActivateAsync();
        Task LockAsync();
        Task UnlockAsync();
        Task SetIdleHintAsync(bool Idle);
        Task SetLockedHintAsync(bool Locked);
        Task KillAsync(string Who, int SignalNumber);
        Task TakeControlAsync(bool Force);
        Task ReleaseControlAsync();
        Task SetTypeAsync(string Type);
        Task<(CloseSafeHandle fd, bool inactive)> TakeDeviceAsync(uint Major, uint Minor);
        Task ReleaseDeviceAsync(uint Major, uint Minor);
        Task PauseDeviceCompleteAsync(uint Major, uint Minor);
        Task SetBrightnessAsync(string Subsystem, string Name, uint Brightness);
        Task<IDisposable> WatchPauseDeviceAsync(Action<(uint major, uint minor, string type)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchResumeDeviceAsync(Action<(uint major, uint minor, CloseSafeHandle fd)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchLockAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUnlockAsync(Action handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<SessionProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SessionProperties
    {
        private string _id = default(string);
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = (value);
            }
        }

        private (uint, ObjectPath) _user = default((uint, ObjectPath));
        public (uint, ObjectPath) User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = (value);
            }
        }

        private string _name = default(string);
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = (value);
            }
        }

        private ulong _timestamp = default(ulong);
        public ulong Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = (value);
            }
        }

        private ulong _timestampMonotonic = default(ulong);
        public ulong TimestampMonotonic
        {
            get
            {
                return _timestampMonotonic;
            }

            set
            {
                _timestampMonotonic = (value);
            }
        }

        private uint _vTNr = default(uint);
        public uint VTNr
        {
            get
            {
                return _vTNr;
            }

            set
            {
                _vTNr = (value);
            }
        }

        private (string, ObjectPath) _seat = default((string, ObjectPath));
        public (string, ObjectPath) Seat
        {
            get
            {
                return _seat;
            }

            set
            {
                _seat = (value);
            }
        }

        private string _tTY = default(string);
        public string TTY
        {
            get
            {
                return _tTY;
            }

            set
            {
                _tTY = (value);
            }
        }

        private string _display = default(string);
        public string Display
        {
            get
            {
                return _display;
            }

            set
            {
                _display = (value);
            }
        }

        private bool _remote = default(bool);
        public bool Remote
        {
            get
            {
                return _remote;
            }

            set
            {
                _remote = (value);
            }
        }

        private string _remoteHost = default(string);
        public string RemoteHost
        {
            get
            {
                return _remoteHost;
            }

            set
            {
                _remoteHost = (value);
            }
        }

        private string _remoteUser = default(string);
        public string RemoteUser
        {
            get
            {
                return _remoteUser;
            }

            set
            {
                _remoteUser = (value);
            }
        }

        private string _service = default(string);
        public string Service
        {
            get
            {
                return _service;
            }

            set
            {
                _service = (value);
            }
        }

        private string _desktop = default(string);
        public string Desktop
        {
            get
            {
                return _desktop;
            }

            set
            {
                _desktop = (value);
            }
        }

        private string _scope = default(string);
        public string Scope
        {
            get
            {
                return _scope;
            }

            set
            {
                _scope = (value);
            }
        }

        private uint _leader = default(uint);
        public uint Leader
        {
            get
            {
                return _leader;
            }

            set
            {
                _leader = (value);
            }
        }

        private uint _audit = default(uint);
        public uint Audit
        {
            get
            {
                return _audit;
            }

            set
            {
                _audit = (value);
            }
        }

        private string _type = default(string);
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = (value);
            }
        }

        private string _class = default(string);
        public string Class
        {
            get
            {
                return _class;
            }

            set
            {
                _class = (value);
            }
        }

        private bool _active = default(bool);
        public bool Active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = (value);
            }
        }

        private string _state = default(string);
        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = (value);
            }
        }

        private bool _idleHint = default(bool);
        public bool IdleHint
        {
            get
            {
                return _idleHint;
            }

            set
            {
                _idleHint = (value);
            }
        }

        private ulong _idleSinceHint = default(ulong);
        public ulong IdleSinceHint
        {
            get
            {
                return _idleSinceHint;
            }

            set
            {
                _idleSinceHint = (value);
            }
        }

        private ulong _idleSinceHintMonotonic = default(ulong);
        public ulong IdleSinceHintMonotonic
        {
            get
            {
                return _idleSinceHintMonotonic;
            }

            set
            {
                _idleSinceHintMonotonic = (value);
            }
        }

        private bool _lockedHint = default(bool);
        public bool LockedHint
        {
            get
            {
                return _lockedHint;
            }

            set
            {
                _lockedHint = (value);
            }
        }
    }

    static class SessionExtensions
    {
        public static Task<string> GetIdAsync(this ISession o) => o.GetAsync<string>("Id");
        public static Task<(uint, ObjectPath)> GetUserAsync(this ISession o) => o.GetAsync<(uint, ObjectPath)>("User");
        public static Task<string> GetNameAsync(this ISession o) => o.GetAsync<string>("Name");
        public static Task<ulong> GetTimestampAsync(this ISession o) => o.GetAsync<ulong>("Timestamp");
        public static Task<ulong> GetTimestampMonotonicAsync(this ISession o) => o.GetAsync<ulong>("TimestampMonotonic");
        public static Task<uint> GetVTNrAsync(this ISession o) => o.GetAsync<uint>("VTNr");
        public static Task<(string, ObjectPath)> GetSeatAsync(this ISession o) => o.GetAsync<(string, ObjectPath)>("Seat");
        public static Task<string> GetTTYAsync(this ISession o) => o.GetAsync<string>("TTY");
        public static Task<string> GetDisplayAsync(this ISession o) => o.GetAsync<string>("Display");
        public static Task<bool> GetRemoteAsync(this ISession o) => o.GetAsync<bool>("Remote");
        public static Task<string> GetRemoteHostAsync(this ISession o) => o.GetAsync<string>("RemoteHost");
        public static Task<string> GetRemoteUserAsync(this ISession o) => o.GetAsync<string>("RemoteUser");
        public static Task<string> GetServiceAsync(this ISession o) => o.GetAsync<string>("Service");
        public static Task<string> GetDesktopAsync(this ISession o) => o.GetAsync<string>("Desktop");
        public static Task<string> GetScopeAsync(this ISession o) => o.GetAsync<string>("Scope");
        public static Task<uint> GetLeaderAsync(this ISession o) => o.GetAsync<uint>("Leader");
        public static Task<uint> GetAuditAsync(this ISession o) => o.GetAsync<uint>("Audit");
        public static Task<string> GetTypeAsync(this ISession o) => o.GetAsync<string>("Type");
        public static Task<string> GetClassAsync(this ISession o) => o.GetAsync<string>("Class");
        public static Task<bool> GetActiveAsync(this ISession o) => o.GetAsync<bool>("Active");
        public static Task<string> GetStateAsync(this ISession o) => o.GetAsync<string>("State");
        public static Task<bool> GetIdleHintAsync(this ISession o) => o.GetAsync<bool>("IdleHint");
        public static Task<ulong> GetIdleSinceHintAsync(this ISession o) => o.GetAsync<ulong>("IdleSinceHint");
        public static Task<ulong> GetIdleSinceHintMonotonicAsync(this ISession o) => o.GetAsync<ulong>("IdleSinceHintMonotonic");
        public static Task<bool> GetLockedHintAsync(this ISession o) => o.GetAsync<bool>("LockedHint");
    }

    [DBusInterface("org.freedesktop.LogControl1")]
    interface ILogControl1 : IDBusObject
    {
        Task<T> GetAsync<T>(string prop);
        Task<LogControl1Properties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class LogControl1Properties
    {
        private string _logLevel = default(string);
        public string LogLevel
        {
            get
            {
                return _logLevel;
            }

            set
            {
                _logLevel = (value);
            }
        }

        private string _logTarget = default(string);
        public string LogTarget
        {
            get
            {
                return _logTarget;
            }

            set
            {
                _logTarget = (value);
            }
        }

        private string _syslogIdentifier = default(string);
        public string SyslogIdentifier
        {
            get
            {
                return _syslogIdentifier;
            }

            set
            {
                _syslogIdentifier = (value);
            }
        }
    }

    static class LogControl1Extensions
    {
        public static Task<string> GetLogLevelAsync(this ILogControl1 o) => o.GetAsync<string>("LogLevel");
        public static Task<string> GetLogTargetAsync(this ILogControl1 o) => o.GetAsync<string>("LogTarget");
        public static Task<string> GetSyslogIdentifierAsync(this ILogControl1 o) => o.GetAsync<string>("SyslogIdentifier");
        public static Task SetLogLevelAsync(this ILogControl1 o, string val) => o.SetAsync("LogLevel", val);
        public static Task SetLogTargetAsync(this ILogControl1 o, string val) => o.SetAsync("LogTarget", val);
    }
}