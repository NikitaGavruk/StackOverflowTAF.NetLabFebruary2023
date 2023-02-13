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
        Search searchWord = new Search(TestData.searchWord);
        MainPage mainPage;
        CaptchaPage captchaPage;
        SearchPage searchPage;
        SearchResultPage searchResultPage;

  

        [Test]
        public void SearchTesting()
        {

            //Verifying Clickability of search button 
            Assert.That(mainPage.IsSearchBarVisible());

            //Input search text
            searchPage.InputSearchWord(searchWord);
            //Clicking Enter
            searchPage.ClickEnter()
            //Assert that the captcha page has been opened
            Assert.That(captchaPage.DoesCaptchaButtonExist());

            //Dealing with captcha manually
            captchaPage.DoCaptchaManually();

            //Assert that The Search page is opened
            searchResultPage = new SearchResultPage();
            Assert.That(searchResultPage.IsSearchDoneCorrectly());

           


        }


    }

}