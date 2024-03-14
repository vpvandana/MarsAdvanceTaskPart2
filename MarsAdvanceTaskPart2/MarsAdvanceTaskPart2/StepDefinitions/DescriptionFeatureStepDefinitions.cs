
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components;
using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Pages.Components.SignIn;
using MarsAdvanceTaskPart2.Steps;
using MarsAdvanceTaskPart2.Utilities;
using NUnit.Framework;
using System.IO;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    public class DescriptionFeatureStepDefinitions : GlobalHelper
    {
        SplashPage loginPage;
        LoginComponent loginComponent;
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        ProfileDescriptionComponent profileDescriptionComponent;
        DescriptionSteps descriptionSteps;
       
        public DescriptionFeatureStepDefinitions()
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            profileDescriptionComponent = new ProfileDescriptionComponent();
            descriptionSteps = new DescriptionSteps();
           
        }

        [Given(@"Login to mars and user is on the profile page of mars")]
        public void GivenLoginToMarsAndUserIsOnTheProfilePageOfMars()
        {
            loginPage.clickSignInButton();
            loginSteps.doLogin();        
        }


        [Given(@"I click on description edit icon in profile page")]
        public void GivenIClickOnDescriptionEditIconInProfilePage()
        {
            homePageSteps.ClickOnDescriptionIcon();
        }



        [When(@"Add description about me located at ""([^""]*)""")]
        public void WhenAddDescriptionAboutMeLocatedAt(string path)
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>(path);
            foreach (var profiledescription in profileDescriptionList)
            {
                profileDescriptionComponent.AddDescription(profiledescription);
                LogScreenshot("AddDescription");
            }
        }

        [Then(@"Description should be added successfully")]
        public void ThenDescriptionShouldBeAddedSuccessfully()
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\DescriptionTestData.json");
            foreach (var profiledescription in profileDescriptionList)
            {
                descriptionSteps.AddDescriptionVerification(profiledescription);
            }

        }

        [When(@"I delete the added description located at ""([^""]*)""")]
        public void WhenIDeleteTheAddedDescriptionLocatedAt(string path)
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>(path);
            
            foreach (var profiledescription in profileDescriptionList)
            { 
                profileDescriptionComponent.DeleteDescription(profiledescription);
                LogScreenshot("Delete Description");
            }
        }

       
        [Then(@"Description has been deleted successfully")]
        public void ThenDescriptionHasBeenDeletedSuccessfully()
        {
            descriptionSteps.DeleteDescriptionVerification();
        }

        [When(@"I Add description as numeric or special characters located at ""([^""]*)""")]
        public void WhenIAddDescriptionAsNumericOrSpecialCharactersLocatedAt(string path)
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>(path);
            foreach (var profiledescription in profileDescriptionList)
            {

                profileDescriptionComponent.FirstCharacterSpace(profiledescription);
                LogScreenshot("SpecialCharacterDescription");
            }
        }

        [When(@"I add description with first character as space located at ""([^""]*)""")]
        public void WhenIAddDescriptionWithFirstCharacterAsSpaceLocatedAt(string path)
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>(path);
            foreach (var profiledescription in profileDescriptionList)
            {

                profileDescriptionComponent.FirstCharacterSpace(profiledescription);
                LogScreenshot("FirstCharacterSpaceDescription");

            }
        }

        [Then(@"Error message should be displayed correctly")]
        public void ThenErrorMessageShouldBeDisplayedCorrectly()
        {
           descriptionSteps.FirstCharacterSpaceDescriptionVerification();
        }

    }
}
