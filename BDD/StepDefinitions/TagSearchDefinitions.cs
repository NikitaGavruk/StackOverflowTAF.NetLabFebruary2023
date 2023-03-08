using NUnit.Framework;
using UI.Pages;
using UI.Entities;
using UI.Steps;
using Core.Utils;
using Core.Logger;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions {

    [Binding]
    public sealed class TagSearchDefinitions {

        private ScenarioContext scenarioContext;
        GeneralPage generalPage = new GeneralPage();
        private readonly string email;
        private readonly string password;
        private readonly string tagToSearch;
        User user;
        CompaniesPage companiesPage;
        CompanyPageSteps companiesPageSteps;
        GenericSearchedCompanyPage genericSearchedPage;
        private int countOfCompanies;


        public TagSearchDefinitions(ScenarioContext scenarioContext) {
            this.scenarioContext = scenarioContext;
            email = scenarioContext.Get<XML_Reader>("xmlReader").GetTextFromNode("//Email");
            password = scenarioContext.Get<XML_Reader>("xmlReader").GetTextFromNode("//Password");
            tagToSearch = scenarioContext.Get<XML_Reader>("xmlReader").GetTextFromNode("//TagToSearch");
            user = new User(email, password);
        }


        [Given(@"I am successfully logged in")]
        public void GivenIAmSuccessfullyLoggedIn() {
            scenarioContext.Get<Logger>("logger").Info("Log into The system");
            generalPage = new LoginPageSteps().Login(user);
            scenarioContext.Get<Logger>("logger").Info("Assert that the home page has loaded correctly");
            Assert.That(generalPage.IsPageLoaded());
        }

        [When(@"I go to the Companies Page")]
        public void IgototheCompaniesPage() {
            scenarioContext.Get<Logger>("logger").Info("CLick On the 'Companies' Button");
            companiesPage = generalPage.ClickOnCompaniesButton();
            scenarioContext.Get<Logger>("logger").Info("Assert that the companies page has loaded correctly");
            Assert.That(companiesPage.IsPageLoaded());
        }

        [When(@"I click the 'Filter By Tag' Button")]
        public void IClickTheFIlterByTagButton() {
            scenarioContext.Get<Logger>("logger").Info("Click On The Filter By Tag Button");
            companiesPage.ClickonFilterByTagButton();
            scenarioContext.Get<Logger>("logger").Info("Assert that The FilterPane Pane is Visible");
            Assert.That(companiesPage.IsFilterPaneVisible());
        }

        [When(@"I Input '([^']*)' In the searchbox of the tag pane")]
        public void WhenIInputInTheSearchboxOfTheTagPane(string tag) {
            scenarioContext.Get<Logger>("logger").Info("Input 'rust' in the searchbox of the filter by tag pane");
            companiesPage.InputInTheFilterByTagSearchBox();
            scenarioContext.Get<Logger>("logger").Info("Assert that the suggestions appear after inputting");
            Assert.That(companiesPage.IsSuggestionsPaneVisisble);
        }

        [When(@"Click on the searched Tag")]
        public void WhenClickOnTheSearchedTag() {
            scenarioContext.Get<Logger>("logger").Info("Click on the suggestion if it exactly matches the input tag");
            companiesPage.ClickOnTheElementThatCompletelyMatchesTheSearchCriteria();
        }

        [Then(@"The Tag should get attached to the searchbox with the option to remove it")]
        public void ThenTheTagShouldGetAttachedToTheSearchboxWithTheOptionToRemoveIt() {
            scenarioContext.Get<Logger>("logger").Info("Assert that the suggestions pane disappeared");
            Assert.That(companiesPage.IsSuggestionsPaneDisappeared());
            scenarioContext.Get<Logger>("logger").Info("Assert that the clicked tag got fixed on the 'filter by tag' searchbox");
            Assert.That(companiesPage.IsClickedTagFixedOnTheSearchBar());
        }

        [When(@"I click the 'Apply Filter' button")]
        public void WhenIClickTheApplyFilterButton() {
            scenarioContext.Get<Logger>("logger").Info("Click on the apply filter button");
            companiesPage.ClickApplyFilterButton();
        }

        [Then(@"The selected filter should get applied correctly")]
        public void ThenTheSelectedFilterShouldGetAppliedCorrectly() {
            companiesPageSteps = new CompanyPageSteps();
            scenarioContext.Get<Logger>("logger").Info("Assert That\n1. The Company Count Is Displayed under The SearchBox" +
                        "\n2. The Count Of Selected Tags Is Displayed within the 'Filter By Tag' Button" +
                        "\n3. The Selected Tags Appeared Under The SearchBox");
            Assert.That(companiesPageSteps.IsFilterAppliedCorrectly(out countOfCompanies));
        }

        [When(@"I Navigate To each page returned by the filter and click on the 'Our Tech Stack' tab")]
        public void WhenINavigateToEachPageReturnedByTheFilterAndClickOnTheOurTechStackTab() {
            scenarioContext.Get<Logger>("logger").Info("Create Instance of a class which included all the URLs for all the " +
                         "pages returned By search");
            genericSearchedPage =
            GenericSearchedCompanyPage.CreateInstance(companiesPage.GetUrls(countOfCompanies));
            scenarioContext.Get<Logger>("logger").Info("Go To each Company's page and " +
                         "Assert That The Searched Tag is included in each Company's techstack list");
        }

        [Then(@"The '([^']*)' should be in the list of 'Our Tech Stack' area")]
        public void ThenTheShouldBeInTheListOfArea(string tag) {
            Assert.That(genericSearchedPage.IsTagExists(countOfCompanies, tagToSearch));
        }

    }

}