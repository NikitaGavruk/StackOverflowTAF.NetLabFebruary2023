using Core.Utils;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using UI.Exceptions;
using UI.Utils;

namespace UI.Pages {

    internal class CompaniesPage {

        private static readonly By firstCompanyLogoInCompanyList = By.XPath("//div[@class='company-list']/descendant::img[1]");
        private static readonly By filterByTagButton = By.XPath("//button[@id='filter-button-tech']");
        private static readonly By filterByTagButtonAppended = By.XPath("//button[@id='filter-button-tech']/span[2]");
        private static readonly By filterByTagPaneSearchBox = By.Id("tageditor-replacing-tl--input");
        private static readonly By applyFilterButton = By.XPath("//button[contains(text(),'Apply filter')]");
        private static readonly By suggestionsPane = By.XPath("//div[contains(@id,'tag-suggestions')]");
        private static readonly By suggestionThatMatches = By.XPath("(//span[@class='match'])[1]");
        private static readonly By countOfCompanies = By.XPath("//span[@class='description fs-body2']");
        private static readonly string filtersUnderSearchBox = "//button[contains(text(),'Clear filters')]//preceding-sibling::span[contains(text(),'{0}')]";
        private static readonly string fixedSuggestion = "//span[@class='s-tag rendered-element' and text()='{0}']";
        private static readonly string searchedCompanyGenericCompanyName = "//div[@class='company-list']/div[{0}]//descendant::h2/a";
        private static readonly string tagToSearch = new XML_Reader(@"..\..\Tests\TestData.xml").GetTextFromNode("//TagToSearch");
        
        public bool IsPageLoaded() =>
            WebDriverExtension.IsElementClickable(firstCompanyLogoInCompanyList, 5);

        public void ClickonFilterByTagButton() =>
            WebDriverExtension.MouseDownByJS(filterByTagButton, 1);

        public bool IsFilterPaneVisible() =>
            WebDriverExtension.IsElementVisible(filterByTagPaneSearchBox, 1);

        public void InputInTheFilterByTagSearchBox() {
            WebDriverExtension.ClickOnButton(filterByTagPaneSearchBox, 1);
            WebDriverExtension.InputTextInField(filterByTagPaneSearchBox, 1, tagToSearch);         
        }

        public bool IsSuggestionsPaneVisisble() =>
            WebDriverExtension.IsElementVisible(suggestionsPane, 2);

        public void ClickOnTheElementThatCompletelyMatchesTheSearchCriteria() {
            if (WebDriverExtension.IsElementClickable(suggestionThatMatches, 3))
                WebDriverExtension.ClickOnButton(suggestionThatMatches, 1);
            else
                throw new WebElementOperationException("No Suggestion Was Found That Exactly " +
                    "Matched The Searched Tag");
        }

        public bool IsSuggestionsPaneDisappeared() =>
            !IsSuggestionsPaneVisisble();

        public bool IsClickedTagFixedOnTheSearchBar() =>
            WebDriverExtension.IsElementExists(WebUtils.FormatXpath(fixedSuggestion, tagToSearch),2);

        public void ClickApplyFilterButton() =>
            WebDriverExtension.ClickOnButton(applyFilterButton, 5);

        public bool IsNumberDisplayed(int count) {
            string text = WebDriverExtension.GetTextFromField(filterByTagButtonAppended, 20);
            return text == count.ToString();
        }

        public bool AreTagsAppearedUnderSearchBar(string[] filters) {
            if (filters is null)
                throw new ArgumentNullException();
            string[] list = WebDriverExtension.GetTextFromEachField(WebUtils.FormatXpath(filtersUnderSearchBox,tagToSearch), 3);
            bool passed = true;
            if (filters.Length != list.Length)
                return false;
            for(int i = 0; i < list.Length; i++) {
                if (list[i] != filters[i])
                    passed = false;
            }
            return passed;
        }

        public bool IsCompanyCountDisplayed(out int count) {
            WebDriverExtension.WaitUntilElementIsExists(WebUtils.FormatXpath(
                filtersUnderSearchBox, tagToSearch), 5);

            string stringCount = WebDriverExtension.GetTextFromField(countOfCompanies, 5);
            Match regex = Regex.Match(stringCount, @"[\d]+");
            count = Int32.Parse(regex.Value);
            return WebDriverExtension.IsElementExists(countOfCompanies,20);
        }

        public string[] GetUrls(int count) {
            if (count < 1)
                throw new ArgumentException();
            string[] list = new string[count];
            By selector;
            string incompleteUrl;
            while (count != 0) {
                selector = WebUtils.FormatXpath(searchedCompanyGenericCompanyName, count.ToString());
                incompleteUrl = WebDriverExtension.GetAttributeFromElement(selector.Criteria, "href");
                list[count-1] = incompleteUrl;
                count--;
            }
            return list;
        }
        
    }

}
