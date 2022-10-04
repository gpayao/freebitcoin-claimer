using FreebitcoinClaimer.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;

namespace FreebitcoinClaimer.Utility
{
    public class FreebitcoinControl
    {
        private static readonly string FreebitcoinHomePage = "https://freebitco.in/";
        private static readonly double ClaimInterval = 60;

        private static IWebDriver? Driver;

        private static readonly System.Timers.Timer ClaimTimer = new();

        internal static void Setup()
        {
            Logger.Info("Starting Chrome Driver");

            var chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.HideCommandPromptWindow = true;
            chromeService.SuppressInitialDiagnosticInformation = true;

            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            options.AddArguments(
                "user-data-dir=" + Folders.ChromeProfile,
                "--start-maximized",
                "--window-size=1920,1080",
                "--disable-notifications"
                );

            if (Logger.Level != LogLevel.Debug)
                options.AddArgument("headless");

            Driver = new ChromeDriver(chromeService, options);

            Driver.Navigate().GoToUrl(FreebitcoinHomePage);

            ClaimTimer.Elapsed += Claim;
        }

        public static bool NeedLogin()
        {
            try
            {
                Driver!.FindElement(By.CssSelector("#balance"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool Login(string username, string password, string fa, out string errorMessage)
        {
            Logger.Info("Logging in");

            errorMessage = string.Empty;

            if (!Driver!.Url.Contains("signup"))
                Driver!.Navigate().GoToUrl(FreebitcoinHomePage);

            IWebElement usernameInput = Driver.FindElement(By.CssSelector("#login_form_btc_address"));
            IWebElement passwordInput = Driver.FindElement(By.CssSelector("#login_form_password"));
            IWebElement faInput = Driver.FindElement(By.CssSelector("#login_form_2fa"));

            if (!usernameInput.Displayed)
                Driver.FindElement(By.CssSelector("li.login_menu_button > a")).Click();

            usernameInput.Clear();
            usernameInput.SendKeys(username);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            faInput.Clear();
            faInput.SendKeys(fa);

            Driver.FindElement(By.CssSelector("#login_button")).Click();

            Thread.Sleep(2000);

            try
            {
                Driver.FindElement(By.CssSelector("#balance"));
                return true;
            }
            catch (NoSuchElementException)
            {
                errorMessage = Driver.FindElement(By.CssSelector("#reward_point_redeem_result_container_div span.reward_point_redeem_result")).Text;
                return false;
            }
        }

        public static double GetBalance()
        {
            return double.Parse(Driver!.FindElement(By.CssSelector("#balance")).Text, CultureInfo.InvariantCulture);
        }

        public static string GetResult()
        {
            var winningsText = Driver!.FindElement(By.CssSelector("#free_play_result winnings")).Text;

            if (string.IsNullOrEmpty(winningsText))
                return "";

            var winnings = double.Parse(winningsText, CultureInfo.InvariantCulture);
            var digits = Driver!.FindElements(By.CssSelector("#free_play_digits span"));

            var rolledNumber = string.Join("", digits.Select(e => e.Text));

            return $"Rolled \"{rolledNumber}\" and won \"{winnings}\".";
        }

        public static void StartClaimer()
        {
            Logger.Trace("Starting claimer clock");

            try
            {
                int minutesRemaining = int.Parse(Driver!.FindElement(By.CssSelector("#time_remaining > span.countdown_row.countdown_show2 > span.countdown_section:first-child > span.countdown_amount")).Text);

                ClaimTimer.Interval = TimeSpan.FromMinutes(minutesRemaining + 1).TotalMilliseconds;
            }
            catch (NoSuchElementException)
            {
                ClaimTimer.Interval = 1000;
            }

            ClaimTimer.Start();
        }

        public static void StopClaimer()
        {
            Logger.Trace("Stopping claimer clock");

            ClaimTimer.Stop();
        }

        private static void Claim(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Logger.Info("Claiming");

            ClaimTimer.Stop();

            Driver!.Navigate().Refresh();

            IWebElement rollButton = Driver.FindElement(By.CssSelector("#free_play_form_button"));

            if (rollButton.Displayed)
                rollButton.SendKeys(" "); // TODO: Change this. Click does not interact with the element. STUPID!

            ClaimTimer.Interval = TimeSpan.FromMinutes(ClaimInterval).TotalMilliseconds;
            ClaimTimer.Start();
        }

        public static void Quit()
        {
            Logger.Trace("Closing Chrome Driver");

            if (Driver is not null)
                Driver.Quit();
        }
    }
}
