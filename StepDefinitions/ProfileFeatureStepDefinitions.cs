using System;
using ProjectMARSIC.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ProjectMARSIC.Pages;

namespace ProjectMARSIC.StepDefinitions
{
    [Binding]
    public class ProfileFeatureStepDefinitions: CommonDriver
    {
        // Initializing Page Objects
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        ProfilePage profilePageObj = new ProfilePage();

        //Login

        [Given(@"Seller is in Home Page")]
        public void GivenSellerIsInHomePage()
        {
            driver = new ChromeDriver();
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

        //Languages

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
        public void WhenSellerInputsLanguageAndLevel()
        {
            profilePageObj.addLanguage(driver);
        }

        [When(@"clicks Add button")]
        public void WhenClicksAddButton()
        {
            profilePageObj.addLanguage(driver);
        }

        [Then(@"verify Seller can see the added languages in the Language section of Profile page")]
        public void ThenVerifySellerCanSeeTheAddedLanguagesInTheLanguageSectionOfProfilePage()
        {
            
            String actualLanguage = profilePageObj.getLanguage(driver);
            String actualLanguageLevel = profilePageObj.getLanguageLevel(driver);
            
            Assert.That(actualLanguage == "English", "Actual Language and Expected Language do not match");
            Assert.That(actualLanguageLevel == "Basic", "Actual Language Level and Expected Language Level do not match");
            
            //profilePageObj.verifyLanguage(driver);
        }
                    
    }
}
