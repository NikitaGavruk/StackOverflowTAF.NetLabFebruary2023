using OpenQA.Selenium;
using AutomationTeamProject.WebDriver;
using System;
using UI.Utils;

namespace UI.Pages {

    public class GenericSearchedCompanyPage:AbstractPage {
        
        private static readonly By techStackButton = By.XPath("//a[contains(text(),'Tech Stack')]");
        private static readonly By ourTechStackElement = By.XPath("//div[@id='tech-stack-items']/h2");
        private static readonly string searchedTag = "//a[text()='{0}']";
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

        private string GetUrl() =>
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
