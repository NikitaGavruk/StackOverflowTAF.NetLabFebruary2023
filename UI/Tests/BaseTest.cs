using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using AutomationTeamProject.WebDriver;
using UI.Utils.Logger;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System;
using AventStack.ExtentReports;

namespace SlackOverFlow
{
    public class BaseTest
    {
        protected static Browser Browser;
        protected static Logger logger;
      
        [SetUp]
        public void Setup()
        {
            logger = new Logger(GetType());
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.StartNavigate();
        }

        [TearDown]
        public void Quite()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed)) {
                ScreenshotTaker.TakeScreenShot();
                logger.Error("Test found error. Screenshots has been taken", TestContext.CurrentContext.Result.Message);
            }
            logger.Info("Test ended with " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
     
            var reportPath = @"UI\bin\Debug\Reports";
            if (Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);
            var htmlReporter = new ExtentHtmlReporter(reportPath+@"\report.html");

            ExtentReports _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            ExtentTest _test= _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log((Status)TestContext.CurrentContext.Result.Outcome.Status, "Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString() + " Message:" + TestContext.CurrentContext.Result.Message);

            _extent.Flush();
            Browser.QuiteBrowser();
        }
    }
}