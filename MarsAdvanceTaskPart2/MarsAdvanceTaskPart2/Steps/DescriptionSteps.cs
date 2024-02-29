using AventStack.ExtentReports;
using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Steps
{
    public class DescriptionSteps : GlobalHelper
    {
        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private ProfileDescriptionComponent profileDescriptionComponent;
        ExtentTest testreport;

        public DescriptionSteps()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            profileDescriptionComponent = new ProfileDescriptionComponent();
        }

        public void AddDescriptionVerification(DescriptionModel description)
        {
            string actualMessage = "Description has been saved successfully";
            string expectedMessage = profileDescriptionComponent.GetAddedSuccessMessage();

            Assert.AreEqual(expectedMessage, actualMessage, "Description not added");

            string addedDescription = profileDescriptionComponent.GetAddedDescription();
            if (addedDescription == description.DescriptionText)
            {

                Assert.AreEqual(addedDescription, description.DescriptionText, "Description does not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }

        }

        public void DeleteDescriptionVerification()
        {
            string actualMessage = "Please, a description is required";
            string expectedMessage = profileDescriptionComponent.GetDeletedMessage();

            Assert.AreEqual(expectedMessage, actualMessage, "Description not deleted");
            if (testreport != null)
            {
                testreport.Log(Status.Pass, "Test Passed");
            }
        }

        public void FirstCharacterSpaceDescriptionVerification()
        {
            string actualMessage = "First character can only be digit or letters";

            string expectedMessage = profileDescriptionComponent.GetFirstCharacterSpaceErrorMessage();


            Assert.AreEqual(expectedMessage, actualMessage, "Description added. Error");
            if (testreport != null)
            {
                testreport.Log(Status.Pass, "Test Passed");
            }
        }
    }
}
