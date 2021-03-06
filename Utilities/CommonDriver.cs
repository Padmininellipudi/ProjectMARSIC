using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.Pages;
using System;
using System.IO;
using OpenQA.Selenium.Support;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;
using ProjectMARSIC.DataUtility;

namespace ProjectMARSIC.Utilities
{
    [TestFixture]
    public class CommonDriver
    {
        public IWebDriver driver;

        // Extent Report Setup
        public ExtentReports extent;
        public ExtentTest test;
        public ExtentHtmlReporter htmlReporter;
        public static string screenshotDirectory;
        
        [OneTimeSetUp]
        public void LoginFunction()
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

            extent = getInstance("1");
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            extent.Flush();
            driver.Quit();
        }

        public ExtentReports getInstance(String testCase)
        {
            string filePath = Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + "Results"
                + Path.DirectorySeparatorChar;

            htmlReporter = new ExtentHtmlReporter(filePath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }

        public void takeScreenShot(IWebDriver driver)
        {
            string screenshotFileName = Directory.GetParent(@"../../../").FullName
                 + Path.DirectorySeparatorChar + "Screenshots"
                 + Path.DirectorySeparatorChar + "Screentshot_" + DateTime.Now.ToString("ddMMyyyy HHmmss") + ".png";

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
        }
    }
}
