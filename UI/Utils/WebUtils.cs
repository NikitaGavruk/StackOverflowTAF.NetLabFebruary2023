using OpenQA.Selenium;

namespace UI.Utils {

    internal static class WebUtils {

        public static By FormatXpath(string xpath, string argument) {
            return By.XPath(string.Format(xpath, argument));
        }

    }

}
