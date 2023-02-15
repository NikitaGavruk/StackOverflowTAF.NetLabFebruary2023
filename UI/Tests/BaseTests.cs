using NUnit.Framework;
using AutomationTeamProject.WebDriver;

namespace UI.Tests {

    public class BaseTests
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
