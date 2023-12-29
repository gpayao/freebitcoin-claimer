using FreebitcoinClaimer.Utility;
using FreebitcoinClaimer.UI;
using Serilog;
using FreebitcoinClaimer.Services;

namespace FreebitcoinClaimer
{
    internal static class Program
    {
        public static string APP_Name = "FreeBitco.in Claimer";
        public static string VERSION = "1.0.0";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadSettings();

            Log.Information($"Started {APP_Name} v{VERSION}");

            ApplicationConfiguration.Initialize();

            if (!FreebitcoinManager.HasLogin())
            {
                if (new LoginForm().ShowDialog() != DialogResult.OK)
                {
                    Shutdown();
                    return;
                }
            }

            Application.Run(new MainForm());

            Shutdown();
        }
        private static void ShowSystemInfo()
        {
            Log.Information($"OS Version: " + Util.GetFriendlyOSVersion());
        }

        private static void LoadSettings()
        {
            LoggerManager.Setup();

            ShowSystemInfo();

            Log.Debug("Loading settings");

            Config.Load();

            LoggerManager.SetLogLevel(Config.GetStringValue("LogLevel", "Information"));

            FreebitcoinManager.Setup();
        }


        internal static void Shutdown()
        {
            Log.Information("Shutting Down");

            Log.CloseAndFlush();

            Application.Exit();
        }

        internal static void ForceShutdown()
        {
            Shutdown();
            Environment.Exit(0); // Kill everything
        }
    }
}