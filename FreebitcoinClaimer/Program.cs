using FreebitcoinClaimer.Utility;
using WebDriverManager.Helpers;
using WebDriverManager;
using FreebitcoinClaimer.UI;

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

            Logger.Info($"Started {APP_Name} v{VERSION}");

            ShowSystemInfo();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (!FreebitcoinControl.NeedLogin())
                Application.Run(new LoginForm());

            Application.Run(new MainForm());
        }
        private static void ShowSystemInfo()
        {
            Logger.Info($"OS Version: " + Util.GetFriendlyOSVersion());
        }

        private static void LoadSettings()
        {
            Logger.Debug("Loading settings");

            Logger.Setup();

            Config.Load();

            Logger.WriteToFile = Config.GetBooleanValue("LogToFile", true);
            Logger.SetLogLevel(Config.GetStringValue("LogLevel", "info"));

            LoadBrowser();
        }

        private static void LoadBrowser()
        {
            Logger.Info("Loading browser driver");

            new DriverManager()
                .SetUpDriver(
                    config: new FreebitcoinClaimerBrowserConfig(), 
                    version: VersionResolveStrategy.MatchingBrowser
                    );

            FreebitcoinControl.Setup();
        }

        internal static void Shutdown()
        {
            Logger.Info("Shutting Down");

            Logger.CleanFiles();

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