﻿using UI.Entities;
using UI.Pages;
using UI.Utils;

namespace UI.Steps {
    internal class LoginPageSteps {
        
        private readonly LoginPage loginPage = new LoginPage();

        public GeneralPage Login(User user) {
            LandingPage landing = new LandingPage();
            landing.ClickLogIn();

            if (WebDriverExtension.IsElementExists(LandingPage.cookiePolicybanner, 10))
                LandingPage.ClickAcceptCookies();

            loginPage.InputEmail(user.email);
            loginPage.InputPassword(user.password);
            loginPage.ClickLogIn<GeneralPage>();
            return new GeneralPage();
        }

    }
}
