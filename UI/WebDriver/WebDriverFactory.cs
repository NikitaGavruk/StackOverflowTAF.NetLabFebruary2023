using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;

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
                        chromeOptions.AddArgument("--disable-dev-shm-usage");
                        chromeOptions.AddArgument("--no-sandbox");
                        chromeOptions.AddArgument("--headless");
                        WebDriver = new RemoteWebDriver(gridHubUrl, chromeOptions);
                        break;
                    }
                case BrowserType.RemoteFireFox:
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        WebDriver = new RemoteWebDriver(gridHubUrl, firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(500));
                        break;
                    }
            }
            return WebDriver;
        }

    }

}
