using AutomationTeamProject.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static Core.Logger.Logger;

namespace UI.Utils {

    public static class WebUtils {

        private static readonly By captchaCheckbox = By.XPath("//div[@class='recaptcha - checkbox - border']");
        private static readonly By cookiesButtonElement = By.XPath("//button[contains(text(), 'Accept all cookies')]");

        public static By FormatXpath(string xpath, string argument) {
            return By.XPath(string.Format(xpath, argument));
        }

        public static void ExecuteCapthaManualy(int seconds) {
            WebDriverExtension.IsElementExists(captchaCheckbox, 10);
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds));
        }

        public static void AcceptAllCookies()
        {
            if (WebDriverExtension.IsElementVisible(cookiesButtonElement, 10))
            {
                WebDriverExtension.ClickOnButton(cookiesButtonElement);
            }

        }

        public static string PathToTestData() {
            if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                return @".\..\..\..\UI\Tests\TestData.xml";
            }
            else
                return @"UI\Tests\TestData.xml";
        }

    }

}