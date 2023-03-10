using AutomationTeamProject.WebDriver;
using Core.Logger;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SearchTestingStepDefinitions
    {
        private ScenarioContext scenarioContext;
        SearchResultPageSteps searchResultPageSteps = new SearchResultPageSteps();
        GeneralPage generalPage = new GeneralPage();

        public SearchTestingStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I should see the search bar")]
        public void GivenIShouldSeeTheSearchBar()
        {
            scenarioContext.Get<Logger>("logger").Info("Search bar should be visible");
            Assert.That(generalPage.IsSearchBarVisible());
        }

        [When(@"I execute search with a given word")]
        public void WhenIExecuteSearchWithAGivenWord()
        {
            scenarioContext.Get<Logger>("logger").Info("Execute search with a given word");
            generalPage.ExecuteSearchRequest(".gitignore");
        }

        [Then(@"I should see search results")]
        public void ThenIShouldSeeSearchResults()
        {
            scenarioContext.Get<Logger>("logger").Info("Search is done correctly");
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }
    }
}