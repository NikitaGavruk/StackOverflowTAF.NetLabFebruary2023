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
        private static readonly By forTeamsButtonElement = By.XPath("//a[contains(text(),'For Teams')] ");
        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");
        private static readonly By careerButtonElement = By.Id("company-careers");


        public CareersPage GoToCareerPages()
        {
            WebDriverExtension.ClickOnButton(careerButtonElement);
            return new CareersPage();
        }

        public ForTeamsSteps GoToForTeamsPage()
        {
            WebDriverExtension.ClickOnButton(forTeamsButtonElement);
            return new ForTeamsSteps();
        }

        public bool IsSearchBarVisible()
        {
            return WebDriverExtension.IsElementClickable(searchBar, 5);
        }
        public SearchResultPage ExecuteSearchRequest(string searchWord)
        {
            WebDriverExtension.InputTextInFieldByJS(searchBar, searchWord);
            WebDriverExtension.ClickOnEnter(searchBar);
            return new SearchResultPage();
        }



    }
}


