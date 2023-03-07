using UI.Entities;
using UI.Pages;
using UI.Utils;

namespace UI.Steps {

    public class LoginPageSteps {
        
        private readonly LoginPage loginPage = new LoginPage();

        public GeneralPage Login(User user) {
            LandingPage landing = new LandingPage();
            landing.ClickLogIn();
            WebUtils.AcceptAllCookies();
            loginPage.InputEmail(user.email);
            loginPage.InputPassword(user.password);
            loginPage.ClickLogIn<GeneralPage>();
            return new GeneralPage();
        }

    }

}
