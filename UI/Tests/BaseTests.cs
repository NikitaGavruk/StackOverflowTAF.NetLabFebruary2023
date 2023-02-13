using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace SlackOverFlow
{
    public class BaseTest
    {

        protected static Browser Browser = Browser.Instance;
        protected LoggerClass Log;
      
        [SetUp]
        public void Setup()
        {
            Log = LoggerManager.GetLogger(this.GetType());
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo(Configuration.StartUrl);

        }

        [TearDown]
        public void Quite()
        {
           
            Browser.QuiteBrowser();
        }
    }
}