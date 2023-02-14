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

        public WebUtils DoCaptchaManually()
        {
            return WebDriverExtensions.WaitUntilCaptchaIsDoneManually(100);
        }

        public static void ClickOnEnter(By xpath, int waitSeconds)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            WaitUntilElementIsClickable(xpath, waitSeconds);
            Browser.GetDriver().FindElement(xpath).SendKeys(Keys.Enter);
        }

        public static void WaitUntilCaptchaIsDoneManually(int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds));
        }
    }

}