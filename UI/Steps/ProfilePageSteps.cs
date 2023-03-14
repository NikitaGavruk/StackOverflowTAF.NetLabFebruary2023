using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Steps
{

    public class ProfilePageSteps
    {

        public void ReturnDefaultAvatar(ProfilePage profilePage)
        {
            profilePage.GoToProfileSettings().ClickEditProfileSettings();
            profilePage.ClickOnChangePictureButton();
            profilePage.ClickOnDefaultAvatar();
            profilePage.ClickOnSaveButton();
        }

    }

}
