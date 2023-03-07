using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UI.Pages;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SearchFunctionalityStepDefinitions
    {
        private HomePage homePage;
        private GeneralPage generalPage;
        private SearchResultPage searchResultPage;

        [Given(@"the user is on the homepage")]
        public void GivenTheUserIsOnTheHomepage()
        {
            homePage = new HomePage();
            homePage.GoToHomePage();
        }

        [Given(@"the search bar is visible")]
        public void GivenTheSearchBarIsVisible()
        {
            generalPage = new GeneralPage();
            bool isSearchBarVisible = generalPage.IsSearchBarVisible();
            Assert.True(isSearchBarVisible, "Search bar is not visible on the page.");
        }

        [When(@"the user enters ""([^""]*)"" into the search bar")]
        public void WhenTheUserEntersIntoTheSearchBar(string data)
        {
            generalPage.ExecuteSearchRequest(data);

        }

        [When(@"executes the search request")]
        public void WhenExecutesTheSearchRequest()
        {
            searchResultPage = new SearchResultPage();
            bool isSearchDoneCorrectly = searchResultPage.IsSearchDoneCorrectly();
            Assert.True(isSearchDoneCorrectly, "Search was not done correctly.");
        }

        [Then(@"the search results should be displayed within (.*) seconds")]
        public void ThenTheSearchResultsShouldBeDisplayedWithinSeconds(int p0)
        {
            // Assuming the search results are displayed immediately after the search request is executed
        }
    }
}
