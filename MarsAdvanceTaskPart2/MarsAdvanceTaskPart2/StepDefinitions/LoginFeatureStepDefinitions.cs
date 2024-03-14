using MarsAdvanceTaskPart2.Pages.Components.SignIn;
using MarsAdvanceTaskPart2.Pages.Components;
using MarsAdvanceTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;
using MarsAdvanceTaskPart2.Model;
using NUnit.Framework;
using MarsAdvanceTaskPart2.Steps;


namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : GlobalHelper
    {
        SplashPage loginPage;
        LoginComponent loginComponent;
        LoginSteps loginSteps;
        //LoginAssertions loginAssertions;
        HomePage homePage;
        HomePageSteps homePageSteps;
        JsonReader jsonReader;
        public LoginFeatureStepDefinitions() 
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
            loginSteps = new LoginSteps();
          //  loginAssertions = new LoginAssertions();
            homePage = new HomePage();
            homePageSteps = new HomePageSteps();
            jsonReader = new JsonReader();
        }

        [Given(@"Login to Mars and user is on profile page of mars")]
        public void GivenLoginToMarsAndUserIsOnProfilePageOfMars()
        {
            loginPage.clickSignInButton();
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
        }

       

        [When(@"I enters valid credentials using json file located at ""([^""]*)""")]
        public void WhenIEntersValidCredentialsUsingJsonFileLocatedAt(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                LogScreenshot("ValidLogin");
                loginComponent.doSignin(user);
                

            }
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\UserInformationTestData.json");
            foreach (var user in userInformationList)
            {
               loginSteps.ValidLoginVerification(user);
            }
        }
        [When(@"I enter invalid username and valid password as '([^']*)'")]
        public void WhenIEnterInvalidUsernameAndValidPasswordAs(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.InvalidUsernameValidPassword(user);
                LogScreenshot("Invalid Username Valid PasswordLogin");

            }
        }

        [Then(@"Error message to enter a valid username should be dispalyed")]
        public void ThenErrorMessageToEnterAValidUsernameShouldBeDispalyed()
        {
            loginSteps.InvalidUsernameValidPasswordVerification();
        }

        [When(@"I enter valid username but incorrect password '([^']*)'")]
        public void WhenIEnterValidUsernameButIncorrectPassword(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.ValidUsernameIncorrectPassword(user);
                LogScreenshot("Valid Username Invalid PasswordLogin");

            }
        }
        [Then(@"Error message to confirm email or password should be dispalyed")]
        public void ThenErrorMessageToConfirmEmailOrPasswordShouldBeDispalyed()
        {
            loginSteps.ValidUsernameIncorrectPasswordVerfication();
        }
        [When(@"I click on forgot password link and I enter email in send email verification '([^']*)'")]
        public void WhenIClickOnForgotPasswordLinkAndIEnterEmailInSendEmailVerification(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.ForgotPasswordFunctionality(user);
                LogScreenshot("ForgotPasswordLogin");

            }
        }
        [Then(@"Email verification sent message to change password should be dispalyed")]
        public void ThenEmailVerificationSentMessageToChangePasswordShouldBeDispalyed()
        {
            loginSteps.ForgotPasswordFunctionalityVerification();
        }
        [When(@"I click on forgot password link and I enter invalid email id for email verification '([^']*)'")]
        public void WhenIClickOnForgotPasswordLinkAndIEnterInvalidEmailIdForEmailVerification(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.InvalidVerificationEmailIdInForgotPassword(user);
                LogScreenshot("InvalidVerificationEmailIdInForgotPasswordLogin");
            }
        }
        [Then(@"Error message email is inavalid should be displayed")]
        public void ThenErrorMessageEmailIsInavalidShouldBeDisplayed()
        {
            loginSteps.InvalidVerificationIdForgotPasswordVerification();
        }
        
        [When(@"I enter a password less than six characters '([^']*)'")]
        public void WhenIEnterAPasswordLessThanSixCharacters(string path)
        {
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.LoginEntries(user);
                LogScreenshot("PasswordCharacterSpecification");
            }
        }

        [Then(@"Error message to add more than six characters should be dispalyed")]
        public void ThenErrorMessageToAddMoreThanSixCharactersShouldBeDispalyed()
        {
            loginSteps.PasswordCharacterSpecificationVerification();
        }

    }
}
