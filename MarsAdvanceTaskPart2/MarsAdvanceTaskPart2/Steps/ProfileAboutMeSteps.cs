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
    public class ProfileAboutMeSteps : GlobalHelper
    {
        ProfileAboutMeComponent profileAboutMeComponent;
        HomePageSteps homePageSteps;
        JsonReader jsonReader;

        public ProfileAboutMeSteps()
        {
            profileAboutMeComponent = new ProfileAboutMeComponent();
            homePageSteps = new HomePageSteps();
            jsonReader = new JsonReader();
        }

        public void AddandUpdateUsernameAssertions(ProfileAboutMeModel profile)
        {
            

            string actualAddedUserName = profileAboutMeComponent.GetUserName();
            string expectedUserName = profile.FirstName + " " + profile.LastName;

            Assert.AreEqual(expectedUserName, actualAddedUserName, "Actual and expected message do not match");


        }

        public void UpdateAvailabilityAssertions(ProfileAboutMeModel profile)
        {
           
            string actualAddedAvailability = profileAboutMeComponent.GetAddedAvailability();
            if (actualAddedAvailability == profile.Availability)
            {
                Assert.AreEqual(profile.Availability, actualAddedAvailability, "Actual and expected message do not match");
            }

            //Verifying success message
            string expectedMessage = "Availability updated";
            string actualMessage = profileAboutMeComponent.GetSuccessMessage();

            Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
        }

        public void UpdateProfileAvailabilityHours(ProfileAboutMeModel profile)
        {
            
                profileAboutMeComponent.AddandUpdateAvailabilityHourDetails(profile);

                string actualAddedHours = profileAboutMeComponent.GetAddedHours();
                if (actualAddedHours == profile.Hours)
                {
                    Assert.AreEqual(profile.Hours, actualAddedHours, "Actual and expected Hours do not match");
                }

                //Verifying success message
                string expectedMessage = "Availability updated";
                string actualMessage = profileAboutMeComponent.GetSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "The availability has not updated");      

        }

        public void UpdateProfileAvailabilityEarnTarget(ProfileAboutMeModel profile)
        {
          
            profileAboutMeComponent.AddandUpdateAvailabilityTargetDetails(profile);

            string actualAddedEarnTarget = profileAboutMeComponent.GetAddedEarnTarget();
            if (actualAddedEarnTarget == profile.EarnTarget)
            {
               Assert.AreEqual(profile.EarnTarget, actualAddedEarnTarget, "Actual and expected availability do not match");
            }
           //Verifying success message
            string expectedMessage = "Availability updated";
            string actualMessage = profileAboutMeComponent.GetSuccessMessage();

            Assert.AreEqual(expectedMessage, actualMessage, "The availability has not updated");   
        }

        public void ClickonCancelIconSteps(ProfileAboutMeModel profile)
        {


            string actualAvailabity = profileAboutMeComponent.GetAddedAvailability();

            profileAboutMeComponent.ClickAvailabilityOnCancel();
            string newAvailabity = profileAboutMeComponent.GetAddedAvailability();

            Assert.AreEqual(actualAvailabity, newAvailabity, "The actual and new availabity does not match");

        }
    }
}
