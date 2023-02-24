using AutomationTeamProject.WebDriver;
using Core.Utils;
using NUnit.Framework;
using SlackOverFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Entities;
using UI.Pages;
using UI.Steps;
using UI.Utils;

namespace UI.Tests
{
    [TestFixture]
    internal class Test:BaseTest
    {

        GeneralPage generalPage = new GeneralPage();
        SearchResultPageSteps searchResultPageSteps = new SearchResultPageSteps();
        private static readonly XML_Reader xmlReader = new XML_Reader(@"..\..\Tests\TestData.xml");
        private static readonly string email = xmlReader.GetTextFromNode("//Email");
        private static readonly string password = xmlReader.GetTextFromNode("//Password");
        private static readonly string tagToSearch = xmlReader.GetTextFromNode("//TagToSearch");
        private static readonly string searchInGeneral = xmlReader.GetTextFromNode("//SearchInGeneral");
        User user = new User(email, password);
        CompaniesPage companiesPage;
        CompanyPageSteps companiesPageSteps;
        GenericSearchedCompanyPage genericSearchedPage;

        [Test]
        public void VideoFieldIsDisplayed()
        {
           var forTeamsPageVideo = generalPage.GoToForTeamsPage().ClickOnVideoButton();
           Assert.IsTrue(forTeamsPageVideo.IsVideoSuccesfulyOpen(), "Video did not open");
        }

        [Test]
        public void SearchTesting()
        {
            Assert.That(generalPage.IsSearchBarVisible());
            generalPage.ExecuteSearchRequest(searchInGeneral);
            WebUtils.ExecuteCapthaManualy(100);
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }

        [Test]
        public void TagExists() {

            logger.Debug("Log into The system");
            generalPage = new LoginPageSteps().Login(user);
            logger.Debug("Assert that the home page has loaded correctly");
            Assert.That(generalPage.IsPageLoaded());

            logger.Debug("CLick On the 'Companies' Button");
            companiesPage = generalPage.ClickOnCompaniesButton();
            logger.Debug("Assert that the companies page has loaded correctly");
            Assert.That(companiesPage.IsPageLoaded());

            logger.Debug("Click On The Filter By Tag Button");
            companiesPage.ClickonFilterByTagButton();
            logger.Debug("Assert that The FilterPane Pane is Visible");
            Assert.That(companiesPage.IsFilterPaneVisible());

            logger.Debug("Input 'rust' in the searchbox of the filter by tag pane");
            companiesPage.InputInTheFilterByTagSearchBox();
            logger.Debug("Assert that the suggestions appear after inputting");
            Assert.That(companiesPage.IsSuggestionsPaneVisisble);

            logger.Debug("Click on the suggestion if it exactly matches the input tag");
            companiesPage.ClickOnTheElementThatCompletelyMatchesTheSearchCriteria();
            logger.Debug("Assert that the suggestions pane disappeared");
            Assert.That(companiesPage.IsSuggestionsPaneDisappeared());
            logger.Debug("Assert that the clicked tag got fixed on the 'filter by tag' searchbox");
            Assert.That(companiesPage.IsClickedTagFixedOnTheSearchBar());

            logger.Debug("Click on the apply filter button");
            companiesPage.ClickApplyFilterButton();
            companiesPageSteps = new CompanyPageSteps();
            logger.Debug("Assert That\n1. The Company Count Is Displayed under The SearchBox" +
                        "\n2. The Count Of Selected Tags Is Displayed within the 'Filter By Tag' Button" +
                        "\n3. The Selected Tags Appeared Under The SearchBox");
            Assert.That(companiesPageSteps.IsFilterAppliedCorrectly(out int countOfCompanies));

            logger.Debug("Create Instance of a class which included all the URLs for all the " +
                         "pages returned By search");
            genericSearchedPage =
            GenericSearchedCompanyPage.CreateInstance(companiesPage.GetUrls(countOfCompanies));
            logger.Debug("Go To each Company's page and " +
                         "Assert That The Searched Tag is included in each Company's techstack list");
            Assert.That(genericSearchedPage.IsTagExists(countOfCompanies, tagToSearch));

        }

        [Test]
        public void WhoweAreIsDisplay()
        {
            Browser.NavigateTo("https://stackoverflow.co/");
            var CareersPage = generalPage.GoToCareerPages();
            Assert.That(CareersPage.WhoWeAreIsVisiblse, Is.True, "the element 'Who we Are' is not visible ");
        }

    }

}
