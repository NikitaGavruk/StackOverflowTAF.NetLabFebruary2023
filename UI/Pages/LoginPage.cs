using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages {

    internal class LoginPage:AbstractPage {

        private static readonly By loginButtonFormContainer = By.XPath("//button[@name='submit-button' and text()='Log in']");
        private static readonly By loginButtonTopBar = By.XPath("//li/a[contains(@data-ga,'login button click')]");
        private static readonly By emailField = By.XPath("//input[@id='email']");
        private static readonly By passwordField = By.XPath("//input[@id='password']");
        public static readonly By acceptCookiesbutton = By.XPath("//button[contains(text(),'Accept all')]");

        public LoginPage InputEmail(string accountEmail) {
            WebDriverExtension.InputTextInField(emailField, 5, accountEmail);
            return new LoginPage();
        }

        public LoginPage InputPassword(string accountPasswrod) {
            WebDriverExtension.InputTextInField(passwordField, 5, accountPasswrod);
            return new LoginPage();
        }

        public T ClickLogIn<T>() where T : AbstractPage {
            WebDriverExtension.MouseDownByJS(loginButtonFormContainer,5);
            return Activator.CreateInstance<T>();
        }

        public void ClickAcceptCookies() =>
            WebDriverExtension.ClickOnButton(acceptCookiesbutton, 5);

    }

}
