using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components
{
    public class SplashPage : GlobalHelper

    {
        private IWebElement signInButton;


        public void RenderComponents()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//a[@class='item']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickSignInButton()
        {

            //Click on "Sign In" button
               
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Sign In']", 10);
            RenderComponents();
            signInButton.Click();

        }
    }
}
