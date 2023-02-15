using AutomationTeamProject.WebDriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void ClickOnEnter(By xpath)
        {
            WaitUntilElementIsVisible(xpath, 3);
            WaitUntilElementIsClickable(xpath, 3);
            Browser.GetDriver().FindElement(xpath).SendKeys(Keys.Enter);
        }

        public static bool IsElementVisible(By xpath, int seconds)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(xpath));
            }
            catch (WebDriverTimeoutException)
            {
                status = false;
            }
            return status;
        }

        public static bool IsElementExists(By xpath, int seconds)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(xpath));
            }
            catch (WebDriverTimeoutException)
            {
                status = false;
            }
            return status;
        }
        public static bool IsElementClickable(By xpath, int seconds)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(xpath));
            }
            catch (WebDriverTimeoutException)
            {
                status = false;
            }
            return status;
        }

        public static void WaitUntilElementIsExists(By xpath, int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(xpath));
        }

        public static void WaitUntilElementIsVisible(By xpath, int second)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementIsVisible(xpath));
        }

        public static void WaitUntilElementIsClickable(By xpath, int second)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementToBeClickable(xpath));
        }

        public static void InputTextInFieldByJS(By xpath, string keys)
        {
            WaitUntilElementIsVisible(xpath, 3);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(xpath));
        }
    }
}
