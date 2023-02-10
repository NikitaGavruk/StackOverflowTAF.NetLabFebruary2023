using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace StackOverFlow.WebDrvier
{
    public class Browser
    {
        private static Browser _currentInstance;
        private static Actions _actions;
        private static IJavaScriptExecutor _jsExecuter;
        private static IWebDriver webDriver;
        public static BrowserType _currentBrowser= BrowserType.Chrome;
        private static string _browser;

        private Browser()
        {
            webDriver = WebDriverFactory.GetDriver(_currentBrowser);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());
        public static void WindowMaximaze()
        {
            webDriver.Manage().Window.Maximize();
        }
        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
        public static IWebDriver GetDriver()
        {
            return webDriver;
        }
        public static Actions GetActions()
        {
            _actions = new Actions(GetDriver());
            return _actions;
        }
        public static IJavaScriptExecutor GetJSExecuter()
        {
            _jsExecuter = (IJavaScriptExecutor) GetDriver();
            return _jsExecuter;
        }
        public static void QuitBrowser()
        {
            webDriver.Quit();
            _currentInstance = null;
            webDriver = null;
            _browser = null;
        }
    }
}
