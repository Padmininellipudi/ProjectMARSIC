using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMARSIC.Pages
{
    internal class ManageListingPage
    {
        public void navigateToManageListing(IWebDriver driver)
        {
            //Identify ShareSkill button and click
            IWebElement manageListingLink = driver.FindElement(By.XPath("//*[@id='listing-management-section']div/section[1]/div/a[3]"));
            manageListingLink.Click();
        }
        public void navigateToShareSkill(IWebDriver driver)
        {
            //Identify Share skill button and click
            Thread.Sleep(3000);
            IWebElement shareSkillButton = driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/div[2]/a"));
            shareSkillButton.Click();
            Thread.Sleep(3000);
        }

        public void verifyListing(IWebDriver driver)
        {
            IWebElement eyeIcon = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i"));
            eyeIcon.Click();

            IWebElement actualCategory = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
            IWebElement actualTitle = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id=//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));

            Console.WriteLine("Actual Category ... " + actualCategory.Text);
            Console.WriteLine("Actual Title ..." + actualTitle.Text);
            Console.WriteLine("Actual Description..." + actualDescription.Text);            
        }
        public void editSkill(IWebDriver driver)
        {
            //Click Edit icon
            Thread.Sleep(2000);
            IWebElement outlineWriteIcon = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
            outlineWriteIcon.Click();

            //Edit Title
            Thread.Sleep(2000);
            IWebElement editTitle = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            editTitle.Clear();
            editTitle.SendKeys("Edit Software Testing");

            //Edit Description
            Thread.Sleep(2000);
            IWebElement editDescription = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            editDescription.Clear();
            editDescription.SendKeys("My hobbies are edit Travelling, edit Teaching and edit Cooking");

            //Edit category and subcategory
            Thread.Sleep(2000);
            IWebElement editCategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select"));
            editCategory.Click();
                        
            Thread.Sleep(2000);
            IWebElement graphicsDesignOption = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[2]"));
            graphicsDesignOption.Click();

            Thread.Sleep(3000);
            IWebElement editSubCategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
            editSubCategory.Click();

            Thread.Sleep(3000);
            IWebElement logoDesignOption = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[2]"));
            logoDesignOption.Click();

            Thread.Sleep(2000);
            IWebElement editSaveButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
            editSaveButton.Click();
            Thread.Sleep(2000);
        }

        public string getEditedTitle(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement editedTitle = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            return editedTitle.Text; 
        }

        public void deleteSkill(IWebDriver driver)
        {
            //Click delete icon
            Thread.Sleep(3000);
            IWebElement removeIcon = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
            removeIcon.Click();

            Thread.Sleep(2000);
            IWebElement deleteConfirmationMessage = driver.FindElement(By.XPath("/html/body/div[2]/div"));
            deleteConfirmationMessage.Click();
            Thread.Sleep(2000);
        }

        public void navigateToManageListing1(IWebDriver driver)
        {
            //Identify Manage listing link and click
            Thread.Sleep(2000);
            IWebElement manageListingLink = driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/a[3]"));
            manageListingLink.Click();
            Thread.Sleep(3000);
            
        }
    }
}
