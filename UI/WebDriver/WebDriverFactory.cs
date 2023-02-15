using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationTeamProject.WebDriver
{
    public class WebDriverFactory
    {
        public enum Browsertype
        {
            Chrome,
            Firefox
        }

        public static IWebDriver GetDriver(Browsertype browser, int TimeoutSec)
        {
            IWebDriver WebDriver = null;
            switch (browser)
            {
                case Browsertype.Chrome:
                    {
                        WebDriver = new ChromeDriver();
                        break;
                    }
                case Browsertype.Firefox:
                    {
                        WebDriver = new FirefoxDriver();
                        break;
                    }
            }
            return WebDriver;
        }
    }
}
