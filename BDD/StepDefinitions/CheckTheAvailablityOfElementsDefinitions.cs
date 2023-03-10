using AutomationTeamProject.WebDriver;
using Core.Logger;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UI.Pages;

namespace BDD.StepDefinitions
{
    [Binding]
    public class CheckTheAvailablityOfElementsDefinitions
    {
        private ScenarioContext scenarioContext;
        private GeneralPage generalPage = new GeneralPage();
        private CareersPage careersPage;

        public CheckTheAvailablityOfElementsDefinitions(ScenarioContext scenarioContext) {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to https://stackoverflow.co")]
        public void GivenINavigateToHttpsStackoverflow_Co()
        {
            scenarioContext.Get<Logger>("logger").Info("navigate to https://stackoverflow.co/");
            Browser.NavigateTo("https://stackoverflow.co/");
        }

        [When(@"I navigate to 'Careers' page")]
        public void WhenINavigateToPage()
        {
            scenarioContext.Get<Logger>("logger").Info("navigate to career page");
            careersPage = generalPage.GoToCareerPages();
        }

        [Then(@"I can see the 'who we are' section")]
        public void ThenICanSeeTheSection()
        {
            scenarioContext.Get<Logger>("logger").Info("find the\"Who we are section\"");
            Assert.That(careersPage.WhoWeAreIsVisiblse, Is.True, "the element 'Who we Are' is not visible ");
        }
    }
}
