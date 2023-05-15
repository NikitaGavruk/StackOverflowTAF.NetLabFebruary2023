using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using static AutomationTeamProject.WebDriver.WebDriverFactory;

namespace AutomationTeamProject.WebDriver
{
    public class Browser
    {

        public static BrowserType _currentBrowser;
        private static Browser _currentInstance;
        private static string _browser;
        private static int ImplWait;
        private static IWebDriver webDriver;
        private static Actions _actions;
        private static IJavaScriptExecutor _jsExecuter;

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out _currentBrowser);
        }

        private Browser()
        {
            InitParams();
            webDriver = WebDriverFactory.GetDriver(_currentBrowser);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());
        
        public static IWebDriver GetDriver()
        {
            return webDriver;
        }
        
        public static void WindowMaximaze()
        {
            webDriver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }  

        public static void Refresh()
        {
            webDriver.Navigate().Refresh();
        }
        
        public static void StartNavigate()
        {
            webDriver.Navigate().GoToUrl(Configuration.StartUrl);
        }

        public static void QuiteBrowser()
        {
            webDriver.Quit();
            _currentInstance = null;
            webDriver = null;
            _browser = null;
        }

        public static Actions GetActions() {
            _actions = new Actions(GetDriver());
            return _actions;
        }

        public static IJavaScriptExecutor GetJSExecuter() {
            _jsExecuter = (IJavaScriptExecutor)GetDriver();
            return _jsExecuter;
        }
    }
}
