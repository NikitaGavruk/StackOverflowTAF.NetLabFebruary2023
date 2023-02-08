using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
     class Wait
    {

        WebDriverWait waiter;
        public void WaitElement(IWebDriver driver, By selector)
        {          
            waiter = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            waiter.Until(driver1=> driver.FindElement(selector).Displayed);

        }
    }
}
