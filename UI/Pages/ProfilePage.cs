using AutomationTeamProject.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Audits;
using OpenQA.Selenium.DevTools.V85.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Profile;
using System.Xml.Serialization;
using UI.Utils;

namespace UI.Pages
{

    public class ProfilePage
    {

        private By settingsButtonElement = By.XPath("//a[text()='Settings']");
        private By editProfileButtonElement = By.XPath("//li[contains(text(),' Personal information')]//following-sibling::li/a[contains(text(),'Edit profile')]");
        private By changePictureElement = By.Id("change-picture");
        private By avatarUploadElement = By.Id("avatar-upload");
        private By uploadAvatarWebElement = By.XPath("//a[contains(text(),'link from the web')]");
        private By linkUploadField = By.Name("upload-url");
        private By addPictureElement = By.XPath("//button[contains(text(),'Add picture')]");
        private By generalAvatarPicture = By.XPath("(//div[@id='mainbar-full']//img)[1]");
        private By saveChangesButton = By.XPath("//button[contains(text(),' Save and copy changes to all public communities')]");
        private By defaultAvatarElement = By.XPath("//span[contains(text(),'Identicon')]");
        private By curentAvatarElement = By.XPath("//div[@class='gravatar-wrapper-164']/img");
        private string avatarUrl = "https://i.pravatar.cc/150?img={0}";
        private string beforeAttribute;
        private string afterAttribute;
        private string helpLoadingWaitBefore;
        private string helperLoadingWaitAfter;

        public void GoToProfileSettings()
        {
            beforeAttribute = WebDriverExtension.GetAttributeValueFromField(generalAvatarPicture, 5, "src");
            WebDriverExtension.ClickOnButton(settingsButtonElement);
        }

        public void GoToEditProfileSettings()
        {
            WebDriverExtension.ClickOnButton(editProfileButtonElement);
        }

        public void ClickOnChangePictureButton()
        {
            helpLoadingWaitBefore = WebDriverExtension.GetAttributeValueFromField(curentAvatarElement, 5, "src");
            WebDriverExtension.ClickOnButton(changePictureElement);
        }

        public void ClickOnSaveButton()
        {
            this.LoadingImage();
            WebDriverExtension.MouseDown(saveChangesButton, 5);
        }

        public void ClickOnDefaultAvatar()
        {
            WebDriverExtension.MouseDown(defaultAvatarElement, 5);
        }

        public void OpenUploadBox()
        {
            WebDriverExtension.MouseDown(avatarUploadElement, 5);
        }

        public void UploadAvatarInWeb()
        {
            WebDriverExtension.ClickOnButton(uploadAvatarWebElement);
        }

        public void InputAvatarUrl()
        {
            Random rng = new Random();
            int n = rng.Next(1, 70);
            WebDriverExtension.InputTextInField(linkUploadField, 15, string.Format(avatarUrl, n));
            WebDriverExtension.ClickOnButton(addPictureElement);
        }

        public bool IsAvatarSuccessfullyChange()
        {
            Browser.Refresh();
            afterAttribute = WebDriverExtension.GetAttributeValueFromField(generalAvatarPicture, 15, "src");
            return beforeAttribute != afterAttribute;
        }

        public void ReturneDefaultAvatar()
        {
            this.GoToProfileSettings();
            this.GoToEditProfileSettings();
            this.ClickOnChangePictureButton();
            this.ClickOnDefaultAvatar();
            this.ClickOnSaveButton();
        }

        private void LoadingImage()
        {
            helperLoadingWaitAfter = WebDriverExtension.GetAttributeValueFromField(curentAvatarElement, 5, "src");
            while (helpLoadingWaitBefore == helperLoadingWaitAfter)
            {
                Browser.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                helperLoadingWaitAfter = WebDriverExtension.GetAttributeValueFromField(curentAvatarElement, 5, "src");
            }
        }

    }

}
