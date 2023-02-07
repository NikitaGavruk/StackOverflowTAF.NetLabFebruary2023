using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal abstract class AbstractPage
    {
      protected IWebDriver driver;
        public AbstractPage(IWebDriver driver) {
            this.driver = driver;
        }

        public abstract void Navigate();

        public virtual bool isLoaded()
        {
            return driver.Url.Contains("stackoverflow.com");

        }
    }
}
