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
        ForTeamsSteps forTeamsSteps = new ForTeamsSteps();

        [Test]
        public void VideoFieldIsDisplayed()
        {
            generalPage.GoToForTeamsPage();
            var forTeamsPageVideo = forTeamsSteps.ClickOnVideoButton();
            Assert.IsTrue(forTeamsPageVideo.IsVideoSuccesfulyOpen(), "Video did not open");
        }
    }
}
