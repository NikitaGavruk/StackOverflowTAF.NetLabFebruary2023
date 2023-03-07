using AutomationTeamProject.WebDriver;
using NUnit.Framework;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{

    [Binding]
    public class FunctionalityOfStackoverflowStepDefinitions
    {

        static Browser? Browser;
        ForTeamsPage forTeamsPage = new ForTeamsPage();
        ForTeamsSteps forTeamsSteps = new ForTeamsSteps();
        GeneralPage generalPage = new GeneralPage();

        [Given(@"I am on StackOverFlow page")]
        public void GivenIAmOnStackOverFlowPage()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.StartNavigate();
        }

        [When(@"I submit For Teams button")]
        public void WhenISubmitForTeamsButton()
        {
            forTeamsSteps = generalPage.GoToForTeamsPage();
        }

        [When(@"I submit Watch overview video button")]
        public void WhenISubmitWatchOverviewVideoButton()
        {
            forTeamsPage = forTeamsSteps.ClickOnVideoButton();
        }

        [Then(@"I should see video field")]
        public void ThenIShouldSeeVideoField()
        {
            Assert.IsTrue(forTeamsPage.IsVideoSuccesfulyOpen());
            Browser.QuiteBrowser();
        }

    }

}

