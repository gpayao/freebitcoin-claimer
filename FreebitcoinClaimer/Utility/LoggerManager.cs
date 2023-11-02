using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace FreebitcoinClaimer.Utility
{
    internal static class LoggerManager
    {
        internal static string LogFile { get; } = Path.Combine(Folders.Logs, $@"FreeBitcoinClaimer.log");

        public static LoggingLevelSwitch LevelSwitch { get; private set; } = new LoggingLevelSwitch
        {
            MinimumLevel = LogEventLevel.Information
        };

        internal static void Setup()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(LevelSwitch)
                .WriteTo.File(LogFile, rollingInterval: RollingInterval.Minute)
                .CreateLogger();
        }

        internal static void SetLogLevel(string level)
        {
            if (Enum.TryParse(level, true, out LogEventLevel logLevel))
                LevelSwitch.MinimumLevel = logLevel;
            else
                Log.Information($"Invalid log level \"{level}\", defaulting to Information");
        }
    }
}
