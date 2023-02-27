using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using AutomationTeamProject.WebDriver;
using static Core.Logger.Logger;
using Core.Logger;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using System;
using UI.Utils;

namespace SlackOverFlow
{
    public class BaseTest {

        protected static Browser Browser;
        protected static Logger logger;
        protected static ExtentReports extentReporter = ExtentReporter.ConfigureExtentReporter();
        protected static ExtentTest testCase;

        [SetUp]
        public void Setup()
        {
            testCase = extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
            testCase.Model.Name = TestContext.CurrentContext.Test.Name;
            logger = new Logger(GetType());
            logger.Info($"Start Test [{testCase.Model.Name}]");
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            logger.Info("Go to General page");
            Browser.StartNavigate();
        }

        [TearDown]
        public void Quite()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;
            Status extentStatus = ExtentReporter.TestStatusConvert(TestContext.CurrentContext.Result.Outcome.Status);

            if (NUnit_status.Equals(TestStatus.Failed))
            {
                string ScreenshotPath = ScreenshotTaker.TakeScreenShot();
                logger.Error("Test found error. Screenshot has been taken, ", TestContext.CurrentContext.Result.Message);
                testCase.Log(extentStatus,
                    $"[{testCase.Model.Name}] Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString()
                    + testCase.AddScreenCaptureFromPath(Environment.CurrentDirectory+@"\"+ScreenshotPath));
            }
            else {
                logger.Info($"[{testCase.Model.Name}] Test ended with Status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
                testCase.Log(extentStatus,
                    "Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
            Browser.QuiteBrowser();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReporter.ExtentFlush(extentReporter);
        }

    }

}