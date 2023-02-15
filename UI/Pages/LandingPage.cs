using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages {
    internal class LandingPage:LoginPage {

        private static readonly By loginButton = By.XPath("//li/a[contains(@data-ga,'login button click')]");
        public static readonly By acceptCookiesbutton = By.XPath("//div[@class='ff-sans ps-fixed z-nav-fixed ws4 sm:w-auto p32 sm:p16 bg-black-750 fc-white bar-lg b16 l16 r16 js-consent-banner']/descendant::button");
        public static readonly By cookiePolicybanner = By.XPath("//div[@class='ff-sans ps-fixed z-nav-fixed ws4 sm:w-auto p32 sm:p16 bg-black-750 fc-white bar-lg b16 l16 r16 js-consent-banner']");


        public LoginPage ClickLogIn() {
            if (WebDriverExtension.IsElementExists(cookiePolicybanner, 10)) 
                ClickAcceptCookies();

            WebDriverExtension.MouseDownByJS(loginButton, 5);
            return new LoginPage();
        }

    }
}
