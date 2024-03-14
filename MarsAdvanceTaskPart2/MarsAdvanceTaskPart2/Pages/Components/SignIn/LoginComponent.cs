using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.SignIn
{
    public class LoginComponent : GlobalHelper
    {
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;

        private IWebElement invalidUsernameErrorMessage;
        private IWebElement invalidPasswordErrorMessage;
        private IWebElement closeMessageIcon;

        private IWebElement emailVerificationId;
        private IWebElement sendVerificationButton;
        private IWebElement emailVerificationSendMessage;

        private IWebElement emailVerificationSuccessMessage;
        private IWebElement emailVerificationMessageBox;
        private IWebElement invalidVerificationIdMessage;

        private IWebElement forgotPasswordLink;
        private IWebElement passwordCharacterMessage;

        private IWebElement signOutButton;



        public void RenderComponents()
        {
            try
            {
                emailTextbox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passwordTextbox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderInvalidUsernameComponent()
        {
            invalidUsernameErrorMessage = driver.FindElement(By.XPath("//div[@class='ui basic red pointing prompt label transition visible']"));
        }

        public void RenderIncorrectPasswordMessageComponent()
        {
            invalidPasswordErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void RenderEmailVerificationComponents()
        {
            emailVerificationId = driver.FindElement(By.Name("email"));
            sendVerificationButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/div[2]/div"));
        }

        public void RenderForgotPasswordComponents()
        {
            forgotPasswordLink = driver.FindElement(By.XPath("//a[@class='pointerCursor' and text()='Forgot your password?']"));
        }

        public void RenderEmailVerificationSuccessMessageComponent()
        {
            emailVerificationSuccessMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        }

        public void RenderEmailVerificationMessageBox()
        {
            emailVerificationMessageBox = driver.FindElement(By.XPath("//div[text()='A recovery link has been sent to your inbox. ']"));
        }
        public void RenderInvalidVerificationIdErrorMessageComponent()
        {
            invalidVerificationIdMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']//div"));
        }
        public void RenderLessPasswordCharacterMessageComponent()
        {
            passwordCharacterMessage = driver.FindElement(By.XPath("//div[@class='ui basic red pointing prompt label transition visible']"));
        }
        public void RenderSignOutComponent()
        {
            signOutButton = driver.FindElement(By.XPath("//button[@class='ui green basic button']"));
        }

        public void LoginEntries(UserInformationModel userinformation)
        {
            RenderComponents();
            //Enter valid Username and Password

            emailTextbox.SendKeys(userinformation.Email);
            passwordTextbox.SendKeys(userinformation.Password);

        }

        public void doSignin(UserInformationModel userinformation)
        {
            RenderComponents();
            emailTextbox.SendKeys(userinformation.Email);
            passwordTextbox.SendKeys(userinformation.Password);
            loginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]", 7);
        }

        public void InvalidUsernameValidPassword(UserInformationModel userinformation)
        {
            RenderComponents();
            LoginEntries(userinformation);
            loginButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]", 7);

        }

        public string GetInvalidUsernameErrorMessage()
        {

            RenderInvalidUsernameComponent();
            return invalidUsernameErrorMessage.Text;
        }

        public void ValidUsernameIncorrectPassword(UserInformationModel userinformation)
        {
            RenderComponents();
            emailTextbox.SendKeys(userinformation.Email);
            passwordTextbox.SendKeys(userinformation.Password);
            loginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]", 7);
        }
        public string GetIncorrectPasswordErrorMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            RenderIncorrectPasswordMessageComponent();

            //Saving error or success message
            String message = invalidPasswordErrorMessage.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();

            return message;
        }

        public void GetEmailVerification(UserInformationModel userinformation)
        {
            RenderEmailVerificationComponents();

            emailVerificationId.SendKeys(userinformation.VerificationEmail);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            sendVerificationButton.Click();

        }

        public void ForgotPasswordFunctionality(UserInformationModel userinformation)
        {
            RenderComponents();
            LoginEntries(userinformation);

            RenderForgotPasswordComponents();
            forgotPasswordLink.Click();

            GetEmailVerification(userinformation);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        public string GetEmailVerificationSuccessMessage()
        {

            RenderEmailVerificationSuccessMessageComponent();
            Thread.Sleep(1000);
            string message = emailVerificationSuccessMessage.Text;

            return message;

        }
        public string GetEmailVerificationConfirmationBox()
        {
            RenderEmailVerificationMessageBox();
            Thread.Sleep(1000);
            string messageBox = emailVerificationMessageBox.Text;
            return messageBox;
        }

        public void InvalidVerificationEmailIdInForgotPassword(UserInformationModel userinformation)
        {
            ForgotPasswordFunctionality(userinformation);

        }

        public string GetInvalidVerificationIdMessage()
        {
            RenderInvalidVerificationIdErrorMessageComponent();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string errorMessage = invalidVerificationIdMessage.Text;
            return errorMessage;
        }

        public string GetLessPasswordCharacterMessage()
        {
            RenderLessPasswordCharacterMessageComponent();
            string message = passwordCharacterMessage.Text;
            return message;
        }
    }
}
