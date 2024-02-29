using MarsAdvanceTaskPart2.Pages.Components.SignIn;
using MarsAdvanceTaskPart2.Pages.Components;
using MarsAdvanceTaskPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskPart2.Model;
using NUnit.Framework;

namespace MarsAdvanceTaskPart2.Steps
{
    public class LoginSteps : GlobalHelper
    {
        SplashPage loginPage;
        LoginComponent loginComponent;
        HomePage homePage;

        public LoginSteps()
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
            homePage = new HomePage();
        }

        public void doLogin()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\UserInformationTestData.json");
            foreach (var user in userInformationList)
            {
                loginComponent.doSignin(user);
            }
        }

        public void ValidLoginVerification(UserInformationModel user)
        {
            string expectedUsername = homePage.getFirstName();
            string actualUsername = "Hi " + user.FirstName;

            Assert.AreEqual(expectedUsername, actualUsername, "Actual and expected username do not match");
        }

        public void InvalidUsernameValidPasswordVerification()
        {
            string actualErrorMessage = "Please enter a valid email address";
            string expectedErrorMessage = loginComponent.GetInvalidUsernameErrorMessage();
           
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Actual and expected message do not match");
        }

        public void ValidUsernameIncorrectPasswordVerfication()
        {
            string expectedErrorMessage = "Confirm your email";
            string actualErrorMessage = loginComponent.GetIncorrectPasswordErrorMessage();

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The actual and expected message do not match");
        }

        public void ForgotPasswordFunctionalityVerification()
        {
            string expectedMessage = loginComponent.GetEmailVerificationSuccessMessage();
            string actualMessage = "Please check your email to reset your password";

            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
        }

        public void InvalidVerificationIdForgotPasswordVerification()
        {
            string expectedErrorMessage = loginComponent.GetInvalidVerificationIdMessage();
            string actualErrorMessage = "Email is Invalid";

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Actual and expected message do not match");
        }

        public void PasswordCharacterSpecificationVerification()
        {
            string expectedMessage = loginComponent.GetLessPasswordCharacterMessage();
            string actualMessage = "Password must be at least 6 characters";

            Assert.AreEqual(expectedMessage, actualMessage, "Messages do not match");
        }
    }
}
