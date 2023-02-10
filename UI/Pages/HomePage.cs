using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages {
    internal class HomePage:AbstractPage {
        
        private static readonly By overFlowBlogFirstItem = By.XPath("//div[@id='sidebar']/div/descendant::li[2]/div[2]");
        private static readonly By companiesButton = By.XPath("//div[contains(text(),'Companies')]");

        public bool IsPageLoaded() =>
            WebDriverExtension.IsElementClickable(overFlowBlogFirstItem, 5);


        public CompaniesPage ClickOnCompaniesButton() {
            WebDriverExtension.MouseDownByJS(companiesButton, 5);
            return new CompaniesPage();
        }

    }
}
