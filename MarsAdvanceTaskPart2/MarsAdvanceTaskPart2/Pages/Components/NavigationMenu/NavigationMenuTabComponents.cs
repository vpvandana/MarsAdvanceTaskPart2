using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.NavigationMenu
{
    public class NavigationMenuTabComponents : GlobalHelper
    {
        private IWebElement shareSkillTab;
        private IWebElement manageListingTab;

        public void RenderComponents()
        {
            try
            {
                shareSkillTab = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
                manageListingTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ClickShareSkillTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Share Skill']", 7);

            RenderComponents();
            shareSkillTab.Click();

            Thread.Sleep(1000);
        }

        public void ClickManageListingTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Manage Listings']", 7);

            RenderComponents();
            manageListingTab.Click();

            Thread.Sleep(1000);
        }

    }
}
