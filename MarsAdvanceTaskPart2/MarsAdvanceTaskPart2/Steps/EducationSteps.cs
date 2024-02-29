using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Steps
{
    public class EducationSteps : GlobalHelper
    {
        HomePageSteps homePageSteps;
        EducationComponent educationComponent;
        ProfileMenuTabComponents profileMenuTabComponents;
        JsonReader jsonReader;
        public EducationSteps() 
        {
            homePageSteps = new HomePageSteps();
            educationComponent = new EducationComponent();
            profileMenuTabComponents = new ProfileMenuTabComponents();
            jsonReader = new JsonReader();
        }

        public void AddEducationValidation(EducationModel education)
        {
            string addedTitle = educationComponent.GetAddedEducation(education);

            string expectedSuccessMessage = "Education has been added";
            string actualMessage = educationComponent.GetAddedMessage();
            Assert.AreEqual(expectedSuccessMessage, actualMessage, "Actual and expected message do not match");

            if (education.Title == addedTitle)
            {
                Assert.AreEqual(education.Title, addedTitle, "Acual and expected education do not match");
                
            }

        }

        public void UpdateEducationValidation(EducationModel education)
        {
            string updatedEducation = educationComponent.GetUpdatedEducation(education);
            if (updatedEducation == education.Degree)
            {
                Assert.AreEqual(education.Degree, updatedEducation, "Actual and updated education do not match");
               
            }
        }

        public void DeleteEducationAssertions()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\DeleteEducationTestData.json");
            foreach (var education in educationList)
            {
                string expectedMessage = educationComponent.GetDeleteEducation(education);
                if(expectedMessage == "Deleted")
                {
                    Assert.AreEqual("Deleted", expectedMessage, "Message mismatch.Education not deleted");
                }

                string expectedSuccessMessage = "Education entry successfully removed";
                string actualMessage = educationComponent.GetDeletedMessage();
            }


        }

        public void AddEmptyEducationAssertions()
        {
            string actualerrorMessage = educationComponent.GetEmptyFieldErrorMessage();
            string expectedMessage = "Please enter all the fields";

            Assert.AreEqual(expectedMessage, actualerrorMessage, "Expected and actual message do not match");
        }

        public void AddSameDegreeSameYearAssertions()
        {
            string actualerrorMessage = educationComponent.GetSameEducationDetailsErrorMessage();
            string expectedMessage = "This information is already exist.";

            Assert.AreEqual(expectedMessage, actualerrorMessage, "Expected and actual message do not match");
        }

        public void AddSameDegreeDifferentYearAssertions()
        {
            string actualerrorMessage = educationComponent.GetSameDegreeDifferentYearErrorMessage();
            string expectedMessage = "Duplicated data";

            Assert.AreEqual(expectedMessage, actualerrorMessage, "Expected and actual message do not match");
        }

        public void UpdateEducationNoChangeAssertions()
        {
            string actualerrorMessage = educationComponent.GetUpdateNoChangeErrorMessage();
            string expectedMessage = "This information is already exist.";

            Assert.AreEqual(expectedMessage, actualerrorMessage, "Expected and actual message do not match");
        }
    }
}
