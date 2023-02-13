using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages
{
    internal class CaptchaPage : AbstractPage
    {

        
        private static readonly By captchaButton = By.XPath("//div[@class='recaptcha - checkbox - border']");


        public bool DoesCaptchaButtonExist()
        {
            WebDriverExtension.IsElementExists(captchaButton, 10);
        }

        public void DoCaptchaManually()
        {
              WebDriverExtension.WaitUntilCaptchaIsDoneManually(100);
        }

        


    }
}