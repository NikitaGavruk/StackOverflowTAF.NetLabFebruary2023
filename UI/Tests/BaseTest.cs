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
using System.Drawing.Imaging;
using System.Diagnostics;
using AventStack.ExtentReports.Reporter.Configuration;

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

            string path = String.Format(@"UI\bin\Debug\Reports" + @"\{0}_TestRun",
                DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path + @"\index.html");

            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Reports";
            htmlReporter.Config.ReportName = "Reporting For StackOverFlow Tests";
            ExtentReports _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            
            ExtentTest _test= _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log((Status)TestContext.CurrentContext.Result.Outcome.Status, "Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString() + " Message:" + TestContext.CurrentContext.Result.Message);
            _test.Log((Status)TestContext.CurrentContext.Result.Outcome.Status, "hehey"+_test.AddScreenCaptureFromPath(@"C:\Users\User\OneDrive\Desktop\.NET Lab\.NET Project\.Net-Lab\UI\bin\Debug\Screenshots\17-02-2023T22-35-34_WhoweAreIsDisplay.jpeg"));
            string[] jjc = Directory.GetDirectories($"{Environment.CurrentDirectory}\\UI\\bin\\Debug\\Reports");
            if (jjc.Length >= 5) {
                foreach (var item in jjc) {
                    Directory.Delete(item,true);
                }
            }

            _extent.Flush();
            Browser.QuiteBrowser();
        }
    }
}