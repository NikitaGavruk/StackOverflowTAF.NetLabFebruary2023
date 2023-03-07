using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages {

    public class LandingPage:LoginPage {

        private static readonly By loginButton = By.XPath("//a[contains(text(),'Log in')]");

        public LoginPage ClickLogIn() {
            WebUtils.AcceptAllCookies();
            WebDriverExtension.MouseDownByJS(loginButton, 5);
            return new LoginPage();
        }

    }

}
