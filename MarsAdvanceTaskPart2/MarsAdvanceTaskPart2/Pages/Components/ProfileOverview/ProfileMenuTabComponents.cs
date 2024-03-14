using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.ProfileOverview
{
    public class ProfileMenuTabComponents : GlobalHelper
    {
        private IWebElement descriptionEditIcon;
        private IWebElement userNameDropdownIcon;
        private IWebElement availabilityEditIcon;
        private IWebElement hoursEditIcon;
        private IWebElement earnTargetEditIcon;
        private IWebElement educationTab;

        public void RenderComponents()
        {
            try
            {
                userNameDropdownIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
                descriptionEditIcon = driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']"));
                availabilityEditIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                earnTargetEditIcon = driver.FindElement(By.XPath("//i[@class='large dollar icon']//parent::span//following-sibling::div//span//i"));
                descriptionEditIcon = driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']"));
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
         
        public void RenderAvailabilityHoursComponent()
        {

            hoursEditIcon = driver.FindElement(By.XPath("//*[text()='Hours']//parent::span//following-sibling::div//child::i"));
            
        }
        public void RenderEducationTabComponent()
        {
            educationTab = driver.FindElement(By.XPath("//a[@data-tab='third']"));
        }

        public void ClickDescriptionIcon()
        {
            RenderComponents();
            descriptionEditIcon.Click();
            Thread.Sleep(1000);
        }

        public void ClickUserNameIcon()
        {
            RenderComponents();
            userNameDropdownIcon.Click();
        }

        public void ClickAvailabilityEditIcon()
        {   
            RenderComponents();
            availabilityEditIcon.Click();
            
        }

        public void ClickHoursEditIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span//i", 7);
            Thread.Sleep(2000);
            RenderAvailabilityHoursComponent();
          
            hoursEditIcon.Click();
           
        }

        public void ClickEarnTargetEditIcon()
        {
            RenderComponents();
            Thread.Sleep(2000);
            earnTargetEditIcon.Click();
            
        }

        public void ClickEducationTab()
        {
            RenderEducationTabComponent();  
            educationTab.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

    }
}
