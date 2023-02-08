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
        Wait wait = new Wait();
        By forTeamsButtonElement = By.XPath("//a[contains(text(),'For Teams')] ");

        public GeneralPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Navigate()
        {
            driver.Navigate().GoToUrl("https://stackoverflow.com/");
        }

        public void GoToForTeamsPage()
        {
            wait.WaitElement(driver, forTeamsButtonElement);
            IWebElement forTeamsButton = driver.FindElement(forTeamsButtonElement);
            forTeamsButton.Click();
        }


    }
}
