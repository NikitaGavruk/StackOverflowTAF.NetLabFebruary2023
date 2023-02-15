using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Steps 
    {
    internal class ForTeamsSteps 
        {
        ForTeamsPage forTeamsPage = new ForTeamsPage();
        public ForTeamsPage ClickOnVideoButton() 
            {
            forTeamsPage.CookiesNessAccept();
            forTeamsPage.ClickOnWatchVideoButton();
            return new ForTeamsPage();
        }
    }
}