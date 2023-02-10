using NUnit.Framework;
using StackOverFlow.WebDrvier;
using UI.Entities;
using UI.Pages;
using UI.Steps;
using UI.Utils;

namespace UI.Tests {

    [TestFixture]
    internal class Tests {

        protected static Browser Browser;
        User user = new User(TestData._email,TestData._pasword);
        HomePage homePage;
        CompaniesPage companiesPage;
        CompanyPageSteps companiesPageSteps;
        GenericSearchedCompanyPage genericSearchedPage;

        [SetUp]
        public void Setup() {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo("https://stackoverflow.com/");
        }

        [Test]
        public void Test() {

            //Login 
            homePage = new LoginPageSteps().Login(user);
            //Assert that the home page has loaded correctly
            Assert.That(homePage.IsPageLoaded());

            //Go To The CompaniesPage
            companiesPage = homePage.ClickOnCompaniesButton();
            //Assert that the companies page has loaded correctly
            Assert.That(companiesPage.IsPageLoaded());

            //Click On The Filter By Tag Button
            companiesPage.ClickonFilterByTagButton();
            //Assert that The FilterPane Pane is Visible
            Assert.That(companiesPage.IsFilterPaneVisible());

            //Input "rust" in the searchbox of the filter by tag pane
            companiesPage.InputInTheFilterByTagSearchBox();
            //Assert that the suggestions appear after inputting
            Assert.That(companiesPage.IsSuggestionsPaneVisisble);

            //Click on the suggestion if it exactly matches the input tag
            companiesPage.ClickOnTheElementThatCompletelyMatchesTheSearchCriteria();
            //Assert thatthe suggestions pane disappeared and the clicked tag got fixed
            //on the filter by tag searchbox
            Assert.That(companiesPage.IsSuggestionsPaneDisappeared());
            Assert.That(companiesPage.IsClickedTagFixedOnTheSearchBar());

            //Click on the apply filter button
            companiesPage.ClickApplyFilterButton();
            companiesPageSteps = new();
            //Assert That the correct events happened after clicking apply filter 
            Assert.That(companiesPageSteps.IsFilterAppliedCorrectly(out int countOfCompanies));
            
            //Create Instance of a class which included all the URLs for all the 
            //pages returned By search
            genericSearchedPage =
            GenericSearchedCompanyPage.CreateInstance(companiesPage.GetUrls(countOfCompanies));
            //Asset That The Searched Tag is included in each Company's techstack list
            Assert.That(genericSearchedPage.IsTagExists(countOfCompanies, TestData.tagToSearch));


        }

        [TearDown]
        public void Quit() {
            Browser.QuitBrowser();
        }

    }

}
