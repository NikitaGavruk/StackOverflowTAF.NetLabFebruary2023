using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumGrid
{
    class SeleniumGrid
    {
        public static void Grid()
        {
            Uri gridHubUrl = new Uri("http://localhost:4444/wd/hub");

            ChromeOptions chromeOptions = new ChromeOptions();
            RemoteWebDriver chromeDriver = new RemoteWebDriver(gridHubUrl, chromeOptions.ToCapabilities());

            FirefoxOptions firefoxOptions = new FirefoxOptions();
            RemoteWebDriver firefoxDriver = new RemoteWebDriver(gridHubUrl, firefoxOptions.ToCapabilities());

            chromeDriver.Navigate().GoToUrl("https://www.google.com");
            firefoxDriver.Navigate().GoToUrl("https://www.google.com");

            chromeDriver.Quit();
            firefoxDriver.Quit();
        }
    }
}
