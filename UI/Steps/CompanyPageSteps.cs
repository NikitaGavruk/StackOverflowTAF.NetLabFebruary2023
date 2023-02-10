using UI.Utils;
using UI.Pages;

namespace UI.Steps {
    internal class CompanyPageSteps {

        CompaniesPage companyPage = new();

        public bool IsFilterAppliedCorrectly(out int count) {
            bool passed = companyPage.IsCompanyCountDisplayed(out count);
            return
            companyPage.IsNumberDisplayed(1) &&
            companyPage.AreTagsAppearedUnderSearchBar(new string[] { TestData.tagToSearch }) &&
            passed;
        }

    }
}
