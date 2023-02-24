﻿using AutomationTeamProject.WebDriver;
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
        TimeoutException exception = new TimeoutException();   

        [Test]
        public void VideoFieldIsDisplayed()
        {
            logger.Info("Go to \"For Teams\" Page");
            var forTeamsPageVideoStep = generalPage.GoToForTeamsPage();
            logger.Info("Click on Video button");
            var forTeamsPageVideo = forTeamsPageVideoStep.ClickOnVideoButton();
            logger.Info("Verify that Video field successfully open");
            Assert.IsTrue(forTeamsPageVideo.IsVideoSuccesfulyOpen(), "Video did not open");
        }

        [Test]
        public void SearchTesting()
        {
            logger.Info("Verify search bar is visible");
            Assert.That(generalPage.IsSearchBarVisible());
            logger.Info("Execute search request");
            generalPage.ExecuteSearchRequest(searchInGeneral);
            logger.Info("There is a 100 seconds timer set for doing captcha manually");
            WebUtils.ExecuteCapthaManualy(100);
            logger.Error("If captcha isn't done within 100 seconds, the test will fail", exception.ToString());
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }

        [Test]
        public void TagExists() {

            //Login 
            generalPage = new LoginPageSteps().Login(user);
            //Assert that the home page has loaded correctly
            Assert.That(generalPage.IsPageLoaded());

            //Go To The CompaniesPage
            companiesPage = generalPage.ClickOnCompaniesButton();
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
            companiesPageSteps = new CompanyPageSteps();
            //Assert That the correct events happened after clicking apply filter 
            Assert.That(companiesPageSteps.IsFilterAppliedCorrectly(out int countOfCompanies));

            //Create Instance of a class which included all the URLs for all the 
            //pages returned By search
            genericSearchedPage =
            GenericSearchedCompanyPage.CreateInstance(companiesPage.GetUrls(countOfCompanies));
            //Assert That The Searched Tag is included in each Company's techstack list
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
