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
    internal class ShareSkillTest : CommonDriver
    {
       
        [Test, Order(1), Description("Check if Seller is able to Add Skills with valid data")]
        public void AddSkill_Test()
        {
            try
            {
                test = extent.CreateTest("Add Skill Test");
                test.Log(Status.Info, "Add Skill Test Start");
                //Navigate to ShareSkillPage 
                HomePage homePageObj = new HomePage();
                homePageObj.navigateToShareSkill(driver);

                //Add Skills
                ShareSkillPage shareSkillObj = new ShareSkillPage();
                shareSkillObj.addListings(driver);
                takeScreenShot(driver);
                
                //Verify skill Added
                shareSkillObj.verifyAddSkill(driver);
                takeScreenShot(driver);
                
                string title = shareSkillObj.getTitle(driver);
                Assert.That(title == "Software Testing", "Test passed");
                test.Log(Status.Pass, "Add Skill Test Passed");
                
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test.Log(Status.Fail, "Add Skill Test Failed");
            }

        }
    }
}
