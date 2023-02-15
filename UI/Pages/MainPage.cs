using OpenQA.Selenium;
using Utils;
using System;

namespace UI.Pages
{
    internal class MainPage : AbstractPage
    {
        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");

        public bool IsSearchBarVisible() => WebDriverExtension.IsElementClickable(searchBar, 10);

        public SearchPage ExecuteSearchRequest(string searchWord)
        {
            WebDriverExtension.InputTextInFieldByJS(searchBar, 5, searchWord);
            return SearchResultPage;
        }

        public MainPage ClickEnter() =>
            WebDriverExtension.ClickOnEnter(searchBar, 5);
        return this;
    }
}