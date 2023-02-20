using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class ForTeamsPage : AbstractPage
    {

        By videoButtonElement = By.XPath("//a[contains(text(),' Watch overview video')]");
        By videoFieldElement = By.XPath("//aside[@class='s-modal']");

        public ForTeamsPage ClickOnWatchVideoButton()
        {
            WebDriverExtension.ClickOnButton(videoButtonElement);
            return new ForTeamsPage();
        }

        public bool IsVideoSuccesfulyOpen()
        {
            return WebDriverExtension.IsElementVisible(videoFieldElement,5);
        }

    }

}
