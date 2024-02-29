
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.NavigationMenu;
using MarsAdvanceTaskPart2.Steps;
using MarsAdvanceTaskPart2.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.StepDefinitions
{
    [Binding]
    public class ShareSkillAddFeatureStepDefinitions : GlobalHelper
    {
        HomePageSteps homePageSteps;
        ShareSkillAddComponent addShareSkillComponent;
        ShareSkillAddSteps shareSkillAddSteps;
        
        JsonReader jsonReader;

        public ShareSkillAddFeatureStepDefinitions()
        {
           
            homePageSteps = new HomePageSteps();
            addShareSkillComponent = new ShareSkillAddComponent();
            shareSkillAddSteps = new ShareSkillAddSteps();
           
            jsonReader = new JsonReader();
        }

        [Given(@"I click on ShareSkill button in the profile page")]
        public void GivenIClickOnShareSkillButtonInTheProfilePage()
        {
            homePageSteps.ClickOnShareSkill();
            
        }


        [When(@"I add service to list from data located at ""([^""]*)""")]
        public void WhenIAddServiceToListFromDataLocatedAt(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.AddShareSkills(shareSkillAdd);
                LogScreenshot("AddShareskill");

            }
        }

        [Then(@"Service should be added successfully")]
        public void ThenServiceShouldBeAddedSuccessfully()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ShareSkillAddTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                shareSkillAddSteps.AddShareSkillStepsVerification(shareSkillAdd);
            }
                
        }

        [When(@"I left mandatory fields in the form empty ""([^""]*)""")]
        public void WhenILeftMandatoryFieldsInTheFormEmpty(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.MandatoryFieldsLeftEmpty(shareSkillAdd);
                LogScreenshot("MandatoryFieldsLeftEmpty");
            }
        }

        [Then(@"Error message to fill the form should be displayed correctly")]
        public void ThenErrorMessageToFillTheFormShouldBeDisplayedCorrectly()
        {
            shareSkillAddSteps.MandatoryFieldsEmptyStepVerification();
        }

        [When(@"I add special characters in title field '([^']*)'")]
        public void WhenIAddSpecialCharactersInTitleField(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.AddSpecialCharacterOnTitleShareSkill(shareSkillAdd);
                LogScreenshot("AddSpecialCharacterTitle");
              
            }
        }

        [Then(@"Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            shareSkillAddSteps.SpecialCharacterOnShareSkillTitleVerification();
        }

        [When(@"I add space as first character in title field '([^']*)'")]
        public void WhenIAddSpaceAsFirstCharacterInTitleField(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.FirstCharacterSpaceForTitle(shareSkillAdd);
                LogScreenshot("FirstCharacterSpaceTitle");
            }
        }

        [Then(@"Error message that indicates space as first character not allowed should be displayed")]
        public void ThenErrorMessageThatIndicatesSpaceAsFirstCharacterNotAllowedShouldBeDisplayed()
        {
            shareSkillAddSteps.FirstCharacterSpaceOnTitleVerification();
        }

        [When(@"I add first character as space in description field '([^']*)'")]
        public void WhenIAddFirstCharacterAsSpaceInDescriptionField(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.FirstCharacterSpaceForDescription(shareSkillAdd);
                LogScreenshot("FirstCharacterSpaceDescription");
            }
               
        }

        [Then(@"Space not allowed as first character should be displayed")]
        public void ThenSpaceNotAllowedAsFirstCharacterShouldBeDisplayed()
        {
            shareSkillAddSteps.FirstCharacterSpaceOnDescriptionVerification();
        }

        [When(@"I did not choose sub catagory from dropdown and tags '([^']*)'")]
        public void WhenIDidNotChooseSubCatagoryFromDropdownAndTags(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.SubCatagoryAndTagsNotSelected(shareSkillAdd);
                LogScreenshot("TagsNotSelected");
            }
        }


        [Then(@"Error message to fill form completely should be displayed")]
        public void ThenErrorMessageToFillFormCompletelyShouldBeDisplayed()
        {
            shareSkillAddSteps.SubCatagoryNotSelectedVerification(); 
        }

        [Then(@"Error message to fill tags should be displayed")]
        public void ThenErrorMessageToFillTagsShouldBeDisplayed()
        {
            shareSkillAddSteps.TagsNotEnteredVerification();  
        }

        [When(@"I add all the fields '([^']*)' and click on cancel button")]
        public void WhenIAddAllTheFieldsAndClickOnCancelButton(string path)
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>(path);
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.ClickonCancelForAdd(shareSkillAdd);
                LogScreenshot("ClickOnCancelForAdd");
            }
        }
        [Then(@"Service should not be added to manage listing")]
        public void ThenServiceShouldNotBeAddedToManageListing()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ClickOnCancelShareSkillAddTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                shareSkillAddSteps.ClickOnCancelVerification(shareSkillAdd);    
            }
        }

    }
}
