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
    internal class ProfilePage
    {
        private IWebDriver driver;
        IWebElement goToLanguageTab;
        public void navigateToLanguagesTab(IWebDriver driver)
        {
            //Identify Languages link and click
            IWebElement linkLanguages = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            linkLanguages.Click();
            Thread.Sleep(2000);
        }

        //Add Language and Language level in Language section
        public void addLanguage(IWebDriver driver)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(2000);

            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageTextbox.SendKeys("English");
            Thread.Sleep(2000);

            IWebElement chooseLanguageDropdown = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            chooseLanguageDropdown.Click();
            Thread.Sleep(3000);

            IWebElement basicOption = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
            basicOption.Click();
            Thread.Sleep(2000);

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);
        }

        public String getLanguage(IWebDriver driver)
        {
            IWebElement actualLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return actualLanguage.Text;
        }

        public String getLanguageLevel(IWebDriver driver)
        {
            IWebElement actualLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
            return actualLanguageLevel.Text;
        }

        public void verifyLanguage(IWebDriver driver)
        {
            IWebElement actualLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            IWebElement actualLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));

            Console.WriteLine("Actual Language ... " + actualLanguage.Text);
            Console.WriteLine("Actual Level ..." + actualLevel.Text);

            if (actualLanguage.Text == "English")
            {
                Console.WriteLine("Language is added successfully, test is passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }

        //Edit Language and Language Level
        public void EditProfile(IWebDriver driver)
        {
            //Wait until the entire Profile page is displayed
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            //Click on language section
            goToLanguageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            goToLanguageTab.Click();
            Thread.Sleep(3000);

            IWebElement findLanguageCreated = driver.FindElement(By.XPath(""));
            if (findLanguageCreated.Text == "English")
            {
                // Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record to be edited has not found, Record not edited");
            }

            // Edit the code
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys(code);

            // Edit the Description
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys(description);

            // Edit the Price field
            IWebElement priceTag1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox1 = driver.FindElement(By.XPath("//*[@id='Price']"));
            priceTag1.Click();
            priceTextbox1.Clear();
            priceTag1.Click();
            priceTextbox1.SendKeys(price);

            //Click save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            Thread.Sleep(3000);

            //Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return createdDescription.Text;
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return createdCode.Text;
        }

    }
}