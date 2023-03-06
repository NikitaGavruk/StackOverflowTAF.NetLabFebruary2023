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

        private static readonly By forTeamsButtonElement = By.XPath("//a[contains(text(),'For Teams')]");
        private static readonly By searchBar = By.Name("q");
        private static readonly By overFlowBlogFirstItem = By.XPath("(//div[contains(@Class,'ow-break-word')])[1]");
        private static readonly By companiesButton = By.XPath("//div[contains(text(),'Companies')]");
        private static readonly By careerButtonElement = By.Id("company-careers");
        private static readonly By profileButtonElement = By.XPath("//span[contains(text(),'George')]//parent::a");

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

        public ProfilePage GoToProfilePage()
        {
            WebDriverExtension.ClickOnButton(profileButtonElement);
            return new ProfilePage();
        }

        public bool IsSearchBarVisible()
        {
            return WebDriverExtension.IsElementClickable(searchBar,5);
        }

        public SearchResultPage ExecuteSearchRequest(string searchWord)
        {
            WebDriverExtension.InputTextInFieldByJS(searchBar, searchWord);
            WebDriverExtension.ClickOnEnter(searchBar);
            return new SearchResultPage();
        }

        public bool IsPageLoaded() =>
            WebDriverExtension.IsElementClickable(overFlowBlogFirstItem, 5);

        public CompaniesPage ClickOnCompaniesButton() {
            WebDriverExtension.MouseDownByJS(companiesButton, 5);
            return new CompaniesPage();
        }

    }

}


