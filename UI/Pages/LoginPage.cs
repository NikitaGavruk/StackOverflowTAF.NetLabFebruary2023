using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages {

    internal class LoginPage : AbstractPage
    {

        private static readonly By loginButtonFormContainer = By.Id("submit-button");
        private static readonly By emailField = By.Id("email");
        private static readonly By passwordField = By.Id("password");

        public LoginPage InputEmail(string accountEmail)
        {
            WebDriverExtension.InputTextInField(emailField, 5, accountEmail);
            return new LoginPage();
        }

        public LoginPage InputPassword(string accountPasswrod)
        {
            WebDriverExtension.InputTextInField(passwordField, 5, accountPasswrod);
            return new LoginPage();
        }

        public T ClickLogIn<T>() where T : AbstractPage
        {
            WebDriverExtension.MouseDownByJS(loginButtonFormContainer, 5);
            return Activator.CreateInstance<T>();
        }

    }

}
