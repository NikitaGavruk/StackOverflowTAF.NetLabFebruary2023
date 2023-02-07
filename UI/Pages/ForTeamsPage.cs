using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
    internal class ForTeamsPage : AbstractPage
    {

        By videoButtonElement = By.XPath("//a[contains(text(),' Watch overview video')]");
        By copyFieldElement = By.XPath("//div[contains(text(),'Copy link')]");
        public ForTeamsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Navigate()
        {
            driver.Navigate().GoToUrl("https://stackoverflow.co/teams/");
        }

        public bool isSuccesfulyGoToTeamsPage()
        {
            return driver.FindElement(videoButtonElement).Displayed;
        }

        public void videoWatvhing()
        {
            IWebElement videoButton = driver.FindElement(videoButtonElement);
            videoButton.Click();
        }
        public bool isSuccesfulyVideoOpened()
        {
            return driver.FindElement(copyFieldElement).Displayed;
        }

    }
}
