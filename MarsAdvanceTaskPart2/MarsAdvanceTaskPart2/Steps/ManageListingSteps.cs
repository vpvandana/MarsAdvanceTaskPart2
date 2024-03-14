using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.NavigationMenu;
using MarsAdvanceTaskPart2.Utilities;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Steps
{
    public class ManageListingSteps : GlobalHelper
    {
        HomePageSteps homePageSteps;
        NavigationMenuTabComponents navigationMenuTabComponents;
        ManageListingOverviewComponent manageListingOverviewComponent;
        ManageListingComponent manageListingComponent;
        ShareSkillAddComponent addShareSkillComponent;
       

        public ManageListingSteps()
        {
            homePageSteps = new HomePageSteps();
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            manageListingOverviewComponent = new ManageListingOverviewComponent();
            manageListingComponent = new ManageListingComponent();
            addShareSkillComponent = new ShareSkillAddComponent();
          

        }

        public void UpdateListedSkillVerification()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\EditManageListingTestData.json");
            foreach (var item in manageListingList)
            {
                string actualUpdateResult = manageListingComponent.GetUpdatedSkillList(item);
                if (actualUpdateResult == "Updated")
                {
                    Assert.AreEqual("Updated", actualUpdateResult, "Actual and expected message do not match");
                }
            }
        }

        public void DeleteListedSkillVerification()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\DeleteSkillListingTestData.json");
            foreach (var item in manageListingList)
            {
                string actualDeleteResult = manageListingComponent.GetDeletedSkill(item);

                if (actualDeleteResult == "Deleted")
                {
                    Assert.AreEqual("Deleted", actualDeleteResult, "Actual and expected message do not match");
                }
                string expectedDeleteMessage = item.Title + " has been deleted";
                string actualDeleteMessage = manageListingComponent.GetDeletedMessage();
                Assert.AreEqual(actualDeleteMessage, expectedDeleteMessage, "Actual and expected message do not match");

            }
        }
        public void ViewListedSkillVerification()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ViewSkillTestData.json");
            foreach (var item in manageListingList)
            {
                string actualResult = manageListingComponent.GetViewSkill(item);
                if (actualResult == item.Title)
                {
                    Assert.AreEqual(actualResult, item.Title, "The actual and expected message do not match");
                }

            }
        }

        public void SkillPaginationAssertion()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\PaginationTestData.json");
            foreach (var item in manageListingList)
            {

                string actualResult = manageListingComponent.GetTitleByPagination(item);
                Assert.AreEqual(actualResult, "Found", "Title not found");
            }
        }

        public void ActivateDeactivateVerification()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ActiveButtonManageListingTestData.json");
            foreach (var item in manageListingList)
            {
                string actualResult = manageListingComponent.ActivateDeactivateSkills(item);
                if (actualResult == "Activated")
                {
                    Assert.AreEqual(actualResult, "Activated", "The actual and expected result do not match");

                    string message = manageListingComponent.GetActiveMessage();
                    string expectedMessage = "Service has been activated";
                    Assert.AreEqual(message, expectedMessage, "Actual and expected message do not match");
                }
                else
                {
                    Assert.AreEqual(actualResult, "Deactivated", "The actual and expected result do not match");
                    string deactiveMessage = manageListingComponent.GetActiveMessage();
                    string expectedDeactiveMessage = "Service has been deactivated";
                    Assert.AreEqual(deactiveMessage, expectedDeactiveMessage, "Actual and expected message do not match");
                }


            }
        }
    }


}
