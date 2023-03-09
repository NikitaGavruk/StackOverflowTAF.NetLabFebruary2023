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
    internal class FunctionalityOfStackoverflowStepDefinitions
    {

        private ScenarioContext scenarioContext;
        ForTeamsPage forTeamsPage = new ForTeamsPage();
        ForTeamsSteps forTeamsSteps = new ForTeamsSteps();
        GeneralPage generalPage = new GeneralPage();

        public FunctionalityOfStackoverflowStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I go to  ""For Teams"" page")]
        public void GivenIGoToPage()
        {
            scenarioContext.Get<Logger>("logger").Info("Go to For Teams page");
            forTeamsSteps = generalPage.GoToForTeamsPage();
        }

        [When(@"I click on ""Watch Overview Video"" button")]
        public void WhenIClickTheButton()
        {
            scenarioContext.Get<Logger>("logger").Info("Click on video button");
            forTeamsPage = forTeamsSteps.ClickOnVideoButton();
        }

        [Then(@"I should see that the video field displayed")]
        public void ThenIShouldSeeThatTheVideoFieldDisplayed()
        {
            scenarioContext.Get<Logger>("logger").Info("Verify that Video field successfully open");        
            Assert.IsTrue(forTeamsPage.IsVideoSuccesfulyOpen());
        }

    }

}
