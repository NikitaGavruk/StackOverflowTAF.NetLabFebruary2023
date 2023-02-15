using AutomationTeamProject.WebDriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace UI.Utils
{
    internal class WebDriverExtension
    {
        public static void ClickOnButton(By xpath)
        {
            WaitUntilElementIsVisible(xpath, 3);
            WaitUntilElementIsClickable(xpath, 3);
            Browser.GetDriver().FindElement(xpath).Click();
        }

        public static bool IsElementClickable(By xpath)
        {
            bool status = true;
            try
            {
                WaitUntilElementIsClickable(xpath, 3);
            }
            catch (WebDriverTimeoutException)
            {
                status = false;
            }
            return status;
        }

        public static bool IsElementVisible(By xpath)
        {
            bool status = true;
            try
            {
                WaitUntilElementIsVisible(xpath, 10);
            }
            catch (WebDriverTimeoutException)
            {
                status = false;
            }
            return status;
        }

        public static void WaitUntilElementIsVisible(By xpath, int second)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementIsVisible(xpath));
        }

        public static void WaitUntilElementIsClickable(By xpath, int second)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementToBeClickable(xpath));
        }
    }
}
