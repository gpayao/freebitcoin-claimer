using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreebitcoinClaimer.Utility
{
    public static class FreebitcoinControl
    {
        private static string FreebitcoinHomePage = "https://freebitco.in/";
        private static double ClaimInterval = 60;

        private static IWebDriver Driver;
        private static IJavaScriptExecutor JavaScriptExecutor;

        private static System.Timers.Timer Timer;

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

            Driver = new ChromeDriver(chromeService, GetDefaultOptions(false));
            JavaScriptExecutor = (IJavaScriptExecutor)Driver;

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

        private static void Claim(object? sender, System.Timers.ElapsedEventArgs e)
        {
            IWebElement claimButton = Driver.FindElement(By.CssSelector(""));

            claimButton.Click();
        }

        public static void StartClaimer()
        {
            Timer = new System.Timers.Timer(TimeSpan.FromMinutes(ClaimInterval).TotalMilliseconds);
            Timer.Elapsed += Claim;
            Timer.Start();
        }

        public static void StopClaimer()
        {
            Timer.Stop();
        }

        public static void Quit()
        {
            if (Driver is not null)
                Driver.Quit();
        }
    }
}
