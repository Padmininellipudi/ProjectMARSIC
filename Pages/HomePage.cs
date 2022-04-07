using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ProjectMARSIC.Pages
{
    internal class HomePage
    {
        public void goToProfilePage(IWebDriver driver)
        {
            //Go to Profile Page
            IWebElement linkProfile = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]"));
            linkProfile.Click();
            Thread.Sleep(3000);
        }

        public void verifyLoginSuccess(IWebDriver driver)
        {
            IWebElement hipadmini = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
            if (hipadmini.Text == "Hi Padmini")
            {
                Console.WriteLine("Logged in successfully, Test Passed");                
            }
            else
            {
                Console.WriteLine("Login Failed, Test Failed");               
            }
        }

        public void navigateToProfilePage(IWebDriver driver)
        {
            //Identify Hi Padmini link and select Go to Profile
            IWebElement hiPadminiDropdownLink = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
            hiPadminiDropdownLink.Click();
            Thread.Sleep(3000);

            IWebElement goToProfileOption = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[1]"));
            goToProfileOption.Click();
            Thread.Sleep(3000);
        }
    }
}
