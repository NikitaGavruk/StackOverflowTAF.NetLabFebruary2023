using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using StackOverFlow.WebDrvier;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using UI.Exceptions;

namespace UI.Utils
{
    internal static class WebDriverExtension
    {

        public static void ClickOnButton(By xpath, int waitSeconds)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            WaitUntilElementIsClickable(xpath, waitSeconds);
            Browser.GetDriver().FindElement(xpath).Click();
        }

        public static void ClickOnEnter(By xpath, int waitSeconds)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            WaitUntilElementIsClickable(xpath, waitSeconds);
            Browser.GetDriver().FindElement(xpath).SendKeys(Keys.Enter);
        }

        public static string GetTextFromField(By xpath, int waitSeconds)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            return Browser.GetDriver().FindElement(xpath).Text;
        }
        public static string[] GetTextFromEachField(By xpath, int waitSeconds)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            ReadOnlyCollection<IWebElement> collection = Browser.GetDriver().FindElements(xpath);
            string[] list = new string[collection.Count];
            int iterator = 0;
            foreach (IWebElement item in collection)
            {
                list[iterator] = item.Text;
                iterator++;
            }
            return list;
        }
        public static string GetAttributeValueFromField(By xpath, int waitSeconds, string attribute)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            return Browser.GetDriver().FindElement(xpath).GetAttribute(attribute);
        }
        public static void InputTextInField(By xpath, int waitSeconds, String input)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            Browser.GetDriver().FindElement(xpath).SendKeys(input);
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

        public static void WaitUntilCaptchaIsDoneManually(int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds));
        }

        public static void WaitUntilElementIsVisible(By xpath, int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(xpath));
        }
        public static void WaitUntilElementIsExists(By xpath, int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(xpath));
        }
        public static void WaitUntilElementIsClickable(By xpath, int seconds)
        {

            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(xpath));
        }
        public static void MouseDown(By xpath, int waitSeconds)
        {
            WaitUntilElementIsClickable(xpath, waitSeconds);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).Click().Perform();
        }
        public static void InputTextInFieldByActions(By xpath, int waitSeconds, string keys)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).SendKeys(keys).Perform();
        }
        public static void InputTextInFieldByJS(By xpath, int waitSeconds, string keys)
        {
            WaitUntilElementIsVisible(xpath, waitSeconds);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(xpath));
        }
        public static void MouseDownByJS(By xpath, int waitSeconds)
        {
            WaitUntilElementIsClickable(xpath, waitSeconds);
            Browser.GetJSExecuter().ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(xpath));
        }

        public static int GetPageYOffset() =>
            (int)Browser.GetJSExecuter().ExecuteScript("return window.pageYOffset;");

        public static string GetAttributeFromElement(string xpathCriteria, string attributeName) =>
            Browser.GetDriver().FindElement(By.XPath(xpathCriteria)).GetAttribute(attributeName).ToString();


    }
}