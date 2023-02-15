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

        // pars the parameter that ar taken from App.config
        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out _currentBrowser);
        }

        private Browser()
        {
            InitParams();
            webDriver = WebDriverFactory.GetDriver(_currentBrowser, ImplWait);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());
        
        //Get the Driver
        public static IWebDriver GetDriver()
        {
            return webDriver;
        }
        
        //Windows maximaizer
        public static void WindowMaximaze()
        {
            webDriver.Manage().Window.Maximize();
        }

        //Navigator
        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }  
        
        //Navigator
        public static void StartNavigate()
        {
            webDriver.Navigate().GoToUrl(Configuration.StartUrl);
        }

        //Quit the browser
        public static void QuiteBrowser()
        {
            webDriver.Quit();
            _currentInstance = null;
            webDriver = null;
            _browser = null;
        }

        //get Actions
        public static Actions GetActions() {
            _actions = new Actions(GetDriver());
            return _actions;
        }

        //Get JS Executer
        public static IJavaScriptExecutor GetJSExecuter() {
            _jsExecuter = (IJavaScriptExecutor)GetDriver();
            return _jsExecuter;
        }
    }
}
