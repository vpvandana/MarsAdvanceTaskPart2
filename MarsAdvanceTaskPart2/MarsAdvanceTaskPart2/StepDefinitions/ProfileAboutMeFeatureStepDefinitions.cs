
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Steps;
using MarsAdvanceTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    
    public class ProfileAboutMeFeatureStepDefinitions : GlobalHelper
    {
        private HomePageSteps homePageSteps;
        private ProfileAboutMeComponent profileAboutMeComponent;
        private ProfileAboutMeSteps profileAboutMeSteps;
      
        public ProfileAboutMeFeatureStepDefinitions() 
        {
            homePageSteps = new HomePageSteps();
            profileAboutMeComponent = new ProfileAboutMeComponent();
            profileAboutMeSteps = new ProfileAboutMeSteps();
           
        }

        [Given(@"I click on username dropdown icon")]
        public void GivenIClickOnUsernameDropdownIcon()
        {
            homePageSteps.ClickOnProfileIcon();
        }

        [When(@"I add firstname and lsatname in aboutme section from file ""([^""]*)""")]
        public void WhenIAddFirstnameAndLsatnameInAboutmeSectionFromFile(string path)
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>(path);
            foreach(var profile in profileAboutMeList )
            {
                profileAboutMeComponent.AddandUpdateUserName(profile);
                LogScreenshot("AddandUpdateUsername");
            }
            
        }

        [Then(@"Username should be updated successfully")]
        public void ThenUsernameShouldBeUpdatedSuccessfully()
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ProfileAboutMeTestData.json");
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeSteps.AddandUpdateUsernameAssertions(profile);
            }
                
        }
        [Given(@"I click on availability edit icon")]
        public void GivenIClickOnAvailabilityEditIcon()
        {
            homePageSteps.ClickOnAvailabilityEditIcon();
        }


        [When(@"I choose availability from dropdown using file located at ""([^""]*)""")]
        public void WhenIChooseAvailabilityFromDropdownUsingFileLocatedAt(string path)
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>(path);
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeComponent.AddandUpdateAvailabilityDetails(profile);
                LogScreenshot("AddandUpdateAvailability");
            }
        }
        [Then(@"availability should be updated successfully")]
        public void ThenAvailabilityShouldBeUpdatedSuccessfully()
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ProfileAvailabilityTestData.json");

            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeSteps.UpdateAvailabilityAssertions(profile);
            }
                
        }
        [Given(@"I click on hours edit icon")]
        public void GivenIClickOnHoursEditIcon()
        {
            homePageSteps.ClickOnHoursEditIcon();
        }


        [When(@"I choose the hours that I am available from file ""([^""]*)""")]
        public void WhenIChooseTheHoursThatIAmAvailableFromFile(string path)
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>(path);
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeComponent.AddandUpdateAvailabilityHourDetails(profile);
                LogScreenshot("AddandUpdateHoursAvailable");
            }
        }

        [Then(@"Hours should be updated successfully")]
        public void ThenHoursShouldBeUpdatedSuccessfully()
        {
            
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\AvailabilityHoursTestData.json");
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeSteps.UpdateProfileAvailabilityHours(profile);
            }
        }

        [Given(@"I click on earn target edit icon")]
        public void GivenIClickOnEarnTargetEditIcon()
        {
            homePageSteps.ClickOnEarnTargetEditIcon();
        }

        [When(@"I choose the target amount from file ""([^""]*)""")]
        public void WhenIChooseTheTargetAmountFromFile(string path)
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>(path);
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeComponent.AddandUpdateAvailabilityTargetDetails(profile);
                LogScreenshot("AddandUpdateEarnTarget");
            }
        }

        [Then(@"Earn target should be updated successfully")]
        public void ThenEarnTargetShouldBeUpdatedSuccessfully()
        {
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\EarnTargetTestData.json");
            foreach (var profile in profileAboutMeList)
            {
                profileAboutMeSteps.UpdateProfileAvailabilityEarnTarget(profile);
            }
        }

    }
}
