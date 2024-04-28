using DemoQA.Source.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;


namespace DemoQA.Tests
{
    public class RegistrationPageTests
    {
        private IWebDriver _driver;
        private string _url = "https://demoqa.com/register";

        [OneTimeSetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }
        // I need to find a way to deal with CAPTCHA

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}