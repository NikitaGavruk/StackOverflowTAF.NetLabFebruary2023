using OpenQA.Selenium;
using Utils;

namespace UI.Pages
{
    internal class HomePage: AbstractPage
    {
        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");

        public bool IsSearchBarVisible() => WebDriverExtension.IsElementClickable(searchBar, 10);


    }
}