using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages
{
    internal class SearchResultPage : AbstractPage
    {
        private static readonly By searchPageTitle = By.XPath("//h1[@class='flex--item fl1 fs-headline1 mb0']");
        private static readonly By searchResult = By.XPath("//div[contains(text(),'Results for .gitignore')]");

        public bool IsSearchPageTitleExists()
        {
            return WebDriverExtension.IsElementExists(searchPageTitle,5);
        }

        public bool IsSearchNameExists()
        {
            return WebDriverExtension.IsElementExists(searchResult, 5);
        }
    }
}