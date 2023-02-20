using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationTeamProject.WebDriver
{

    public class WebDriverFactory
    {

        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public static IWebDriver GetDriver(BrowserType browser)
        {
            IWebDriver WebDriver = null;
            switch (browser)
            {
                case BrowserType.Chrome:
                    {
                        WebDriver = new ChromeDriver();
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        WebDriver = new FirefoxDriver();
                        break;
                    }
            }
            return WebDriver;
        }

    }

}
