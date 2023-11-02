using FreebitcoinClaimer.Utility;
using WebDriverManager.Helpers;
using WebDriverManager;
using FreebitcoinClaimer.UI;
using FreebitcoinClaimer.Types;
using Serilog;
using System.Configuration;

namespace FreebitcoinClaimer
{
    internal static class Program
    {
        public static string APP_Name = "FreeBitcoin Claimer";
        public static string VERSION = "1.0.0";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadSettings();

            Log.Information($"Started {APP_Name} v{VERSION}");

            ShowSystemInfo();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (!FreebitcoinControl.NeedLogin())
                Application.Run(new LoginForm());

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

            Log.Debug("Loading settings");

            Config.Load();

            LoggerManager.SetLogLevel(Config.GetStringValue("LogLevel", "information"));

            LoadBrowser();
        }

        private static void LoadBrowser()
        {
            Log.Information("Loading browser driver");

            new DriverManager()
                .SetUpDriver(
                    config: new FreebitcoinClaimerBrowserConfig(),
                    version: VersionResolveStrategy.MatchingBrowser
                    );

            FreebitcoinControl.Setup();
        }

        internal static void Shutdown()
        {
            Log.Information("Shutting Down");

            Log.CloseAndFlush();

            FreebitcoinControl.Quit();

            Application.Exit();
        }

        internal static void ForceShutdown()
        {
            Shutdown();
            Environment.Exit(0); // Kill everything
        }
    }
}