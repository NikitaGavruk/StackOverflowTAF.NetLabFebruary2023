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
        Logger logger;

        public ForTeamsPage ClickOnVideoButton() {
            logger = new Logger(GetType());
            logger.Info("Successfully went to ForTeams page");
            WebUtils.AcceptAllCookies();
            logger.Info("Cookies accepted");
            forTeamsPage.ClickOnWatchVideoButton();
            logger.Info("Video Field displayed");
            return new ForTeamsPage();
        }

    }

}