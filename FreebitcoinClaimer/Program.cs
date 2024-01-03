using FreebitcoinClaimer.Utility;
using FreebitcoinClaimer.UI;
using Serilog;
using FreebitcoinClaimer.Services;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;
using Serilog.Core;

namespace FreebitcoinClaimer
{
    internal static class Program
    {
        public static string APP_Name = "FreeBitco.in Claimer";
        public static Version Version { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadSettings();

            Log.Information($"Started {APP_Name} v{Version}");

            // run on our own thread since the async functions of WebClient kill threads when program exits
            if (Config.GetBooleanValue("CheckForUpdates", true))
                new Thread(CheckLatestVersion).Start();

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

        private static void CheckLatestVersion()
        {
            Log.Information("Checking for updates");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using(HttpClient updateClient = new HttpClient())
                {
                    updateClient.DefaultRequestHeaders.Add("User-Agent", "freebitcoin-claimer v" + Version);
                    var result = updateClient.GetAsync("https://api.github.com/repos/gpayao/freebitcoin-claimer/releases/latest").Result;

                    JObject obj = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result)!;
                    var stringValue = obj["tag_name"]!.Value<string>();
                    
                    if (string.IsNullOrEmpty(stringValue))
                    {
                        Log.Error("Failed to get \"tag_name\" value from API response");
                        return;
                    }

                    Match match = Regex.Match(stringValue, @"[0-9]+(?:\.[0-9]+){0,3}"); // extract version from tag name
                    
                    if (!match.Success)
                    {
                        Log.Error($"Failed to parse {stringValue} as a valid version");
                        return;
                    }

                    var latestVersion = new Version(match.Value);

                    if (latestVersion > Version)
                    {
                        Log.Information("New version available: " + latestVersion);

                        DialogResult dialogResult = MessageBox.Show("A new version of Freebitcoin Claimer is available! Would you like do download it?", "New Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                        if (dialogResult == DialogResult.Yes)
                        {
                            var url = $"https://github.com/gpayao/freebitcoin-claimer/releases/download/{stringValue}/FreebitcoinClaimer.exe";
                            var ps = new ProcessStartInfo(url)
                            {
                                UseShellExecute = true,
                                Verb = "open"
                            };

                            Process.Start(ps);
                            return;
                        }

                        dialogResult = MessageBox.Show("Would you like to disable automatic update checking?", "Disable Automatic Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            Config.SetValue("CheckForUpdates", false);
                            MessageBox.Show("Automatic update checking has been disabled. You can re-enable updates by editing the configuration file.", "Updates Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Log.Information($"Newer version not found (latest is {latestVersion})");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to get latest version", ex);
            }
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

            Version = Assembly.GetExecutingAssembly().GetName().Version;

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