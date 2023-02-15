using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Steps;
using UI.Utils;

namespace UI.Pages
{
    internal class GeneralPage : AbstractPage
    {
        By forTeamsButtonElement = By.XPath("//a[contains(text(),'For Teams')] ");
        public ForTeamsSteps GoToForTeamsPage()
        {
            WebDriverExtension.ClickOnButton(forTeamsButtonElement);
            return new ForTeamsSteps();
        }
    }
}
