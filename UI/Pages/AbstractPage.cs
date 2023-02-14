using AutomationTeamProject.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal abstract class AbstractPage
    {
        protected AbstractPage()
        {
        }
        public T NavigateToUrl<T>(string url) where T : AbstractPage
        {
            Browser.GetDriver().Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
