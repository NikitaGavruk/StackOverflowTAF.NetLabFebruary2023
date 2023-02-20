using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class CareersPage : AbstractPage
    {

        public static readonly By WhoWeAreElement = By.XPath("//h2[contains(text(), \"Who we are\")]");

        public bool WhoWeAreIsVisiblse()
        {
           return WebDriverExtension.IsElementVisible(WhoWeAreElement,5);
        }

    }

}
