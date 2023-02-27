using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;
using UI.Utils;
using Core.Logger;

namespace UI.Steps {  
    

    internal class ForTeamsSteps {  
        
        ForTeamsPage forTeamsPage = new ForTeamsPage();

        public ForTeamsPage ClickOnVideoButton() {
            WebUtils.AcceptAllCookies();
            forTeamsPage.ClickOnWatchVideoButton();
            return new ForTeamsPage();
        }

    }

}