using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMARSIC.Pages
{
    internal class LoginPage
    {
        public void loginSteps(IWebDriver driver)
        {
            //Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            try
            {
                //Click Sign Button
                IWebElement linkSignIn = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
                linkSignIn.Click();
                Thread.Sleep(2000);

                //Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Name("email"));
                usernameTextbox.SendKeys("paddu.nellipudi@gmail.com");

                //Identify password textbox and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
                passwordTextbox.SendKeys("paddusrinu");
                                
                //Click on Login button
                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                loginButton.Click();
                Thread.Sleep(3000);

            }
            catch (Exception ex)
            {
                Assert.Fail("Mars portal Login not successful", ex.Message);
                throw;
            }
            
        }

        internal void LoginSteps(object driver)
        {
            throw new NotImplementedException();
        }
    }
}
