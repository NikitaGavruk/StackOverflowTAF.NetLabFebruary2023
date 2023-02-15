using System;
using AutomationTeamProject.WebDriver;

namespace UI
{
    internal abstract class AbstractPage
    {

        public T NavigateToUrl<T>(string url) where T : AbstractPage {
            Browser.GetDriver().Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T));

        }

    }
}
