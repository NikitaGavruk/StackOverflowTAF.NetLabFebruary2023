﻿using UI.Entities;
using UI.Pages;
using UI.Utils;

namespace UI.Steps {
    internal class LoginPageSteps {
        
        private readonly LoginPage loginPage = new LoginPage();

        public HomePage Login(User user) {
            LandingPage landing = new();
            landing.ClickLogIn();

            if (WebDriverExtension.IsElementClickable(LoginPage.acceptCookiesbutton, 5))
                loginPage.ClickAcceptCookies();

            loginPage.InputEmail(user.email);
            loginPage.InputPassword(user.password);
            loginPage.ClickLogIn<HomePage>();
            return new HomePage();
        }

    }
}
