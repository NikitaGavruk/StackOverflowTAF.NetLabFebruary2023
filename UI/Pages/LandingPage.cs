using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages {
    internal class LandingPage:LoginPage {

        private static readonly By loginButton = By.XPath("//li/a[contains(@data-ga,'login button click')]");

        public LoginPage ClickLogIn() {
            WebDriverExtension.MouseDownByJS(loginButton, 5);
            return new LoginPage();
        }

    }
}
