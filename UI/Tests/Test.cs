using NUnit.Framework;
using SlackOverFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            generalPage.ExecuteSearchRequest(".gitignore");
            WebUtils.ExecuteCapthaManualy(100);
            Assert.That(searchResultPageSteps.IsSearchDoneCorrectly());
        }
    }
}
