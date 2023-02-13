using OpenQA.Selenium;
using Utils;
using System;

namespace UI.Pages
{
    internal class MainPage: AbstractPage
    {
        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");

        public bool IsSearchBarVisible() => WebDriverExtension.IsElementClickable(searchBar, 10);



        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");

        public SearchPage InputSearchWord(string searchWord)
        {
            WebDriverExtension.InputTextInFieldByJS(searchBar, 5, searchWord);
        }

        public MainPage ClickEnter() =>
            WebDriverExtension.ClickOnEnter(searchBar, 5);
        return this;
    }
}