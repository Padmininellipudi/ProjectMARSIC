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
        [Test, Order(1), Description("Check if Seller is able to Login Profile page with valid data")]
        public void AddLanguage_Test()
        {
            ProfilePage profilePageObj = new ProfilePage();

            //Add Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.addLanguage(driver, "English");

            //Verify Language Added
            profilePageObj.verifyLanguage(driver, "English");
        }

        [Test, Order(2), Description("Check if Seller is able to edit a Language and Language Level with valid data")]
        public void EditLanguage_Test()
        {
            ProfilePage profilePageObj = new ProfilePage();

            //Edit Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.verifyLanguage(driver, "English");
            profilePageObj.editLanguage(driver, "English", "EditedEnglish");

            //Verify Language Edited
            profilePageObj.verifyEditedLanguage(driver, "dummy");
        }

        [Test, Order(3), Description("Check if Seller is able to Delete Language with valid data")]
        public void DeleteLanguage_Test()
        {
            ProfilePage profilePageObj = new ProfilePage();

            //Delete Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.verifyEditedLanguage(driver, "dummy");
            profilePageObj.deleteLanguage(driver, "EditedEnglish");

        }
    }
}
