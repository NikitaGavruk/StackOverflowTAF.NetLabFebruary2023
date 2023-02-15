using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using AutomationTeamProject.WebDriver;
namespace SlackOverFlow
{
    public class BaseTest
    {
        protected static Browser Browser;
      
        [SetUp]
        public void Setup()
        {
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