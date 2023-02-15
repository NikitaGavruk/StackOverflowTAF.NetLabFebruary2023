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
            chrome,
            Firefox
        }

        public static IWebDriver GetDriver(BrowserType browser, int TimeoutSec)
        {
            IWebDriver WebDriver = null;
            switch (browser)
            {
                case BrowserType.chrome:
                    {
                        var Service = ChromeDriverService.CreateDefaultService();
                        var Option = new ChromeOptions();
                        WebDriver = new ChromeDriver(Service, Option, TimeSpan.FromSeconds(TimeoutSec));
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
