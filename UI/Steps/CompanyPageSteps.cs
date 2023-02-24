using UI.Pages;
using Core.Utils;

namespace UI.Steps {

    internal class CompanyPageSteps {

        private static readonly string tagToSearch = new XML_Reader("../../Tests/TestData.xml").GetTextFromNode("//TagToSearch");
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
