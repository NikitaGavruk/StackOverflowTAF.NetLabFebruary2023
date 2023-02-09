﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTeamProject.WebDriver
{
    internal class WebDriverFactory
    {
        public enum Browsertype
        {
            chrome,
            Firefox
        }

        public static IWebDriver GetDriver(Browsertype browser, int TimeoutSec)
        {
            IWebDriver WebDriver = null;
            switch (browser)
            {
                case Browsertype.chrome:
                    {
                        var Service = ChromeDriverService.CreateDefaultService();
                        var Option = new ChromeOptions();
                        WebDriver = new ChromeDriver(Service, Option, TimeSpan.FromSeconds(TimeoutSec));
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