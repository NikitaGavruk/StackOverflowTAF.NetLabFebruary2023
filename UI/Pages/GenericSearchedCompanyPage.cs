using OpenQA.Selenium;
using StackOverFlow.WebDrvier;
using System;
using UI.Utils;

namespace UI.Pages {
    internal class GenericSearchedCompanyPage:AbstractPage {
        
        private static readonly By techStackButton = By.XPath("//*[@id='company-page']/header/nav/a[contains(text(),'Tech Stack')]");
        private static readonly By ourTechStackElement = By.XPath("//div[@id='tech-stack-items']/*[1]");
        private static readonly string searchedTag = "//h2[@class='fs-subheading fw-normal fc-black-900']/following-sibling::div[1 and child::a[contains(@href,'')]]/a[text()='{0}']";

        private readonly string[] Urls;
        private int iterator = 0;
        private GenericSearchedCompanyPage(string[] Urls) {
            if (Urls.Length < 1)
                throw new ArgumentException();
            this.Urls = Urls;
        }

        public static GenericSearchedCompanyPage CreateInstance(string[] Urls) =>
            new GenericSearchedCompanyPage(Urls);
        
        private void Iterate() {
            if(iterator!=Urls.Length-1)
            iterator++;
        }

        private string getUrl() =>
            Urls[iterator];

        private void NavigateToPage() {
            Browser.NavigateTo(Urls[iterator]);
            Iterate();
        }

        private void ClickTechStackButon() =>
            WebDriverExtension.MouseDownByJS(techStackButton, 10);

        private bool IsScrolledToView() =>
            WebDriverExtension.IsElementVisible(ourTechStackElement, 5);

        private bool IsTagExistsInTechStack(string tag) =>
            WebDriverExtension.IsElementExists(WebUtils.FormatXpath(searchedTag, tag), 1);
        

        public bool IsTagExists(int count, string tag) {
            bool control = false;
            while (count != 0) {
                NavigateToPage();
                ClickTechStackButon();
                control = IsScrolledToView();
                control = IsTagExistsInTechStack(tag);
                count--;
            }
            return control;
        }

    }
}
