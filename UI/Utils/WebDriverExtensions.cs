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
        public static void WaitUntilCaptchaIsDoneManually(int seconds)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(seconds));
        }
    }
}