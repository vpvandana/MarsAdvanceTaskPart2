
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.NavigationMenu;
using MarsAdvanceTaskPart2.Steps;
using MarsAdvanceTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    public class ManageListingFeatureStepDefinitions : GlobalHelper
    {
        ManageListingSteps manageListingSteps;
        ManageListingOverviewComponent manageListingOverviewComponent;
        NavigationMenuTabComponents navigationMenuTabComponents;
        HomePageSteps homePageSteps;
        ManageListingComponent manageListingComponent;
        ShareSkillAddComponent shareSkillAddComponent;
        JsonReader jsonReader;

        public ManageListingFeatureStepDefinitions() 
        {
            manageListingSteps = new ManageListingSteps();
            manageListingOverviewComponent = new ManageListingOverviewComponent();
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            manageListingComponent = new ManageListingComponent();
            shareSkillAddComponent = new ShareSkillAddComponent();
            homePageSteps = new HomePageSteps();
            jsonReader = new JsonReader();
        }
        [Given(@"I click on manage listing tab in profile page")]
        public void GivenIClickOnManageListingTabInProfilePage()
        {
            homePageSteps.ClickOnManageListingTab();
        }


        [When(@"I update '([^']*)' the service I added")]
        public void WhenIUpdateTheServiceIAdded(string path)
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var item in manageListingList)
            {
                
                manageListingOverviewComponent.ClickUpdateSkillIcon();
                manageListingComponent.UpdateListedSkill(item);
                LogScreenshot("UpdateSkills");

            }
        }

      
        [Then(@"Service should be updated successfully")]
        public void ThenServiceShouldBeUpdatedSuccessfully()
        {
            manageListingSteps.UpdateListedSkillVerification();
        }

        [When(@"I delete '([^']*)' the service I added")]
        public void WhenIDeleteTheServiceIAdded(string path)
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var item in manageListingList)
            {
                manageListingComponent.DeleteListedSkill(item);
                LogScreenshot("DeleteSkills");
            }
               
        }
        [Then(@"Service should be successfully deleted")]
        public void ThenServiceShouldBeSuccessfullyDeleted()
        {
            manageListingSteps.DeleteListedSkillVerification();
        }

        [When(@"I view '([^']*)' the service I added")]
        public void WhenIViewTheServiceIAdded(string path)
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var item in manageListingList)
            {
                manageListingComponent.ViewListedSkill(item);
                LogScreenshot("ViewSkills");
            }
        }
        [Then(@"I should be able to view the service")]
        public void ThenIShouldBeAbleToViewTheService()
        {
            manageListingSteps.ViewListedSkillVerification();
        }
        [When(@"I search for a the added skill using pagination '([^']*)'")]
        public void WhenISearchForATheAddedSkillUsingPagination(string path)
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var item in manageListingList)
            {
                manageListingComponent.GetTitleByPagination(item);
                LogScreenshot("SkillPagination");
            }
        }

        [Then(@"I should be able to find the skill")]
        public void ThenIShouldBeAbleToFindTheSkill()
        {
            manageListingSteps.SkillPaginationAssertion();
        }

        [When(@"I click on toggle button in service listing from '([^']*)'")]
        public void WhenIClickOnToggleButtonInServiceListingFrom(string path)
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var item in manageListingList)
            {
                manageListingComponent.ActivateDeactivateSkills(item);
                LogScreenshot("ToggleButtonSkills");
            }
        }

        

        [Then(@"Service should be activated or deactivated successfully")]
        public void ThenServiceShouldBeActivatedOrDeactivatedSuccessfully()
        {
            manageListingSteps.ActivateDeactivateVerification();
        }


    }
}
