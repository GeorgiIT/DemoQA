using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using DemoQA.Source.Pages;
using DemoQA.Source.Drivers;

namespace DemoQA.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : Driver
    {

        private string _url = "https://demoqa.com/login";
        private string profileURL = "https://demoqa.com/profile";

        // TO DO more tests
        [Order(1)]
        [Test]
        public void LoginIntoBookStore_WithInvalidCredentials_ShouldFail()
        {
            string username = "SomeRandomUser123";
            string password = "SomeRandomPass123";
            LoginPage page = new LoginPage();
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);
            string result = page.LoginAndCatchingTheErrorMsg(username, password);

            Assert.That(result, Is.EqualTo("Invalid username or password!"));
        }
        [Order(2)]
        [Test]
        public void LoginInBookStore_WithValidCredentials_ShouldSucceed()
        {
            string username = "Geo333";
            string password = "Georgi!123";
            LoginPage page = new LoginPage();
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);
            page.Login(username, password);
            Thread.Sleep(2000);

            Assert.That(_driver.Url, Is.EqualTo(profileURL));
        }
    }
}