using NUnit.Framework;
using StackOverFlow.WebDrvier;

namespace UI.Tests {

    [TestFixture]
    internal class BaseTest {

        protected static Browser browser;

        [SetUp]
        public void Setup() {
            browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo("https://stackoverflow.com/");
        }

        [TearDown]
        public void Quit() {
            Browser.QuitBrowser();
        }

    }

}
