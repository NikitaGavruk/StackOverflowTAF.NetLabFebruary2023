using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumGridExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.BrowserName, "chrome");

            var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://www.google.com/");
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium Grid example");
            searchBox.Submit();

            driver.Quit();
        }
    }
}

