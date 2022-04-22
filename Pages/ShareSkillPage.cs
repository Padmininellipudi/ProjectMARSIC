using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMARSIC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMARSIC.Pages
{
    internal class ShareSkillPage
    {
        public void navigateToServiceListing(IWebDriver driver)
        {
            //Identify ShareSkill button and click
            IWebElement shareSkillButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
            shareSkillButton.Click();
        }

        //Add all Sections in Share Skill 

        public void addListings(IWebDriver driver)
        {
            //Enter Title in Textbox
            Thread.Sleep(2000);
            IWebElement titleTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            titleTextbox.SendKeys("Software Testing");

            //Enter Description in Textbox
            Thread.Sleep(2000);
            IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/ div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            descriptionTextbox.SendKeys("My hobbies are travelling, teaching and cooking");

            //Select category and subcategory in Share Skill
            Thread.Sleep(2000);
            IWebElement categoryDropdown = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select"));
            categoryDropdown.Click();
            Thread.Sleep(3000);

            IWebElement programmingTechOption = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]"));
            programmingTechOption.Click();
            Thread.Sleep(2000);

            IWebElement subCategoryDropdown = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
            subCategoryDropdown.Click();
            Thread.Sleep(3000);

            IWebElement qaOption = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]"));
            qaOption.Click();

            //Add new tags in Tags field
            Thread.Sleep(2000);
            IWebElement tagsTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            tagsTextbox.Click();
            tagsTextbox.SendKeys("Testing");
            tagsTextbox.SendKeys(Keys.Enter);


            //Select Service type
            Thread.Sleep(2000);
            IWebElement hourlyBasisServiceRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
            hourlyBasisServiceRadiobox.Click();

            //Select Location Type
            Thread.Sleep(2000);
            IWebElement onlineRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
            onlineRadiobox.Click();

            //Select Available days
            Thread.Sleep(2000);
            IWebElement startDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
            startDate.SendKeys("25/04/2022");

            Thread.Sleep(2000);
            IWebElement endDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
            endDate.SendKeys("30/04/2022");

            Thread.Sleep(2000);
            IWebElement sunCheckbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
            sunCheckbox.Click();

            Thread.Sleep(2000);
            IWebElement startTime = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input"));
            startTime.SendKeys("05:50pm");

            Thread.Sleep(2000);
            IWebElement endTime = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input"));
            endTime.SendKeys("12:30pm");

            //Select Skill Trade
            Thread.Sleep(2000);
            IWebElement creditRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
            creditRadiobox.Click();

            //Enter credit amount
            Thread.Sleep(2000);
            IWebElement creditTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/ div[2]/div/form/div[8]/div[4]/div/div/input"));
            creditTextbox.SendKeys("5");

            //Select Active radiobox
            Thread.Sleep(2000);
            IWebElement activeRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
            activeRadiobox.Click();

            //Click Save button
            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
            saveButton.Click();
        }
        
        public string getTitle(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement title = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            return title.Text;
        }

        public string getDescription(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement description = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
            return description.Text;
        }

        public string getCategory(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement category = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
            return category.Text;
        }

        public void verifyAddSkill(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement actualTitle = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
            
            Console.WriteLine("Actual Title ... " + actualTitle.Text);
            Console.WriteLine("Actual Description ..." + actualDescription.Text);

            if (actualTitle.Text == "Software Testing")
            {
                Console.WriteLine("Title is added successfully, test is passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
        //Navigates to Manage Listing page
        public void navigateToManageListing(IWebDriver driver)
        {
            //Identify Manage listing link and click
            Thread.Sleep(2000);
            IWebElement manageListingLink = driver.FindElement(By.XPath("//*[@id='listing-management-section']div/section[1]/div/a[3]"));
            manageListingLink.Click();
        }
    }
}
