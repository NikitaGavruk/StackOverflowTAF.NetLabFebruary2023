using UI.Utils;
using UI.Pages;

namespace UI.Steps
{
    internal class SearchResultPageSteps
    {

        SearchResultPage searchResultPage = new();

        public bool IsSearchDoneCorrectly()
        {
            return searchResultPage.DoesSearchPageTitleExist() && searchResultPage.DoesSearchNameExist();
        } 

    }
}