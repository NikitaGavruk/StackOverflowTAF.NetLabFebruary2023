using NUnit.Framework;
using StackOverFlow.WebDrvier;
using UI.Entities;
using UI.Pages;
using UI.Steps;
using UI.Utils;

namespace UI.Tests
{

    [TestFixture]
    internal class Tests
    {

        protected static Browser Browser;
        string searchWord = ".gitignore";
        MainPage mainPage;
        CaptchaPage captchaPage;
        SearchResultPage searchResultPage;

  

        [Test]
        public void SearchTesting()
        {

            //Verifying Clickability of search button 
            Assert.That(mainPage.IsSearchBarVisible());

            //Input search text
            mainPage.InputSearchWord(searchWord);
            //Clicking Enter
            mainPage.ClickEnter()
            //Assert that the captcha page has been opened
            Assert.That(WebUtils.IsCaptchaButtonExists());

            //Dealing with captcha manually
            WebUtils.DoCaptchaManually();

            //Assert that The Search page is opened
            searchResultPage = new SearchResultPage();
            Assert.That(searchResultPage.IsSearchDoneCorrectly());

        }


    }

}