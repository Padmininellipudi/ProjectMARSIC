using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMARSIC.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login page object Initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.loginSteps(driver);
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
