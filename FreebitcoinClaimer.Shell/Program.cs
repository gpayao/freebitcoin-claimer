using CommandLine;
using FreebitcoinClaimer.Services;
using FreebitcoinClaimer.Services.Types;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace FreebitcoinClaimer.Shell
{
    internal class Program
    {
        public class Options
        {
            [Option('b', "btcaddress", Required = true, HelpText = "BTC address to use")]
            public string? BtcAddress { get; set; }

            [Option('p', "password", Required = true, HelpText = "Password of the BTC address")]
            public string? Password { get; set; }

            [Option('t', "tfa", Required = false, HelpText = "Two Factor authentication code")]
            public string? TfaCode { get; set; }

            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        public static string? BtcAddress { get; set; } = "";

        public static string? Password { get; set; } = "";

        public static string? TfaCode { get; set; } = "";

        public static bool Verbose { get; set; } = false;

        public static Login Login;

        public static FreebitcoinClaimerClient claimerClient;

        private static System.Timers.Timer _timer;

        static async Task Main(string[] args)
        {
            string title = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

            Console.Title = title;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    BtcAddress = o.BtcAddress;
                    Password = o.Password;
                    TfaCode = o.TfaCode ?? "";
                    Verbose = o.Verbose;
                });

            var claimerOptions = new FreebitcoinClaimerClientOptions(BtcAddress, Password, TfaCode);

            claimerClient = new FreebitcoinClaimerClient(claimerOptions);

            LoggingLevelSwitch logLevelSwitcher = new LoggingLevelSwitch(LogEventLevel.Information);

            if (Verbose) { logLevelSwitcher.MinimumLevel = LogEventLevel.Verbose; }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(logLevelSwitcher)
                .WriteTo.Console()
                .CreateLogger();

            await claimerClient.LoginAsync(BtcAddress, Password, TfaCode);

            var freeRoll = claimerClient.FreeRollAsync(
                clientSeed: FreebitcoinClaimerHelper.GenerateCSRFToken(),
                csrfToken: FreebitcoinClaimerHelper.GenerateCSRFToken(),
                fingerprint: "8435762738ca8dc683c406da5b3bb508",
                fingerprint2: FreebitcoinClaimerHelper.GenerateFingerprint2()
                );

            _timer = new System.Timers.Timer(TimeSpan.FromMinutes(60).TotalMilliseconds);
            _timer.Elapsed += OnTimer;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            Console.ReadLine();
        }

        private static void OnTimer(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var freeRoll = claimerClient.FreeRollAsync(
                clientSeed: FreebitcoinClaimerHelper.GenerateCSRFToken(),
                csrfToken: FreebitcoinClaimerHelper.GenerateCSRFToken(),
                fingerprint: "8435762738ca8dc683c406da5b3bb508",
                fingerprint2: FreebitcoinClaimerHelper.GenerateFingerprint2()
                );
        }
    }
}
