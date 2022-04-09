using System;
using ProjectMARSIC.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ProjectMARSIC.Pages;

namespace ProjectMARSIC.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        // Initializing Page Objects
        HomePage homePageObj = new HomePage();
        ProfilePage profilePageObj = new ProfilePage();
        LoginPage loginPageObj = new LoginPage();

    //Adds Language and Language Level   
        [Given(@"Seller visits Profile page")]
        public void GivenSellerVisitsProfilePage()
        {
            driver = new ChromeDriver();
            loginPageObj.loginSteps(driver);
            homePageObj.goToProfilePage(driver);
        }

        [When(@"Seller adds '([^']*)'")]
        public void WhenSellerAdds(string p0)
        {
            profilePageObj.addLanguage(driver, p0);
        }

        [Then(@"verify Seller can see the added '([^']*)' in the Language section of Profile page")]
        public void ThenVerifySellerCanSeeTheAddedLanguageInTheLanguageSectionOfProfilePage(string p0)
        {
            String actualLanguage = profilePageObj.getLanguage(driver);

            Assert.That(actualLanguage == p0, "Actual Language and Expected Language match");
            profilePageObj.verifyLanguage(driver, p0);
        }

        [Then(@"Seller closes the browser")]
        public void ThenSellerClosesTheBrowser()
        {
            driver.Quit();
        }

        //Edit Language and Language Level         

        [When(@"Seller edits '([^']*)' with '([^']*)'")]
        public void WhenSellerEdits(string p0, string p1)
        {
            profilePageObj.editLanguage(driver, p0, p1);            
        }

        [Then(@"Seller can see the '([^']*)' in the Language section of Profile page")]
        public void ThenSellerCanSeeTheInTheLanguageSectionOfProfilePage(string p0)
        {
            profilePageObj.verifyEditedLanguage(driver, p0);
        }

        //Deletes Language and Language level
        [When(@"Seller Deletes '([^']*)' Edited Language")]
        public void WhenSellerDeletesEditedLanguage(string p0)
        {
            profilePageObj.deleteLanguage(driver, p0);
        }

        [Then(@"verify Seller can see ""([^""]*)"" in the Language section of profile page")]
        public void ThenVerifySellerCanSeeInTheLanguageSectionOfProfilePage(string p1)
        {
            profilePageObj.verifyDeletedLanguage(driver, p1);
        }

        [Then(@"Verify Seller can see confirmation message '([^']*)' has been deleted from your languages")]
        public void ThenVerifySellerCanSeeConfirmationMessageHasBeenDeletedFromYourLanguages(string p0)
        {
            profilePageObj.verifyDeletedLanguage(driver, p0);
        }


    }
}
