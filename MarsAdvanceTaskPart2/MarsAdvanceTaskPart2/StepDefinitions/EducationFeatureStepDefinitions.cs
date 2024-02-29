
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components;
using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Steps;
using MarsAdvanceTaskPart2.Utilities;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    public class EducationFeatureStepDefinitions : GlobalHelper
    {
        private SplashPage loginPage;
        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private JsonReader jsonReader;  
        private EducationComponent educationComponent;
        private EducationSteps educationSteps;
        private ProfileMenuTabComponents profileMenuTabComponents;
      

        public EducationFeatureStepDefinitions() 
        {
            loginPage = new SplashPage();
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            jsonReader = new JsonReader();
            educationComponent = new EducationComponent();
            educationSteps = new EducationSteps();
            profileMenuTabComponents = new ProfileMenuTabComponents();
            
        }

        [Given(@"I navigate to education tab of profile page")]
        public void GivenINavigateToEducationTabOfProfilePage()
        {
            homePageSteps.ClickOnEducationTab();
        }

        [When(@"I reset the existing entries")]
        public void WhenIResetTheExistingEntries()
        {
            educationComponent.ClearExistingEntries();
        }


        [When(@"I add education from file located at ""([^""]*)""")]
        public void WhenIAddEducationFromFileLocatedAt(string path)
        {
            
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
 
                educationComponent.AddEducation(education);
                LogScreenshot("AddEducation");
            }

        }
        

        [Then(@"Education should be added successfully")]
        public void ThenEducationShouldBeAddedSuccessfully()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\AddEducationTestData.json");
            foreach (var education in educationList)
            {

                educationSteps.AddEducationValidation(education);
            }
        }

        [When(@"I update education from file located at ""([^""]*)""")]
        public void WhenIUpdateEducationFromFileLocatedAt(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                educationComponent.UpdateEducation(education);
                LogScreenshot("UpdateEducation");
            
            }
                
        }

        [Then(@"Education should be updated successfully")]
        public void ThenEducationShouldBeUpdatedSuccessfully()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\UpdateEducationTestData.json");
            foreach (var education in educationList)
            {
                educationSteps.UpdateEducationValidation(education);
            }
        }

        [When(@"I delete education from file '([^']*)'")]
        public void WhenIDeleteEducationFromFile(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {

                educationComponent.DeleteEducation(education);
                LogScreenshot("DeleteEducation");
            }
        }
        

        [Then(@"Education should be deleted successfully")]
        public void ThenEducationShouldBeDeletedSuccessfully()
        {
            educationSteps.DeleteEducationAssertions();
        }

        

        [When(@"I add education field empty as in file ""([^""]*)""")]
        public void WhenIAddEducationFieldEmptyAsInFile(string deletepath)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(deletepath);
            foreach (var education in educationList)
            {
                educationComponent.AddEmptyEducationField(education);
                LogScreenshot("AddEmptyEducation");
            }
               
        }

        [Then(@"Error message to enter all fields should be displayed")]
        public void ThenErrorMessageToEnterAllFieldsShouldBeDisplayed()
        {
            educationSteps.AddEmptyEducationAssertions();
        }

        [When(@"I add degree and year that is already adeed as in file ""([^""]*)""")]
        public void WhenIAddDegreeAndYearThatIsAlreadyAdeedAsInFile(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                educationComponent.AddSameDegreeSameYear(education);
                LogScreenshot("AddSameDegreeSameYearEducation");
            }
        }

        [Then(@"error message information already exists should be displayed")]
        public void ThenErrorMessageInformationAlreadyExistsShouldBeDisplayed()
        {
            educationSteps.AddSameDegreeSameYearAssertions();
        }

        [When(@"I add  same degree and different year as in file ""([^""]*)""")]
        public void WhenIAddSameDegreeAndDifferentYearAsInFile(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                educationComponent.AddSameDegreeSameYear(education);
                LogScreenshot("AddSameDegreeDifferentYearEducation");
            }
        }

        [Then(@"error message duplicated data should be displayed")]
        public void ThenErrorMessageDuplicatedDataShouldBeDisplayed()
        {
            educationSteps.AddSameDegreeDifferentYearAssertions();
        }

        [When(@"I click on Update button without making changes")]
        public void WhenIClickOnUpdateButtonWithoutMakingChanges()
        {
            educationComponent.UpdateEducationNoChange();
            LogScreenshot("UpdateEducationWithNoChange");
        }

        [Then(@"Error message that information already exists should be displayed")]
        public void ThenErrorMessageThatInformationAlreadyExistsShouldBeDisplayed()
        {
            educationSteps.UpdateEducationNoChangeAssertions();
        }

      

    }
}
