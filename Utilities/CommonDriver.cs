using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.Pages;

namespace ProjectMARSIC.Utilities
{
    [TestFixture]
    public class CommonDriver
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        protected void LoginFunction()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login page object Initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.loginSteps(driver);

            //Check if user is logged in successfully
            HomePage homePageObj = new HomePage();
            homePageObj.verifyLoginSuccess(driver);
            homePageObj.navigateToProfilePage(driver);
        }

        [OneTimeTearDown]
        protected void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
