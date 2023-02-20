using AutomationTeamProject.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UI.Utils {

    internal static class WebUtils {

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
    }

}