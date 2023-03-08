using AutomationTeamProject.WebDriver;
using Core.Utils;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using static Core.Logger.Logger.ExtentReporter;
using static Core.Logger.Logger;
using Core.Logger;
using UI.Utils;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;

namespace BDD.Hooks {

    [Binding]
    public class Hooks {

        private ScenarioContext scenarioContext;
        protected static Browser Browser;
        protected static Logger logger;
        protected static ExtentTest testCase;
        protected static ExtentReports extentReporter = ExtentReporter.ConfigureExtentReporter(Projects.BDD);
        protected static XML_Reader xmlReader = new XML_Reader(WebUtils.PathToTestData());

        public Hooks(ScenarioContext scenarioContext) {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario() {
            testCase = extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
            testCase.Model.Name = TestContext.CurrentContext.Test.Name;
            logger = new Logger(GetType());
            logger.Info($"Start Test [{testCase.Model.Name}]");
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            logger.Info("Go to General page");
            Browser.StartNavigate();
            scenarioContext["browser"] = Browser;
            scenarioContext["logger"] = logger;
            scenarioContext["testCase"] = testCase;
            scenarioContext["xmlReader"] = xmlReader;
            scenarioContext["extentReporter"] = extentReporter;
        }

        [AfterScenario]
        public void AfterScenario() {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;
            Status extentStatus = ExtentReporter.TestStatusConvert(TestContext.CurrentContext.Result.Outcome.Status);

            if (NUnit_status.Equals(TestStatus.Failed)) {
                string ScreenshotPath = ScreenshotTaker.TakeScreenShot(Projects.BDD);
                logger.Error("Test found error. Screenshot has been taken, ", TestContext.CurrentContext.Result.Message);

                if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                    testCase.Log(extentStatus,
                    $"[{testCase.Model.Name}] Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString()
                    + testCase.AddScreenCaptureFromPath(Environment.CurrentDirectory + @"\" + ScreenshotPath));
                }
                else
                    testCase.Log(extentStatus,
                    $"[{testCase.Model.Name}] Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString()
                    + testCase.AddScreenCaptureFromPath($@"{Environment.CurrentDirectory}\BDD\bin\Debug\" + ScreenshotPath));
            }
            else {
                logger.Info($"[{testCase.Model.Name}] Test ended with Status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
                testCase.Log(extentStatus,
                    "Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
            Browser.QuiteBrowser();
        }

        [AfterFeature]
        public static void AfterFeature() {
            ExtentFlush(extentReporter);
        }

    }

}
