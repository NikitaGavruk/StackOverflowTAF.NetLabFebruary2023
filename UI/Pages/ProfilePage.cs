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
        private By pictureInEditProfile = By.XPath("//div[@class='gravatar-wrapper-164']/img");
        private string avatarUrl = "https://i.pravatar.cc/150?img={0}";
        private string beforeUploadSrcAttribute;
        private string afterUploadSrcAttribute;

        public ProfilePage GoToProfileSettings()
        {
            WebDriverExtension.MouseDown(settingsButtonElement,5);
            return new ProfilePage();
        }

        public ProfilePage ClickEditProfileSettings()
        {
            WebDriverExtension.MouseDown(editProfileButtonElement,5);
            return new ProfilePage();
        }

        public void ClickOnChangePictureButton()
        {
            beforeUploadSrcAttribute = WebDriverExtension.GetAttributeValueFromField(pictureInEditProfile, 5, "src");
            WebDriverExtension.ClickOnButton(changePictureElement);
        }

        public void ClickOnSaveButton()
        {
            WebDriverExtension.WaitUntilPictureIsSuccesfullyLoaded(beforeUploadSrcAttribute, pictureInEditProfile);
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

        public void UploadAvatar()
        {
            WebDriverExtension.ClickOnButton(uploadAvatarWebElement);
        }

        public void InputAvatarUrl()
        {
            Random rng = new Random();
            int n = rng.Next(1, 70);
            WebDriverExtension.InputTextInField(linkUploadField, 5, string.Format(avatarUrl, n));
            WebDriverExtension.ClickOnButton(addPictureElement);
        }

        public bool IsAvatarSuccessfullyChange()
        {
            WebDriverExtension.WaitUntilPictureIsSuccesfullyLoaded(beforeUploadSrcAttribute, generalAvatarPicture);
            afterUploadSrcAttribute = WebDriverExtension.GetAttributeValueFromField(generalAvatarPicture, 5, "src");
            return beforeUploadSrcAttribute != afterUploadSrcAttribute;
        }

    }

}
