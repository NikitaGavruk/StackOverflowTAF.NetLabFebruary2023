using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI
{
    internal class TestFixture
    {
        IWebDriver driver;
        ForTeamsPage forTeamsPage;
        GeneralPage generalPage;

       [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            ForTeamsPage forTeamsPage = new ForTeamsPage(driver);
            GeneralPage generalPage = new GeneralPage(driver);
            

        }

        [Test]
        public void VideoFieldIsDisplayed()
        {
            generalPage.Navigate();
            generalPage.GoToForTeamsPage();
            forTeamsPage.videoWatvhing();
            Assert.IsTrue(forTeamsPage.isSuccesfulyVideoOpened());
            

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
