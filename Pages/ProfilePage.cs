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
    internal class ProfilePage
    {
        //private IWebDriver driver;
        IWebElement goToLanguageTab;
        public void navigateToLanguagesTab(IWebDriver driver)
        {
            //Identify Languages link and click
            IWebElement linkLanguages = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            linkLanguages.Click();
            Thread.Sleep(2000);
        }

        //Add Language and Language level in Language section
        public void addLanguage(IWebDriver driver, String Language)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(2000);

            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageTextbox.SendKeys(Language);
            Thread.Sleep(1000);

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
            IWebElement actualLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return actualLanguage.Text;
        }

        public String getLanguageLevel(IWebDriver driver)
        {
            IWebElement actualLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return actualLanguageLevel.Text;
        }

        public void verifyLanguage(IWebDriver driver, String language)
        {
            IWebElement actualLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            IWebElement actualLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));

            Console.WriteLine("Actual Language ... " + actualLanguage.Text);
            Console.WriteLine("Actual Level ..." + actualLevel.Text);

            if (actualLanguage.Text == language)
            {
                Console.WriteLine("Language is added successfully, test is passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }

        //Edit Language and Language Level
        public void editLanguage(IWebDriver driver, String oldLanguage, String newLanguage)
        {
            //Wait until the entire Profile page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[1]/div/a[2]", 2);

            //Click on language section
            goToLanguageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            goToLanguageTab.Click();
            Thread.Sleep(3000);

            IWebElement findLanguageCreated = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (findLanguageCreated.Text == oldLanguage)
            {
                // Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record to be edited has not found, Record not edited");
            }

            // Edit the Language
            IWebElement editLanguageTextbox = driver.FindElement(By.Name("name"));
            editLanguageTextbox.Clear();
            editLanguageTextbox.SendKeys(newLanguage);

            // Edit the Language Level
            IWebElement editLanguageLevel = driver.FindElement(By.Name("level"));
            editLanguageLevel.Click();
            Thread.Sleep(2000);

            IWebElement fluentOption = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]"));
            fluentOption.Click();
            Thread.Sleep(2000);

            //Click Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]", 3);
            Thread.Sleep(3000);
        }

        public string GetEditedLanguage(IWebDriver driver)
        {
            IWebElement editedLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[1]/input"));
            return editedLanguage.Text;
        }

        public string GetEditedLanguageLevel(IWebDriver driver)
        {
            IWebElement editedLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[2]/select/option[4]"));
            return editedLanguageLevel.Text;
        }

        //Verify Language Edited
        public void verifyEditedLanguage(IWebDriver driver, string editedLanguagee)
        {
           
            IWebElement editedLanguage = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            
            Console.WriteLine("Edited Language ... " + editedLanguagee);
            Console.WriteLine("Expected Language ... " + editedLanguage.Text);

            if (editedLanguage.Text == editedLanguagee)
            {
                Console.WriteLine("Language is edited successfully, test is passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
            Thread.Sleep(8000);
        }

        //Delete Language

        public void deleteLanguage(IWebDriver driver, String language)
        {
            //Wait until the entire Profile page is displayed
            
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[1]/div/a[2]", 3);

            //Click on language section
            goToLanguageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            goToLanguageTab.Click();
            Thread.Sleep(3000);

            IWebElement findLanguageEdited = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (findLanguageEdited.Text == language)
            {
                // Click on delete button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                deleteButton.Click();
                Console.WriteLine("Language Deleted Successfully");

                ////Wait for the alert to be displayed
                ////Store the alert in a variable
                //IAlert alert = driver.SwitchTo().Alert();
                //Thread.Sleep(3000);
                ////Store the alert in a variable for reuse
                //string text = alert.Text;

                ////Press Ok button
                //alert.Accept();
            }
            else
            {
                Assert.Fail("Record to be deleted has not found, Record not deleted");
                Thread.Sleep(2000);
            }
            //driver.Navigate().Refresh();
            //Thread.Sleep(1000);
        }

        public void verifyDeletedLanguage(IWebDriver driver, string p0)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 5);
            IWebElement deleteConfirmationMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Console.WriteLine(deleteConfirmationMessage.Text);
            Assert.That(deleteConfirmationMessage.Text.Contains(p0));
            Assert.That(deleteConfirmationMessage.Text == (p0 + " has been deleted from your languages"));
        }

    }
}