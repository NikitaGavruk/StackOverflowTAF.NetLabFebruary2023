using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
    internal class GeneralPage : AbstractPage
    {
        By forTeamsButtonElement = By.XPath("//a[contains(text(),'For Teams')] ");
        Wait wait = new Wait();
        public GeneralPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Navigate()
        {
            driver.Navigate().GoToUrl("https://stackoverflow.com/");
        }

        public void GoToForTeamsPage()
        {
            IWebElement forTeamsButton = driver.FindElement(forTeamsButtonElement);
            wait.WaitElement(driver,forTeamsButtonElement);
            forTeamsButton.Click();
        }
    }
}
