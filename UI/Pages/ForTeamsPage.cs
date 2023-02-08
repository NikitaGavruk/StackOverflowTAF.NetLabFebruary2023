using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI.Pages
{
    internal class ForTeamsPage : AbstractPage
    {
        Wait wait = new Wait();
        By videoButtonElement = By.XPath("//a[contains(text(),' Watch overview video')]");
        By videoFieldElement = By.XPath("//aside[@class='s-modal']");
        By cookiesbuttonacElement = By.XPath("//button[@id='onetrust-reject-all-handler']");


        public ForTeamsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Navigate()
        {
            driver.Navigate().GoToUrl("https://stackoverflow.co/teams/");
        }

        public void videoWatching()
        {
            wait.WaitElement(driver, videoButtonElement);
            IWebElement videoButton = driver.FindElement(videoButtonElement);
            videoButton.Click();
        }
        public bool isSuccesfulyVideoOpened()
        {
            wait.WaitElement(driver, videoFieldElement);
            IWebElement copyField = driver.FindElement(videoFieldElement);
            return copyField.Displayed;
        }

        public void CookiesNessAccept()
        {
            wait.WaitElement(driver, cookiesbuttonacElement);
            IWebElement cookButton = driver.FindElement(cookiesbuttonacElement);
            if (cookButton.Displayed)
            {
                cookButton.Click();
            }
        }

    }
}
