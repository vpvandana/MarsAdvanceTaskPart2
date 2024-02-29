using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.ProfileOverview
{
    public class EducationComponent : GlobalHelper
    {
        private IWebElement addNewButton;

        private IWebElement universityNameTextbox;
        private IWebElement countryDropdown;
        private IWebElement titleDropdown;
        private IWebElement degreeTextbox;
        private IWebElement yearOfGraduationDropdown;
        private IWebElement addButton;
        private IWebElement cancelBButton;
        private IWebElement educationTab;

        private IWebElement addedTitle;

        private IWebElement removeIcon;
        private IWebElement updateIcon;
        private IWebElement updateButton;

        private IWebElement deleteIcon;
        private IWebElement actualMessage;
        public void RenderEducationComponents()
        {
           
            cancelBButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            addedTitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3][last()]"));
            // addedTitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3][last()]"));
            removeIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
            

        }

        public void RenderAddComponents()
        {
            try
            {
                addNewButton = driver.FindElement(By.XPath("//*[text()='Country']//parent::tr//child::th[6]//div"));
                universityNameTextbox = driver.FindElement(By.Name("instituteName"));
                countryDropdown = driver.FindElement(By.Name("country"));
                titleDropdown = driver.FindElement(By.Name("title"));
                degreeTextbox = driver.FindElement(By.Name("degree"));
                yearOfGraduationDropdown = driver.FindElement(By.Name("yearOfGraduation"));
                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderUpdateComponents()
        {
            updateIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
           
        }

        public void RenderUpdateButton()
        {
            updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
        }

        public void RenderDeleteComponent()
        {
             deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));
        }

        public void RenderActualMessageComponent()
        {
            actualMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        
        public void SendKeysToInputField(EducationModel education)
        {
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            universityNameTextbox.SendKeys(Keys.Control +"A");
            universityNameTextbox.SendKeys(Keys.Delete);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            universityNameTextbox.SendKeys(education.CollegeName);

            countryDropdown.SendKeys(education.Country);
            titleDropdown.SendKeys(education.Title);

            degreeTextbox.SendKeys(Keys.Control +"A");
            degreeTextbox.SendKeys(Keys.Delete);
            degreeTextbox.SendKeys(education.Degree);
            yearOfGraduationDropdown.SendKeys(education.Year);
        }

        public void ClearExistingEntries()
        {
          
            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 15);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            if (rows.Count > 0)
            {
                foreach (IWebElement row in rows)
                {
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[6]/span[2]/i"));
                    deleteIcon.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
                }
            }
        }
        public void AddEducation(EducationModel education)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 7);
          
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            addNewButton.Click();
            SendKeysToInputField(education);
            addButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }

        public string GetAddedEducation(EducationModel education)
        {
            Thread.Sleep(1000);
            string result = "";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody[last()]/tr"));

            foreach (IWebElement row in rows)
            {
                IWebElement collegeNameElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement countryElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                string addedCollegeName = collegeNameElement.Text;
                string addedCountry = countryElement.Text;
                string addedTitle = titleElement.Text;

                if (addedCollegeName.Equals(education.CollegeName) && addedCountry.Equals(education.Country) && addedTitle.Equals(education.Title))
                {
                    result = addedCollegeName;
                    break;
                }
                else
                {
                    result = "Not Added";
                }

            }
            return result;
        }

        public string GetAddedMessage()
        {
            RenderActualMessageComponent();
            return actualMessage.Text;
        }
        public void UpdateEducation(EducationModel education)
        {
            
            RenderUpdateComponents();
            updateIcon.Click();
            SendKeysToInputField(education);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            RenderUpdateButton();
            updateButton.Click();

        }

        public string GetUpdatedEducation(EducationModel education)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            string result = "";

            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement countryElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement degreeElement = row.FindElement(By.XPath("./td[4]"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string updatedCountry = countryElement.Text;
                string updatedTitle = titleElement.Text;
                string updatedDegree = degreeElement.Text;

                if ((updatedCountry == education.Country) && (updatedDegree == education.Degree) && (updatedTitle == education.Title))
                {
                    result = updatedDegree;
                    break;
                }

            }

            return result;

        }

        public void DeleteEducation(EducationModel education)
        {
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            foreach (IWebElement row in rows)
            {
                
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement degreeElement = row.FindElement(By.XPath("./td[4]"));
                IWebElement yearElement = row.FindElement(By.XPath("./td[5]"));

               
                string titleDelete = titleElement.Text;
                string degreetodelete = degreeElement.Text;
                string yearDelete = yearElement.Text;

                if (degreetodelete.Equals(education.Degree) && yearDelete.Equals(education.Year) && titleDelete.Equals(education.Title))
                {
                    RenderDeleteComponent();
                    deleteIcon.Click();
           
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }

            }
        }

        public string GetDeleteEducation(EducationModel education)
        {
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            string result = "";

            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement yearElement = row.FindElement(By.XPath("./td[5]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement degreeElement = row.FindElement(By.XPath("./td[4]"));
                string deletedYear = yearElement.Text;
                string deletedTitle = titleElement.Text;
                string deletedDegree = degreeElement.Text;

                if ((deletedYear != education.Country) && (deletedTitle != education.Title) && (deletedDegree != education.Degree))
                {
                  
                     result = "Deleted";
                     break;
                    
                   
                }
                else if(rows.Count == 0)
                {
                    result = "Deleted";
                    break;
                }

            }

            return result;
        }
        public string GetDeletedMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            RenderActualMessageComponent();
            return actualMessage.Text;
        }

        public void AddEmptyEducationField(EducationModel education)
        {


            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 7);
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            addNewButton.Click();
            SendKeysToInputField(education);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            addButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        public string GetEmptyFieldErrorMessage()
        {
            RenderActualMessageComponent();
            return actualMessage.Text;
        }

        public void AddSameDegreeSameYear(EducationModel education)
        {


            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 7);
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            addNewButton.Click();
            SendKeysToInputField(education);
            addButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public string GetSameEducationDetailsErrorMessage()
        {
            RenderActualMessageComponent();
            return actualMessage.Text;
        }

        public string GetSameDegreeDifferentYearErrorMessage()
        {
            RenderActualMessageComponent();
            return actualMessage.Text;
        }

        public void UpdateEducationNoChange()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 7);
            RenderUpdateComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            updateIcon.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            RenderUpdateButton();
            updateButton.Click();

        }

        public string GetUpdateNoChangeErrorMessage()
        {
            RenderActualMessageComponent();
            return actualMessage.Text;
        }


    }
}
