using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components
{
    public class HomePage : GlobalHelper
    {
        private IWebElement userNameLabel;
        private ProfileMenuTabComponents profileMenuTabComponents;

        public HomePage()
        {
            profileMenuTabComponents = new ProfileMenuTabComponents();
        }

        public void RenderComponents()
        {
            try
            {
                userNameLabel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public String getFirstName()
        {
            //Return username
            try
            {
                RenderComponents();
                return userNameLabel.Text;

            }
            catch (Exception ex)
            {
                driver.Navigate().Refresh();
                return ex.Message;
            }
        }
    }
}

