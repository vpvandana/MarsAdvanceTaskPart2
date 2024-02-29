using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.NavigationMenu
{
    public class ManageListingOverviewComponent : GlobalHelper
    {
        private IWebElement updateSkillIcon;
        private IWebElement deleteSkillIcon;
        private IWebElement viewSkillIcon;

        public void RenderComponents()
        {

            viewSkillIcon = driver.FindElement(By.XPath("//i[@class='eye icon']"));
            updateSkillIcon = driver.FindElement(By.XPath("//i[@class='outline write icon']"));
            deleteSkillIcon = driver.FindElement(By.XPath("//i[@class='remove icon']"));
        }

        public void ClickUpdateSkillIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='outline write icon']", 10);
            RenderComponents();
            updateSkillIcon.Click();

        }

        public void ClickDeleteSkillIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='remove icon']", 10);
            RenderComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            deleteSkillIcon.Click();
        }

        public void ClickViewSkillIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='eye icon']", 10);
            RenderComponents();
            viewSkillIcon.Click();
        }
    }
}

