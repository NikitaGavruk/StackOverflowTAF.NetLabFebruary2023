using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace AutomationTeamProject.WebDriver
{

    public class WebDriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            RemoteChrome,
            RemoteFireFox
        }

        public static IWebDriver GetDriver(BrowserType browser)
        {
            Uri gridHubUrl = new Uri("http://localhost:4444/wd/hub");

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
                case BrowserType.RemoteChrome:
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        RemoteWebDriver chromeDriver = new RemoteWebDriver(gridHubUrl, chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(500));
                        break;
                    }
                case BrowserType.RemoteFireFox:
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        RemoteWebDriver firefoxDriver = new RemoteWebDriver(gridHubUrl, firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(500));
                        break;
                    }
            }
            return WebDriver;
        }

    }

}
