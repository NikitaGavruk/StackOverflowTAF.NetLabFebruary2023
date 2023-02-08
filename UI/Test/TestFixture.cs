using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;
using UI.Driver;

namespace UI
{
    internal class TestFixture
    {
        IWebDriver driver;
        Driver.Driver drivers = new Driver.Driver();
        ForTeamsPage forTeamsPage;
        GeneralPage generalPage;

       [SetUp]
        public void SetUp()
        {

            driver = drivers.GetChromeDriver();
            driver.Manage().Window.Maximize();
            forTeamsPage = new ForTeamsPage(driver);
            generalPage = new GeneralPage(driver);

        }

        [Test]
        public void VideoFieldIsDisplayed()
        {
            //Act
            generalPage.Navigate();
            generalPage.GoToForTeamsPage();
            forTeamsPage.CookiesNessAccept();
            forTeamsPage.videoWatching();
            //Assert
            Assert.IsTrue(forTeamsPage.isSuccesfulyVideoOpened());           

        }

        [TearDown]
        public void TearDown()
        {
            drivers.Close();
        }
    }
}
