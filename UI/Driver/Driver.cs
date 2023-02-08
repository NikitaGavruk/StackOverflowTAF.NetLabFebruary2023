using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Driver
{
    public class Driver
    {
       IWebDriver driver;

        public  IWebDriver GetChromeDriver()
        {
                driver = new ChromeDriver();
                return driver;              
        }

        public  void Close()
        {
            driver.Quit();
        }
    }
}
