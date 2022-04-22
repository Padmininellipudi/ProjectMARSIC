using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.Pages;
using ProjectMARSIC.Utilities;
using System;
using System.Threading;

namespace ProjectMARSIC.Tests
{
    [TestFixture]
    internal class ProfileTests : CommonDriver
    {
        [Ignore("For now")]
        [Test, Order(1), Description("Check if Seller is able to Login Profile page and add language with valid data")]
        public void AddLanguage_Test()
        {
            try
            {
                
                test = extent.CreateTest("Add Language Test");
                test.Log(Status.Info, "Add Language Test Start");
                ProfilePage profilePageObj = new ProfilePage();
                HomePage homePageObj = new HomePage();

                //Navigate to Profile page
                homePageObj.navigateToProfilePage(driver);
                takeScreenShot(driver);

                //Add Language
                profilePageObj.navigateToLanguagesTab(driver);
                profilePageObj.addLanguage(driver, "English");

                //Verify Language Added
                profilePageObj.verifyLanguage(driver, "English");
                takeScreenShot(driver);
                test.Log(Status.Pass, "Add Language Test Passed");
                
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Add Language Test Failed");
            }
            
        }
        [Ignore("For now")]
        [Test, Order(2), Description("Check if Seller is able to edit a Language and Language Level with valid data")]
        public void EditLanguage_Test()
        {
            ProfilePage profilePageObj = new ProfilePage();
            HomePage homePageObj = new HomePage();
            //Navigate to Profile page
            homePageObj.navigateToProfilePage(driver);

            //Edit Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.verifyLanguage(driver, "English");
            profilePageObj.editLanguage(driver, "English", "EditedEnglish");

            //Verify Language Edited
            profilePageObj.verifyEditedLanguage(driver, "dummy");
        }
        [Ignore("For now")]
        [Test, Order(3), Description("Check if Seller is able to Delete Language with valid data")]
        public void DeleteLanguage_Test()
        {
            ProfilePage profilePageObj = new ProfilePage();
            HomePage homePageObj = new HomePage();
            //Navigate to Profile page
            homePageObj.navigateToProfilePage(driver);

            //Delete Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.verifyEditedLanguage(driver, "dummy");
            profilePageObj.deleteLanguage(driver, "EditedEnglish");

        }
    }
}
