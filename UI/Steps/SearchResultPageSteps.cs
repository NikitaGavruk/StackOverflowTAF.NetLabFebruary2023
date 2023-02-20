using UI.Utils;
using UI.Pages;

namespace UI.Steps
{
    internal class SearchResultPageSteps
    {

        SearchResultPage searchResultPage = new SearchResultPage();

        public bool IsSearchDoneCorrectly()
        {
            return searchResultPage.IsSearchPageTitleExists() && searchResultPage.IsSearchNameExists();
        }

    }

}