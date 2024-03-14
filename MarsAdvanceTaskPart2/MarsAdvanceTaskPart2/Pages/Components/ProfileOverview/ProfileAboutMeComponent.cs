using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.ProfileOverview
{
    public class ProfileAboutMeComponent : GlobalHelper
    {
        private IWebElement usernameDropdownIcon;
        private IWebElement firstNameTextbox;
        private IWebElement lastName;
        private IWebElement saveButton;
        private IWebElement editIcon;

        private IWebElement availabilityDropdown;
        private IWebElement hoursDropdown;
        private IWebElement earnTargetDropdown;
        private IWebElement addedUserName;
        private IWebElement addedAvailability;
        private IWebElement addedHours;
        private IWebElement addedEarnTarget;

        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;

        private IWebElement availabilityEditIcon;

        private IWebElement availabilityCloseIcon;
        private IWebElement hoursCloseIcon;
        private IWebElement earnTargetCloseIcon;
        private IWebElement hoursEditIcon;

        public void RenderComponents()
        {
            try
            {
                usernameDropdownIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderAddComponents()
        {
            try
            {

                firstNameTextbox = driver.FindElement(By.XPath("//input[@name='firstName']"));
                lastName = driver.FindElement(By.Name("lastName"));
                saveButton = driver.FindElement(By.XPath("//*[text()='Last Name']//parent::div//following-sibling::div//button"));

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderAddTestComponent()
        {
            addedUserName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
        }

        public void RenderAvailabilityComponent()
        {

            availabilityDropdown = driver.FindElement(By.Name("availabiltyType"));
            availabilityEditIcon = driver.FindElement(By.XPath("//*[@class='large calendar icon']//parent::span//following-sibling::div//i"));
            availabilityCloseIcon = driver.FindElement(By.XPath("//*[@name='availabiltyType']//following-sibling::i"));

        }
        public void RenderAvailabilityTestComponents()
        {
            try
            {
                addedAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderHourComponent()
        { 
            hoursDropdown = driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            //hoursCloseIcon = driver.FindElement(By.XPath("//*[@name='availabiltyHour']//following-sibling::i"));

        }
        public void RenderAvailabilityHoursComponent()
        {

            hoursEditIcon = driver.FindElement(By.XPath("//*[text()='Hours']//parent::span//following-sibling::div//child::i"));

        }
        public void RenderHourTestComponent()
        {

            addedHours = driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span"));
        }
        public void RenderTargetComponent()
        {
            earnTargetDropdown = driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
            hoursCloseIcon = driver.FindElement(By.XPath("//*[@name='availabiltyTarget']//following-sibling::i"));

        }
        public void RenderTargetTestComponent()
        {

            addedEarnTarget = driver.FindElement(By.XPath("//i[@class='large dollar icon']//parent::span//following-sibling::div//span"));
        }

        public void RenderMessageComponent()
        {
            messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));

        }


        public void AddandUpdateUserName(ProfileAboutMeModel profileAboutMe)
        {

            Wait.WaitToBeClickable(driver, "Name", "firstName", 20);

            RenderComponents();
            //Saving username
            RenderAddComponents();
            firstNameTextbox.SendKeys(Keys.Control + "A");
            firstNameTextbox.SendKeys(Keys.Delete);
            firstNameTextbox.SendKeys(profileAboutMe.FirstName);

            lastName.SendKeys(Keys.Control + "A");
            lastName.SendKeys(Keys.Delete);
            lastName.SendKeys(profileAboutMe.LastName);

            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='title']", 15);
            Thread.Sleep(2000);

        }

        public string GetUserName()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='title']", 15);
            RenderAddTestComponent();

            return addedUserName.Text;
        }

        public void AddandUpdateAvailabilityDetails(ProfileAboutMeModel profileAboutMe)
        {

            RenderAvailabilityComponent();

            availabilityDropdown.SendKeys(profileAboutMe.Availability);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        public string GetAddedAvailability()
        {
            Wait.WaitToExist(driver, "XPath", "//span[normalize-space()='Full Time']", 15);
            RenderAvailabilityTestComponents();
            return addedAvailability.Text;
        }

        public string GetSuccessMessage()
        {
            RenderMessageComponent();
            //Saving error or success message

            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();

            return message;
        }

        public void AddandUpdateAvailabilityHourDetails(ProfileAboutMeModel profileAboutMe)
        {
            RenderAvailabilityHoursComponent();
            hoursEditIcon.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Hours']//parent::span//following-sibling::div//child::i", 20);
            RenderHourComponent();
            
            hoursDropdown.SendKeys(profileAboutMe.Hours);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }
        public string GetAddedHours()
        {
            Wait.WaitToExist(driver, "XPath", "//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span", 15);
            RenderHourTestComponent();
            return addedHours.Text;
        }

        public void AddandUpdateAvailabilityTargetDetails(ProfileAboutMeModel profileAboutMe)
        {
            RenderTargetComponent();
            earnTargetDropdown.SendKeys(profileAboutMe.EarnTarget);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }
        public string GetAddedEarnTarget()
        {
            Wait.WaitToExist(driver, "XPath", "//i[@class='large dollar icon']//parent::span//following-sibling::div//span", 15);
            RenderTargetTestComponent();
            return addedEarnTarget.Text;
        }

        public void ClickAvailabilityOnCancel()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            RenderAvailabilityComponent();
            availabilityEditIcon.Click();
            availabilityCloseIcon.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
    }
}
