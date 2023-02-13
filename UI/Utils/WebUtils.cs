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
            ExternalMethods.IsElementExists(captchaButton, 10);
        }

        public void DoCaptchaManually()
        {
            ExternalMethods.WaitUntilCaptchaIsDoneManually(100);
        }
    }

}