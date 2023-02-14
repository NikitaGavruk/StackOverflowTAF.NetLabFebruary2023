using UI.Utils;
using UI.Pages;

namespace UI.Steps {
    internal class CompanyPageSteps {

        private static readonly string tagToSearch = new XML_Reader("C:/Users/User/OneDrive/Desktop/.NET Lab/.NET Project/.Net-Lab/UI/Tests/TestData.xml").GetTextFromNode("//TagToSearch");

        CompaniesPage companyPage = new CompaniesPage();

        public bool IsFilterAppliedCorrectly(out int count) {
            bool passed = companyPage.IsCompanyCountDisplayed(out count);
            return
            companyPage.IsNumberDisplayed(1) &&
            companyPage.AreTagsAppearedUnderSearchBar(new string[] { tagToSearch }) &&
            passed;
        }

    }
}
