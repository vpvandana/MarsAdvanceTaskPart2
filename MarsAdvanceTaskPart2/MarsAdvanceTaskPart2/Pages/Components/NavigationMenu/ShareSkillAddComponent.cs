using MarsAdvanceTaskPart2.Model;
using MarsAdvanceTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Pages.Components.NavigationMenu
{
    public class ShareSkillAddComponent : GlobalHelper
    {
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement selectCatagory;
        private IWebElement subCatagory;
        private IWebElement addTags;

        private IWebElement oneoffServiceType;
        private IWebElement onlineLocationType;
        private IWebElement offlineLocationType;
        private IWebElement availableStartDate;
        private IWebElement availableSunday;
        private IWebElement availableSaturday;

        private IWebElement availableStartHours;
        private IWebElement availableEndHours;
        private IWebElement skillExchangeTrade;
        //  private IWebElement creditTrade;
        //  private IWebElement creditAmount;
        private IWebElement skillExchangeTag;
        private IWebElement activeWork;
        private IWebElement hiddenWork;
        private IWebElement saveButton;
        private IWebElement cancelButton;

        private IWebElement messageBox;
        private IWebElement messageCloseButton;

        private IWebElement warningMessageBoxTitle;
        private IWebElement warningMessageBoxDescription;

        private IWebElement warningMessageBoxSubCatagory;
        private IWebElement errorMessageForForm;

        private IWebElement warningMessageBoxTags;

        public void RenderComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.XPath("//input[@name='title']"));
                addDescription = driver.FindElement(By.XPath("//textarea[@name='description']"));
                selectCatagory = driver.FindElement(By.XPath("//select[@name='categoryId']"));

                addTags = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                oneoffServiceType = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
                onlineLocationType = driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']"));
                
                availableStartDate = driver.FindElement(By.XPath("//input[@name='startDate']"));

                availableSunday = driver.FindElement(By.XPath("//input[@name='Available' and @index='0']"));
                availableSaturday = driver.FindElement(By.XPath("//input[@name='Available' and @index='6']"));
                availableStartHours = driver.FindElement(By.XPath("//input[@name='StartTime' and @index='0']"));
                availableEndHours = driver.FindElement(By.XPath("//input[@name='EndTime' and @index='0']"));
                skillExchangeTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
                
                skillExchangeTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

                activeWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));
                hiddenWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
                saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderSubCatagoryComponent()
        {
            subCatagory = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        }
        public void RenderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            messageCloseButton = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void RenderWarningMessageForTitleComponent()
        {
            warningMessageBoxTitle = driver.FindElement(By.XPath("//input[@name='title']//parent::div//following-sibling::div//child::div"));

        }

        public void RenderWarningMessageForDescriptionComponent()
        {
            warningMessageBoxDescription = driver.FindElement(By.XPath("//textarea[@name='description']//parent::div//following-sibling::div//child::div"));
        }

        public void RenderWarningMessageForSubCatagoryComponent()
        {
            warningMessageBoxSubCatagory = driver.FindElement(By.XPath("//div[text()='Subcategory is required']"));
        }

        public void RenderWarningMessageForTagsComponent()
        {
            warningMessageBoxTags = driver.FindElement(By.XPath("//div[text()='Tags are required']"));
        }
        public void RenderFormErrorMessageComponent()
        {
            errorMessageForForm = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
        }

        public void AddTitleAndDescription(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            addTitle.SendKeys(skill.Title);
            addDescription.SendKeys(skill.Description);
        }


        public void AddShareSkills(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            AddTitleAndDescription(skill);

            selectCatagory.SendKeys(skill.Catagory);

            RenderSubCatagoryComponent();
            subCatagory.SendKeys(Keys.Tab);
            subCatagory.SendKeys(skill.SubCatagory);

            foreach (string tag in skill.CatagoryTags)
            {
                addTags.SendKeys(tag + Keys.Enter);
            }
            IList<IWebElement> serviceRadioButtons = driver.FindElements(By.Name("serviceType"));
            int Size = serviceRadioButtons.Count;

            for (int i = 0; i < Size; i++)
            {

                String Value = serviceRadioButtons.ElementAt(i).GetAttribute("value");


                if (Value.Equals("1"))
                {
                    serviceRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            IList<IWebElement> locationRadioButtons = driver.FindElements(By.Name("locationType"));
            int locationSize = locationRadioButtons.Count;

            for (int i = 0; i < locationSize; i++)
            {

                String locationValue = locationRadioButtons.ElementAt(i).GetAttribute("value");


                if (locationValue.Equals("0"))
                {
                    locationRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            //Date
            DateTime currentDateTime = DateTime.Today;
            string formattedDateTime = currentDateTime.ToString("MM/dd/YYYY");
            availableStartDate.SendKeys(formattedDateTime);

            //Select multiple days by choice
            IList<IWebElement> checkbox = driver.FindElements(By.XPath("//input[@type='checkbox' and @name='Available']"));
            foreach (IWebElement checkboxElement in checkbox)
            {
                string checkboxName = checkboxElement.GetAttribute("index");
                if (checkboxName.Equals("0") || checkboxName.Equals("3"))
                {
                    checkboxElement.Click();
                    availableStartHours.SendKeys(skill.AvailableStartTime);
                    availableEndHours.SendKeys(skill.AvailableEndTime);
                }
            }
            skillExchangeTrade.Click();
            foreach (string tag in skill.SkillExchangeTag)
            {
                skillExchangeTag.SendKeys(tag + Keys.Enter);
            }

            activeWork.Click();

            saveButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


        }

        public string GetAddedSkill(ShareSkillAddModel skill)
        {
            Thread.Sleep(1000);
            string result = "";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]"));

            foreach (IWebElement row in rows)
            {
                IWebElement skillCatagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement skillTitleElement = row.FindElement(By.XPath("./td[3]"));
                string addedCatagory = skillCatagoryElement.Text;
                string addedTitle = skillTitleElement.Text;

                if (addedCatagory.Equals(skill.Catagory) && addedTitle.Equals(skill.Title))
                {
                    result = addedCatagory;
                    break;
                }
                else
                {
                    result = "Not Added";
                }

            }
            return result;
        }

        public void MandatoryFieldsLeftEmpty(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();

            AddTitleAndDescription(skill);

            selectCatagory.SendKeys(skill.Catagory);

            RenderSubCatagoryComponent();
            subCatagory.SendKeys(skill.SubCatagory);

            foreach (string tag in skill.CatagoryTags)
            {
                addTags.SendKeys(tag + Keys.Enter);
            }

            oneoffServiceType.Click();
            onlineLocationType.Click();
            availableStartDate.SendKeys(skill.AvailableStartDate);

            availableSunday.Click();
            availableStartHours.SendKeys(skill.AvailableStartTime);
            availableEndHours.SendKeys(skill.AvailableEndTime);

            skillExchangeTrade.Click();

            foreach (string tag in skill.SkillExchangeTag)
            {
                skillExchangeTag.SendKeys(tag + Keys.Enter);
            }


            activeWork.Click();

            saveButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        public string GetErrorMessage()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderMessageComponent();

            String message = messageBox.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            messageCloseButton.Click();

            return message;
        }

        public void AddSpecialCharacterOnTitleShareSkill(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            addTitle.SendKeys(skill.Title);


        }

        public string GetWarningMessageTitle()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderWarningMessageForTitleComponent();

            string messageTitle = warningMessageBoxTitle.Text;

            return messageTitle;
        }

        public void FirstCharacterSpaceForTitle(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            addTitle.SendKeys(skill.Title);
        }
        public string GetWarningMessageForFirstCharacterSpace()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderWarningMessageForTitleComponent();

            string messageTitle = warningMessageBoxTitle.Text;

            return messageTitle;
        }

        public void FirstCharacterSpaceForDescription(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            addTitle.SendKeys(skill.Title);
            addDescription.SendKeys(skill.Description);
        }

        public string GetWarningMessageForFirstCharacterSpaceDescription()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderWarningMessageForDescriptionComponent();

            string messageTitle = warningMessageBoxDescription.Text;

            return messageTitle;
        }
        public void SubCatagoryAndTagsNotSelected(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();
            addTitle.SendKeys(skill.Title);
            addDescription.SendKeys(skill.Description);
            selectCatagory.SendKeys(skill.Catagory);

            IList<IWebElement> serviceRadioButtons = driver.FindElements(By.Name("serviceType"));
            int Size = serviceRadioButtons.Count;

            for (int i = 0; i < Size; i++)
            {

                String Value = serviceRadioButtons.ElementAt(i).GetAttribute("value");


                if (Value.Equals("1"))
                {
                    serviceRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            IList<IWebElement> locationRadioButtons = driver.FindElements(By.Name("locationType"));
            int locationSize = locationRadioButtons.Count;

            for (int i = 0; i < locationSize; i++)
            {

                String locationValue = locationRadioButtons.ElementAt(i).GetAttribute("value");


                if (locationValue.Equals("0"))
                {
                    locationRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            DateTime currentDateTime = DateTime.Today;
            string formattedDateTime = currentDateTime.ToString("MM/dd/YYYY");
            availableStartDate.SendKeys(formattedDateTime);

            IList<IWebElement> availableDaysCheckbox = driver.FindElements(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));

            availableStartHours.SendKeys(skill.AvailableStartTime);
            availableEndHours.SendKeys(skill.AvailableEndTime);

            availableSaturday.Click();
            skillExchangeTrade.Click();

            activeWork.Click();

            saveButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


        }

        public string GetWarningMessageForSubCatagoryNotSelected()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderWarningMessageForSubCatagoryComponent();

            string messageTitle = warningMessageBoxSubCatagory.Text;

            return messageTitle;
        }
        public string GetWarningMessageForTagsNotEntered()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderWarningMessageForTagsComponent();

            string messageTitle = warningMessageBoxTags.Text;

            return messageTitle;
        }
        public string GetErrorMessageForIncompleteForm()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderFormErrorMessageComponent();

            string errorMessage = errorMessageForForm.Text;
            return errorMessage;

        }
        public void ClickonCancelForAdd(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();


            addTitle.SendKeys(skill.Title);
            addDescription.SendKeys(skill.Description);
            selectCatagory.SendKeys(skill.Catagory);

            RenderSubCatagoryComponent();
            subCatagory.SendKeys(Keys.Tab);
            subCatagory.SendKeys(skill.SubCatagory);

            foreach (string tag in skill.CatagoryTags)
            {
                addTags.SendKeys(tag + Keys.Enter);
            }
            IList<IWebElement> serviceRadioButtons = driver.FindElements(By.Name("serviceType"));
            int Size = serviceRadioButtons.Count;

            for (int i = 0; i < Size; i++)
            {

                String Value = serviceRadioButtons.ElementAt(i).GetAttribute("value");


                if (Value.Equals("1"))
                {
                    serviceRadioButtons.ElementAt(i).Click();

                    break;
                }

            }
            DateTime currentDateTime = DateTime.Today;
            string formattedDateTime = currentDateTime.ToString("MM/dd/YYYY");
            availableStartDate.SendKeys(formattedDateTime);

            availableSunday.Click();
            availableStartHours.SendKeys(skill.AvailableStartTime);
            availableEndHours.SendKeys(skill.AvailableEndTime);

            availableSaturday.Click();
            skillExchangeTrade.Click();

            foreach (string tag in skill.SkillExchangeTag)
            {
                skillExchangeTag.SendKeys(tag + Keys.Enter);
            }

            activeWork.Click();

            cancelButton.Click();
        }

        public string GetSkillToVerifyNotAdded(ShareSkillAddModel skill)
        {
            string result = "";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]"));

            foreach (IWebElement row in rows)
            {
                IWebElement skillCatagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement skillTitleElement = row.FindElement(By.XPath("./td[3]"));
                string addedCatagory = skillCatagoryElement.Text;
                string addedTitle = skillTitleElement.Text;

                if (addedCatagory != (skill.Catagory) && addedTitle != (skill.Title))
                {
                    result = "Not Added";
                    break;
                }
                else
                {
                    result = "Added";
                }

            }
            return result;
        }
    }

}

