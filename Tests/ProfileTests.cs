using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.Pages;
using System;
using System.Threading;

namespace ProjectMARSIC
{
    internal class ProfileTests
    {
        static void Main(string[] args)
        {
            //Open Chrome Browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
           
            LoginPage loginPageObj = new LoginPage();
            HomePage homePageObj = new HomePage();
            ProfilePage profilePageObj = new ProfilePage();

            // Login
            loginPageObj.loginSteps(driver);

            //Check if user is logged in successfully
            homePageObj.verifyLoginSuccess(driver);

            //Go to Profile Page
            homePageObj.navigateToProfilePage(driver);


            //Add Language
            profilePageObj.navigateToLanguagesTab(driver);
            profilePageObj.addLanguage(driver);

            //Verify Language Added
            profilePageObj.verifyLanguage(driver);

            //Quit Browser
            driver.Quit();
        }
    }
}
