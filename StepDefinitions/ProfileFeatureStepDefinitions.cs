using System;
using ProjectMARSIC.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ProjectMARSIC.Pages;

namespace ProjectMARSIC.StepDefinitions
{
    [Binding]
    public class ProfileFeatureStepDefinitions : CommonDriver
    {
        // Initializing Page Objects
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        ProfilePage profilePageObj = new ProfilePage();

        //Login

        [Given(@"Seller is in Home Page")]
        public void GivenSellerIsInHomePage()
        {
            loginPageObj.LoginSteps(driver);
        }

        [When(@"Seller enters valid username and password")]
        public void WhenSellerEntersValidUsernameAndPassword()
        {
            loginPageObj.LoginSteps(driver);
        }

        [When(@"Clicks Login button")]
        public void WhenClicksLoginButton()
        {
            homePageObj.navigateToProfilePage(driver);
        }

        [Then(@"Seller logged in successfully")]
        public void ThenSellerLoggedInSuccessfully()
        {
            homePageObj.verifyLoginSuccess(driver);
        }

        //Adding Languages

        [Given(@"Seller is in Profile Page")]
        public void GivenSellerIsInProfilePage()
        {
            homePageObj.navigateToProfilePage(driver);
        }

        [Given(@"Seller is in Language section")]
        public void GivenSellerIsInLanguageSection()
        {
            profilePageObj.navigateToLanguagesTab(driver);
        }

        [When(@"Seller inputs Language and Level")]
        public void WhenSellerInputsLanguageAndLevel(String p0)
        {
            profilePageObj.addLanguage(driver, p0);
        }

        [When(@"clicks Add button")]
        public void WhenClicksAddButton()
        {
            profilePageObj.getLanguage(driver);
        }

        [Then(@"verify Seller can see the added languages in the Language section of Profile page")]
        public void ThenVerifySellerCanSeeTheAddedLanguagesInTheLanguageSectionOfProfilePage(String p0)
        {

            String actualLanguage = profilePageObj.getLanguage(driver);
            
            Assert.That(actualLanguage == p0, "Actual Language and Expected Language match");
            profilePageObj.verifyLanguage(driver, p0);
        }

        //Edit Language and Language Level

        [Given(@"Seller has Languages in Language section")]
        public void GivenSellerHasLanguagesInLanguageSection()
        {
            profilePageObj.verifyLanguage(driver, "Eng");
        }

        [When(@"Seller Edits Languages")]
        public void WhenSellerEditsLanguages()
        {
            profilePageObj.editLanguage(driver, "Eng", "Eng");
        }

        [Then(@"verify Seller can see the edited Languages in the Language section of Profile page")]
        public void ThenVerifySellerCanSeeTheEditedLanguagesInTheLanguageSectionOfProfilePage()
        {
            profilePageObj.verifyEditedLanguage(driver, "dummy");
        }


        //Delete Language
        [Given(@"Seller has Edited Languages in Language section")]
        public void GivenSellerHasEditedLanguagesInLanguageSection()
        {
            profilePageObj.verifyEditedLanguage(driver, "dummy");
        }

        [When(@"Seller Deletes Edited Languages")]
        public void WhenSellerDeletesEditedLanguages()
        {
            profilePageObj.deleteLanguage(driver, "dummy");
        }

        [Then(@"verify Seller can see the edited Languages deleted in the Language section of Profile page")]
        public void ThenVerifySellerCanSeeTheEditedLanguagesDeletedInTheLanguageSectionOfProfilePage()
        {
            profilePageObj.verifyDeletedLanguage(driver, "dummy");
        }

    }
}




    
