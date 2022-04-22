using AventStack.ExtentReports;
using NUnit.Framework;
using ProjectMARSIC.Pages;
using ProjectMARSIC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMARSIC.Tests
{
    [TestFixture]
    internal class ManageListingTest: CommonDriver
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

        [Test, Order(2), Description("Check if Seller is able to Edit Skills in Manage Listing")]
        public void EditSkill_Test()
        {
            try
            {
                
                test = extent.CreateTest("Edit Skill Test");
                test.Log(Status.Info, "Edit Skill Test Start");
                //Navigate to Manage Listing Page 
                HomePage homePageObj = new HomePage();
                homePageObj.navigateToManageListing(driver);

                //Edit skills
                ManageListingPage manageListingPageObj = new ManageListingPage();
                manageListingPageObj.editSkill(driver);

                //Verify Edit Success
                String editedTitle = manageListingPageObj.getEditedTitle(driver);
                Console.WriteLine(editedTitle);
                Assert.That(editedTitle == "Edit Software Testing", "Test Passed");
                takeScreenShot(driver);
                test.Log(Status.Pass, "Edit Skill Test Passed");
                
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test.Log(Status.Fail, "Edit Skill Test Failed");
            }
        }

        [Test, Order(3), Description("Check if Seller is able to Delete Skills in Manage Listing")]
        public void DeleteSkill_Test()
        {
            try
            {
            
            test = extent.CreateTest("Delete Skill Test");
            test.Log(Status.Info, "Delete Skill Test Start");

            //Delete skills
            ManageListingPage manageListingPageObj = new ManageListingPage();
            manageListingPageObj.deleteSkill(driver);
            takeScreenShot(driver);
            test.Log(Status.Pass, "Delete Skill Test Passed");
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test.Log(Status.Fail, "Delete Skill Test Failed");
            }
        }
    }
}
