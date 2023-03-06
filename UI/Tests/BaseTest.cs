using NUnit.Framework;
using AutomationTeamProject.WebDriver;
using static Core.Logger.Logger;
using static Core.Logger.Logger.ExtentReporter;
using Core.Logger;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using System;
using UI.Utils;
using Core.Utils;

namespace SlackOverFlow
{
    public class BaseTest {

        protected static Browser Browser;
        protected static Logger logger;
        protected static ExtentTest testCase;
        protected static ExtentReports extentReporter = ExtentReporter.ConfigureExtentReporter(Projects.UI);
        protected static XML_Reader xmlReader = new XML_Reader(WebUtils.PathToTestData());


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

                if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                    testCase.Log(extentStatus,
                    $"[{testCase.Model.Name}] Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString()
                    + testCase.AddScreenCaptureFromPath(Environment.CurrentDirectory + @"\" + ScreenshotPath));
                }
                else
                    testCase.Log(extentStatus,
                    $"[{testCase.Model.Name}] Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString()
                    + testCase.AddScreenCaptureFromPath($@"{Environment.CurrentDirectory}\UI\bin\Debug\" + ScreenshotPath));
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