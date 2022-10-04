using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FreebitcoinClaimer.Utility
{
    public static class FreebitcoinControl
    {
        private static string FreebitcoinHomePage = "https://freebitco.in/";
        private static double ClaimInterval = 60;

        private static IWebDriver Driver;
        private static IJavaScriptExecutor JavaScriptExecutor;

        private static System.Timers.Timer ClaimTimer;

        private static ChromeOptions GetDefaultOptions(bool headless = false)
        {
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

            if (headless)
                options.AddArgument("headless");

            return options;
        }

        internal static void Setup()
        {
            var chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.HideCommandPromptWindow = true;
            chromeService.SuppressInitialDiagnosticInformation = true;

            Driver = new ChromeDriver(chromeService, GetDefaultOptions(Logger.Level != LogLevel.Debug));
            JavaScriptExecutor = (IJavaScriptExecutor)Driver;

            ClaimTimer = new System.Timers.Timer();

            Driver.Navigate().GoToUrl(FreebitcoinHomePage);
        }

        public static bool NeedLogin()
        {
            try
            {
                Driver.FindElement(By.CssSelector("#balance_small"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool Login(string username, string password, string fa, out string errorMessage)
        {
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
                Driver.FindElement(By.CssSelector("#balance_small"));
                return true;
            }
            catch (NoSuchElementException)
            {
                errorMessage = Driver.FindElement(By.CssSelector("#reward_point_redeem_result_container_div span.reward_point_redeem_result")).Text;
                return false;
            }
        }

        public static string GetBalance()
        {
            return Driver.FindElement(By.CssSelector("#balance")).Text;
        }

        public static void StartClaimer()
        {
            try
            {
                int minutesRemaining = int.Parse(Driver.FindElement(By.CssSelector("#time_remaining > span.countdown_row.countdown_show2 > span.countdown_section:first-child > span.countdown_amount")).Text);

                ClaimTimer.Interval = TimeSpan.FromMinutes(minutesRemaining + 1).TotalMilliseconds;
            }
            catch (NoSuchElementException)
            {
                ClaimTimer.Interval = 1000;
            }

            ClaimTimer.Elapsed += Claim;
            ClaimTimer.Start();
        }

        private static void Claim(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Driver.Navigate().Refresh();
            ClaimTimer.Stop();
            IWebElement rollButton = Driver.FindElement(By.CssSelector("#free_play_form_button"));

            if (rollButton.Displayed)
                rollButton.SendKeys(" "); // TODO: Change this. Click does not interact with the element. STUPID!

            ClaimTimer.Interval = TimeSpan.FromMinutes(ClaimInterval).TotalMilliseconds;
            ClaimTimer.Start();
        }

        public static void StopClaimer()
        {
            ClaimTimer.Stop();
        }

        public static void Quit()
        {
            if (Driver is not null)
                Driver.Quit();
        }
    }
}
