using DemoQA.Pages.Book_StorePages;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;

namespace DemoQA.Tests.Book_Store_Tests
{
    internal class ElementsLoginTests: BaseSetup
    {
        [Test]
        public void VerifySuccessfulLogin()
        {
            new HomePage().clickBookStoreTab();
            var loginPage = new ElementsLogin();

            loginPage.clickLoginTab();
            // Enter valid credentials
            loginPage.EnterUsername("Geo333");
            loginPage.EnterPassword("Georgi!123"); 
            loginPage.ClickLogin();

            loginPage.verifyLogin();
        }

        [Test]
        public void VerifyUnsuccessfulLogin()
        {
            new HomePage().clickBookStoreTab();
            var loginPage = new ElementsLogin();

            loginPage.clickLoginTab();
            // Enter invalid credentials
            loginPage.EnterUsername("wronguser");
            loginPage.EnterPassword("wrongpassword");
            loginPage.ClickLogin();
            // Verify error message
            string errorMessage = loginPage.GetErrorMessage();
            Assert.That(errorMessage, Is.EqualTo("Invalid username or password!"), "The error message is incorrect.");
        }

    }
}
