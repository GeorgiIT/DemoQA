using DemoQA.Source.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using DemoQA.Source.Drivers;


namespace DemoQA.Tests
{
    public class RegistrationPageTests : Driver
    {
        private string _url = "https://demoqa.com/register";
        // I need to find a way to deal with CAPTCHA
    }
}