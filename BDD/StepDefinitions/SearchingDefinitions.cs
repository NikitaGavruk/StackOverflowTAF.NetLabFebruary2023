using AutomationTeamProject.WebDriver;
using Core.Logger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SearchFunctionalityStepDefinitions
    {
        private ScenarioContext scenarioContext;
        SearchResultPage searchResultPage = new SearchResultPage();
        SearchResultPageSteps searchResultPageSteps = new SearchResultPageSteps();
        GeneralPage generalPage = new GeneralPage();
        public SearchFunctionalityStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"the search bar is visible")]
        public void GivenTheSearchBarIsVisible()
        {
            scenarioContext.Get<Logger>("logger").Info("Search bar should be visible");
            Assert.That(generalPage.IsSearchBarVisible());
        }

        [When(@"executes the search request")]
        public void WhenExecutesTheSearchRequest()
        {
            scenarioContext.Get<Logger>("logger").Info("Execute search with a given word");
            generalPage.ExecuteSearchRequest(".gitignore");
        }

        [Then(@"the search results should be displayed within (.*) seconds")]
        public void ThenTheSearchResultsShouldBeDisplayedWithinSeconds(int p0)
        {
            scenarioContext.Get<Logger>("logger").Info("Search is done correctly");
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }
    }
}