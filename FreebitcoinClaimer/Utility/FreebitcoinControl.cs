﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace FreebitcoinClaimer.Utility
{
    public class FreebitcoinControl
    {
        private static readonly string FreebitcoinHomePage = "https://freebitco.in/";

        private static IWebDriver? Driver;

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
                "user-data-dir=" + (Logger.Level == LogLevel.Debug ? Folders.ChromeProfileDebug : Folders.ChromeProfile),
                "--window-size=1920,1080",
                "--disable-notifications"
                );

            if (Logger.Level != LogLevel.Debug)
                options.AddArgument("headless");

            Driver = new ChromeDriver(chromeService, options);
        }

        public static bool NeedLogin()
        {
            Driver!.Navigate().GoToUrl(FreebitcoinHomePage);

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

            Driver!.Navigate().GoToUrl(FreebitcoinHomePage);

            IWebElement usernameElement;
            IWebElement passwordElement;
            IWebElement faElement;

            try
            {
                usernameElement = Driver.FindElement(By.CssSelector("#login_form_btc_address"));
                passwordElement = Driver.FindElement(By.CssSelector("#login_form_password"));
                faElement = Driver.FindElement(By.CssSelector("#login_form_2fa"));
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Unable to get login elements.");
            }

            if (!usernameElement.Displayed)
                Driver.FindElement(By.CssSelector("li.login_menu_button > a")).Click();

            usernameElement.Clear();
            passwordElement.Clear();
            faElement.Clear();

            usernameElement.SendKeys(username);
            passwordElement.SendKeys(password);
            faElement.SendKeys(fa);

            Driver!.FindElement(By.Id("login_button")).Click();

            Thread.Sleep(2000);

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            try
            {
                wait.Until(drv => drv.FindElement(By.Id("balance")).Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                errorMessage = Driver.FindElement(By.CssSelector("#reward_point_redeem_result_container_div span.reward_point_redeem_result")).Text;
                return false;
            }
        }

        public static double GetBalance()
        {
            IWebElement balanceElement;

            try
            {
                balanceElement = Driver!.FindElement(By.Id("balance"));
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Unable to get balance element.");
            }

            if (!double.TryParse(balanceElement.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double balance))
                throw new Exception("Failed to parse balance value.");

            return balance;
        }

        public static TimeSpan GetCountdown()
        {
            string countdownMinutesElementText = string.Empty;
            string countdownSecondsElementText = string.Empty;

            try
            {
                countdownMinutesElementText = Driver!.FindElement(By.CssSelector("#time_remaining > span.countdown_row > span.countdown_section:nth-child(1) > span.countdown_amount")).Text;
                countdownSecondsElementText = Driver!.FindElement(By.CssSelector("#time_remaining > span.countdown_row > span.countdown_section:nth-child(2) > span.countdown_amount")).Text;
            }
            catch (NoSuchElementException)
            {
                Logger.Warn("Unable to get countdown element.");
            }

            if (!int.TryParse(countdownMinutesElementText, out int minutes))
                minutes = 0;

            if (!int.TryParse(countdownSecondsElementText, out int seconds))
                seconds = 0;

            TimeSpan countdown = TimeSpan.FromMinutes(minutes) + TimeSpan.FromSeconds(seconds);

            return countdown;
        }

        public static void Claim()
        {
            Driver!.Navigate().GoToUrl(FreebitcoinHomePage);

            IWebElement? rollElement = null;

            try
            {
                rollElement = Driver!.FindElement(By.Id("free_play_form_button"));
            }
            catch (NoSuchElementException ex)
            {
                Logger.PrintException("Unable to find free play button.", ex);
            }

            if (rollElement!.Displayed)
                rollElement.SendKeys(" "); // TODO: Change this. Click does not interact with the element. STUPID!

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(
                drv => drv.FindElement(By.Id("free_play_first_digit")));
        }

        public static string GetResult()
        {
            IWebElement? resultElement = null;

            try
            {
                resultElement = Driver!.FindElement(By.Id("free_play_result"));
            }
            catch (NoSuchElementException ex)
            {
                Logger.PrintException("Unable to get free play results.", ex);
            }

            string result = string.Empty;

            if (resultElement is not null)
                result = resultElement.Text;

            return result;
        }

        public static int GetFreePlayDigits()
        {
            IWebElement? fistDigitElement = null;
            IWebElement? secondDigitElement = null;
            IWebElement? thirdDigitElement = null;
            IWebElement? fouthDigitElement = null;
            IWebElement? fifthDigitElement = null;

            try
            {
                fistDigitElement = Driver!.FindElement(By.Id("free_play_first_digit"));
                secondDigitElement = Driver!.FindElement(By.Id("free_play_second_digit"));
                thirdDigitElement = Driver!.FindElement(By.Id("free_play_third_digit"));
                fouthDigitElement = Driver!.FindElement(By.Id("free_play_fourth_digit"));
                fifthDigitElement = Driver!.FindElement(By.Id("free_play_fifth_digit"));

            }
            catch (NoSuchElementException ex)
            {
                Logger.PrintException("Unable to get free play digts.", ex);
            }

            string digitsStr = string.Empty;

            if (fistDigitElement is not null)
                digitsStr = fistDigitElement.Text + secondDigitElement!.Text + thirdDigitElement!.Text + fouthDigitElement!.Text + fifthDigitElement!.Text;

            if (!int.TryParse(digitsStr, out int digits))
                digits = 0;

            return digits;
        }

        public static void Quit()
        {
            if (Driver is not null)
                Driver.Quit();
        }
    }
}
