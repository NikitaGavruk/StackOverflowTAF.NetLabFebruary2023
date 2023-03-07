using Core.Utils;
using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class SearchResultPage : AbstractPage
    {

        private static readonly By searchPageTitle = By.XPath("//h1[contains(text(),'Search Results')]");
        private static readonly string searchResult = "//div[contains(text(),'Results for {0}')]";
        private static readonly string searchInGeneral = new XML_Reader(WebUtils.PathToTestData()).GetTextFromNode("//SearchInGeneral");

        public bool IsSearchPageTitleExists()
        {
            return WebDriverExtension.IsElementExists(searchPageTitle,5);
        }

        public bool IsSearchNameExists()
        {
            return WebDriverExtension.IsElementExists(WebUtils.FormatXpath(searchResult,searchInGeneral), 5);
        }

    }

}