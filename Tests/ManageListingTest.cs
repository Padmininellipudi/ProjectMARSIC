using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMARSIC.DataUtility;
using ProjectMARSIC.Pages;
using ProjectMARSIC.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectMARSIC.Tests
{
    [TestFixture]
    public class ManageListingTest : CommonDriver
    {        
        ExcelUtility1 excelUtilityObj = new ExcelUtility1();
        HomePage homePageObj = new HomePage();
        ShareSkillPage shareSkillObj = new ShareSkillPage();
        ExtentReports rep;
        ExtentTest test1;

        [Test, Order(0), Description("Check if Seller is able to Add Skills with valid data")]
        public void AddSkill_Test1()
        {
            ShareSkillPage shareSkillObj = new ShareSkillPage();
            shareSkillObj.uploadFile("file1.txt");
        }


        [Test, Order(1), Description("Check if Seller is able to Add Skills with valid data")]
        public void AddSkill_Test()
        {
            try
            {
                test1 = extent.CreateTest("Add Skill Test");
                test1.Log(Status.Info, "Add Skill Test Start");
                excelUtilityObj.populateDataCollectionList();                                

                //Navigate to ShareSkillPage                
                homePageObj.navigateToShareSkill(driver);

                for (int i = 0; i < excelUtilityObj.TotalRows; i++)
                {
                    test1.Log(Status.Info, "Processing data from excel.\n Rownum " + i);
                    //Title
                    String title = excelUtilityObj.readSingleRowData(i, "TITLE");

                    //Description
                    String description = excelUtilityObj.readSingleRowData(i, "DESCRIPTION");

                    //Category
                    String category = excelUtilityObj.readSingleRowData(i, "CATEGORY");
                    //Subcategory
                    String subCategory = excelUtilityObj.readSingleRowData(i, "SUBCATEGORY");

                    //Tags
                    String serviceTag = excelUtilityObj.readSingleRowData(i, "SERVICETAG");
                    
                    //Service type
                    String serviceType = excelUtilityObj.readSingleRowData(i, "SERVICETYPE");

                    //Location type
                    String locationType = excelUtilityObj.readSingleRowData(i, "LOCATIONTYPE");

                    //Available Days
                    String startDate = excelUtilityObj.readSingleRowData(i, "STARTDATE");
                    String endDate = excelUtilityObj.readSingleRowData(i, "ENDDATE");

                    //Work Sample
                    String workSample = excelUtilityObj.readSingleRowData(i, "WORKSAMPLE");
                    
                    shareSkillObj.addListings(driver, title, description, category, subCategory, serviceTag, serviceType, locationType, startDate, endDate, workSample);

                    ManageListingPage manageListingPage = new ManageListingPage();
                    manageListingPage.navigateToShareSkill(driver);                                        
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test1.Log(Status.Fail, "Add Skill Test Failed");
            }
        }


        [Test, Order(2), Description("Check if Seller is able to Edit Skills in Manage Listing")]
        public void EditSkill_Test()
        {
            try
            {
                test1 = extent.CreateTest("Edit Skill Test");
                test1.Log(Status.Info, "Edit Skill Test Start");
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
                test1.Log(Status.Pass, "Edit Skill Test Passed");

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test1.Log(Status.Fail, "Edit Skill Test Failed");
            }
        }

        [Test, Order(3), Description("Check if Seller is able to Delete Skills in Manage Listing")]
        public void DeleteSkill_Test()
        {
            try
            {

                test1 = extent.CreateTest("Delete Skill Test");
                test1.Log(Status.Info, "Delete Skill Test Start");

                //Delete skills
                ManageListingPage manageListingPageObj = new ManageListingPage();
                manageListingPageObj.deleteSkill(driver);
                takeScreenShot(driver);
                test1.Log(Status.Pass, "Delete Skill Test Passed");
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                takeScreenShot(driver);
                test1.Log(Status.Fail, "Delete Skill Test Failed");
            }
        }
    }
}
