using AutomationTeamProject.WebDriver;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SearchFunctionalityStepDefinitions
    {
        static Browser? Browser;
        SearchResultPage searchResultPage = new SearchResultPage();
        SearchResultPageSteps searchResultPageSteps = new SearchResultPageSteps();
        GeneralPage generalPage = new GeneralPage();

        [Given(@"the user is on the homepage")]
        public void GivenTheUserIsOnTheHomepage()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.StartNavigate();
        }

        [Given(@"the search bar is visible")]
        public void GivenTheSearchBarIsVisible()
        {
            Assert.That(generalPage.IsSearchBarVisible());
        }

        [When(@"executes the search request")]
        public void WhenExecutesTheSearchRequest()
        {
          generalPage.ExecuteSearchRequest(".gitignore");
        }

        [Then(@"the search results should be displayed within (.*) seconds")]
        public void ThenTheSearchResultsShouldBeDisplayedWithinSeconds(int p0)
        {
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }
    }
}
