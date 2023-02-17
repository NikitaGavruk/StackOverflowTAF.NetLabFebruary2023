using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using AutomationTeamProject.WebDriver;
using UI.Utils.Logger;
using NUnit.Framework.Interfaces;

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
            Browser.QuiteBrowser();
        }
    }
}