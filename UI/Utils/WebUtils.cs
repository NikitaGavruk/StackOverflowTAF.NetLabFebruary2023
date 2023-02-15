using OpenQA.Selenium;
using System;

namespace UI.Utils
{

    internal static class WebUtils
    {
        //Captcha
        private static readonly By captchaButton = By.XPath("//div[@class='recaptcha - checkbox - border']");


        public bool IsCaptchaButtonExists()
        {
            return IsElementExists(captchaButton, 10);
        }

        public void DoCaptchaManually()
        {
           WaitUntilCaptchaIsDoneManually(100);
        }

        public void WaitUntilCaptchaIsDoneManually(int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds));
        }
    }

}