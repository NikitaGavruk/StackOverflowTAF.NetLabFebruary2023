using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages
{
    internal class SearchPage: AbstractPage
    {
        private static readonly By searchBar = By.XPath("//input[@placeholder='Search…']");

        public SearchPage InputSearchWord(string searchWord)
        {
            WebDriverExtension.InputTextInFieldByJS(searchBar, 5, searchWord);
        }

        public void ClickEnter() =>
            WebDriverExtension.ClickOnEnter(searchBar, 5);


    }
}