using NUnit.Framework;
using SlackOverFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;
using UI.Steps;

namespace UI.Tests
{
    [TestFixture]
    internal class Test:BaseTest
    {
        GeneralPage generalPage = new GeneralPage();
        MainPage mainPage = new MainPage();
        SearchResultPage searchResultPage = new SearchResultPage();
        SearchResultPageSteps searchResultPageSteps = new SearchResultPageSteps();

        [Test]
        public void VideoFieldIsDisplayed()
        {
           var forTeamsPageVideo = generalPage.GoToForTeamsPage().ClickOnVideoButton();
           Assert.IsTrue(forTeamsPageVideo.IsVideoSuccesfulyOpen(), "Video did not open");
        }

        [Test]
        public void SearchTesting()
        {

            //Verifying Clickability of search button 
            Assert.That(mainPage.IsSearchBarVisible());
            //Execute search
            var searchResultPage mainPage.ExecuteSearchRequest(".gitignore").ClickEnter();
            //Assert that the captcha page has been opened
            Assert.That(WebUtils.IsCaptchaButtonExists());
            //Dealing with captcha manually
            WebUtils.DoCaptchaManually();
            //Assert that The Search page is opened
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());

        }
    }
}
