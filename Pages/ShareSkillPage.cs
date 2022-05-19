using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMARSIC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.IO;

namespace ProjectMARSIC.Pages
{
    public class ShareSkillPage
    {
        AutoItX3 fileUpload = new AutoItX3();
        public string parentDir = Directory.GetParent(@"../../../").FullName;
        
        
        public void navigateToServiceListing(IWebDriver driver)
        {
            Thread.Sleep(3000);
            //Identify ShareSkill button and click
            IWebElement shareSkillButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
            shareSkillButton.Click();
        }

        //Add all Sections in Share Skill 

        public void addListings(IWebDriver driver, String title, String description, String category, String subCategory, String serviceTag, String serviceType, String locationType, String startDate, String endDate, String workSample)
        {
            try
            {

                //Enter Title in Textbox
                Thread.Sleep(2000);
                IWebElement titleTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
                titleTextbox.SendKeys(title);

                //Enter Description in Textbox
                Thread.Sleep(2000);
                IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/ div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
                //descriptionTextbox.Click();
                descriptionTextbox.SendKeys(description);


                //Select category and subcategory in Share Skill
                Thread.Sleep(2000);
                IWebElement categoryDropdown = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select"));
                categoryDropdown.Click();
                categoryDropdown.SendKeys(category);
                categoryDropdown.Click();
                Thread.Sleep(3000);

                IWebElement subCategoryDropdown = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
                subCategoryDropdown.Click();
                subCategoryDropdown.SendKeys(subCategory);
                subCategoryDropdown.Click();
                Thread.Sleep(3000);


                //Add new tags in Tags field
                IWebElement tagsTextbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                tagsTextbox.Click();
                Thread.Sleep(2000);
                tagsTextbox.SendKeys(serviceTag);
                tagsTextbox.SendKeys(Keys.Enter);


                //Select Service type
                Thread.Sleep(2000);
                IWebElement hourlyBasisServiceRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
                hourlyBasisServiceRadiobox.Click();
                hourlyBasisServiceRadiobox.SendKeys(serviceType);


                //Select Location Type
                Thread.Sleep(2000);
                IWebElement onlineRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
                onlineRadiobox.Click();
                onlineRadiobox.SendKeys(locationType);


                //Select Available days
                Thread.Sleep(2000);
                IWebElement startDate1 = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
                startDate1.Click();
                startDate1.SendKeys(startDate);

                Thread.Sleep(2000);
                IWebElement endDate1 = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
                endDate1.Click();
                endDate1.SendKeys(endDate);


                Thread.Sleep(2000);
                IWebElement sunCheckbox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
                sunCheckbox.Click();

                //Select start time and end time
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

                //Upload Samples
                Thread.Sleep(2000);
                IWebElement workSamples = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                workSamples.Click();
                Thread.Sleep(2000);
                uploadFile(workSample);
                IWebElement removeWorkSamples = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/div/i[1]"));
                removeWorkSamples.Click();
                Thread.Sleep(3000);


                //Select Active radiobox
                Thread.Sleep(2000);
                IWebElement activeRadiobox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
                activeRadiobox.Click();

                //Click Save button
                IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
                saveButton.Click();
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ignore Worksample Error", ex.Message);
            }
        }

        public void uploadFile(string filename)
        {
            fileUpload.WinActivate("Open");
            Console.WriteLine(parentDir);

            string filePath = parentDir
                + Path.DirectorySeparatorChar + "FileUpload"
                + Path.DirectorySeparatorChar + filename;
            Console.WriteLine(filePath);

            fileUpload.Send(filePath);
            fileUpload.Send("{ENTER}");
            Thread.Sleep(2000);
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