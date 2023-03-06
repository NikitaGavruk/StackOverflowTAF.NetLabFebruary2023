using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SearchFeatureSteps
    {
        private readonly HomePage homePage;
        private readonly SearchResultPage searchResultPage;

        public SearchFeatureSteps(HomePage homePage, SearchResultPage searchResultPage)
        {
            this.homePage = homePage;
            this.searchResultPage = searchResultPage;
        }

        [Given(@"the user is on the homepage")]
        public void GivenTheUserIsOnTheHomepage()
        {
            homePage.NavigateTo();
        }

        [Given(@"the search bar is visible")]
        public void GivenTheSearchBarIsVisible()
        {
            Assert.That(homePage.IsSearchBarVisible());
        }

        [When(@"the user enters ""(.*)"" into the search bar")]
        public void WhenTheUserEntersIntoTheSearchBar(string data)
        {
            homePage.EnterSearchData(data);
        }

        [When(@"executes the search request")]
        public void WhenExecutesTheSearchRequest()
        {
            homePage.ClickSearchButton();
            searchResultPage.WaitForPageToLoad();
        }

        [Then(@"the search results should be displayed within 100 seconds")]
        public void ThenTheSearchResultsShouldBeDisplayedWithin100Seconds()
        {
            Assert.That(searchResultPage.IsSearchResultsDisplayedWithin100Seconds());
        }
    }

}
