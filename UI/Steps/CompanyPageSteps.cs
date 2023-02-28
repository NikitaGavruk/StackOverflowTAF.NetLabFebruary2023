using UI.Pages;

namespace UI.Steps {

    internal class CompanyPageSteps : CompaniesPage {

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
