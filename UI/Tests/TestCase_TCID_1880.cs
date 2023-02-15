using NUnit.Framework;
using SlackOverFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Tests
{
    [TestFixture]
    internal class TestCase_TCID_1880 : BaseTest
    {
        GeneralPage generalPage = new GeneralPage();

        [Test]
        public void WhoweAreIsDisplay()
        {
            var CareersPage=generalPage.GoToCareerPages();
            Assert.That(CareersPage.WhoWeAreIsVisiblse,Is.True);
        }

    }
}
