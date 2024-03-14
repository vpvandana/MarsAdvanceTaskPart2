using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.ProfileOverview
{
    public class ProfileDescriptionComponent : GlobalHelper
    {
        private IWebElement descriptionTextArea;
        private IWebElement saveButton;
        private IWebElement messageBox;
        private IWebElement closeMessageIcon;
        private IWebElement addedDescription;
        private IWebElement deleteMessage;
        private IWebElement spaceErrorMessageBox;

        public void RenderComponents()
        {
            try
            {
                descriptionTextArea = driver.FindElement(By.XPath("//textarea[@name='value']"));
                saveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void RenderTestComponent()
        {
            addedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        }

        public void RenderDeleteMessageComponent()
        {
            deleteMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
        }

        public void RenderSpaceErrorMessageComponent()
        {
            spaceErrorMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void AddDescription(DescriptionModel description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);

            RenderComponents();
            descriptionTextArea.Click();
            descriptionTextArea.Clear();

            descriptionTextArea.SendKeys(description.DescriptionText);

            saveButton.Click();
            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 9);
        }

        public string GetAddedDescription()
        {
           // Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 25);

            RenderTestComponent();
            return addedDescription.Text;


        }
        public string GetAddedSuccessMessage()
        {
            //Saving error or success message
            RenderMessageComponent();
            String message = messageBox.Text;

            //If any message visible close it
           // Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
         //   closeMessageIcon.Click();

            return message;
        }

        public void DeleteDescription(DescriptionModel description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);

            RenderComponents();

            descriptionTextArea.Click();

            descriptionTextArea.SendKeys(description.DescriptionText);

            descriptionTextArea.SendKeys(Keys.Control + "A");
            descriptionTextArea.SendKeys(Keys.Delete);

            saveButton.Click();

            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 15);
        }

        public string GetDeletedMessage()
        {
            //Saving error or success message
            RenderDeleteMessageComponent();
            String message = deleteMessage.Text;

            return message;
        }

        public void FirstCharacterSpace(DescriptionModel description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);

            RenderComponents();

            descriptionTextArea.Click();

            descriptionTextArea.SendKeys(Keys.Control + "A");
            descriptionTextArea.SendKeys(Keys.Delete);

            descriptionTextArea.SendKeys(description.DescriptionText);

            saveButton.Click();

            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 15);

        }

        public string GetFirstCharacterSpaceErrorMessage()
        {
            //Saving error or success message
            RenderSpaceErrorMessageComponent();
            String message = spaceErrorMessageBox.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();

            return message;
        }
    }
}
