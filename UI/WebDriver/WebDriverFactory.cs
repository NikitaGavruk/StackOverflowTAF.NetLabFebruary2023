using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace StackOverFlow.WebDrvier
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserType browser)
        {
            IWebDriver webDriver = null;
            switch (browser)
            {
                case BrowserType.Chrome:
                    {
                        ChromeOptions option = new ChromeOptions();
                        webDriver = new ChromeDriver(option);
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        FirefoxOptions option = new FirefoxOptions();
                        webDriver = new FirefoxDriver(option);
                        break;
                    }
                case BrowserType.Edge: 
                    {
                        EdgeOptions option = new EdgeOptions();
                        webDriver = new EdgeDriver(option);
                        break;
                    }

            }
            return webDriver;
        }
    }
}