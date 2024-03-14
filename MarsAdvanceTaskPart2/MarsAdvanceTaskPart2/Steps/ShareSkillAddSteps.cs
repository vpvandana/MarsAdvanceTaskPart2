using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.NavigationMenu;
using MarsAdvanceTaskPart2.Utilities;
using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Steps
{
    public class ShareSkillAddSteps : GlobalHelper
    {
        NavigationMenuTabComponents navigationMenuTabComponents;
        ShareSkillAddComponent addShareSkillComponent;
        JsonReader jsonReader;

        public ShareSkillAddSteps()
        {
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            addShareSkillComponent = new ShareSkillAddComponent();
            jsonReader = new JsonReader();
        }

        public void AddShareSkillStepsVerification(ShareSkillAddModel skill)
        {
            string addedSkillCatagory = addShareSkillComponent.GetAddedSkill(skill);
            if (addedSkillCatagory == skill.Catagory)
            {
                Assert.AreEqual(addedSkillCatagory, skill.Catagory, "Actual and expected message do not match");

            }
        }
        public void MandatoryFieldsEmptyStepVerification()
        {

            string actualMessage = addShareSkillComponent.GetErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
        }

        public void SpecialCharacterOnShareSkillTitleVerification()
        {
            string actualMessage = addShareSkillComponent.GetWarningMessageTitle();

            string expectedMessage = "Special characters are not allowed.";

            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
        }
        public void FirstCharacterSpaceOnTitleVerification()
        {
            string actualMessage = addShareSkillComponent.GetWarningMessageForFirstCharacterSpace();
            string expectedMessage = "First character must be an alphabet character or a number.";
            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
        }

        public void FirstCharacterSpaceOnDescriptionVerification()
        {
            string actualMessage = addShareSkillComponent.GetWarningMessageForFirstCharacterSpaceDescription();

            string expectedMessage = "First character must be an alphabet character or a number.";

            Assert.AreEqual(expectedMessage, actualMessage, "Messages do not match");
        }

        public void SubCatagoryNotSelectedVerification()
        {
            string actualMessage = addShareSkillComponent.GetWarningMessageForSubCatagoryNotSelected();
            string expectedMessage = "Subcategory is required";

            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");

            string formErrorMessage = addShareSkillComponent.GetErrorMessageForIncompleteForm();
            string expectedFormMessage = "Please complete the form correctly.";

            Assert.AreEqual(formErrorMessage, expectedFormMessage, "Actual and expected message do not match");
        }

        public void TagsNotEnteredVerification()
        {
            string actualMessage = addShareSkillComponent.GetWarningMessageForTagsNotEntered();
            string expectedMessage = "Tags are required";

            Assert.AreEqual(expectedMessage, actualMessage, "Messages do not match");

            string formErrorMessage = addShareSkillComponent.GetErrorMessageForIncompleteForm();
            string expectedFormMessage = "Please complete the form correctly.";

            Assert.AreEqual(formErrorMessage, expectedFormMessage, "Actual and expected message do not match");
        }

        public void ClickOnCancelVerification(ShareSkillAddModel skill)
        {
            navigationMenuTabComponents.ClickManageListingTab();
            string actualResult = addShareSkillComponent.GetSkillToVerifyNotAdded(skill);
            Assert.AreEqual(actualResult, "Not Added", "Actual and expected message do not match");
        }
    }
}
