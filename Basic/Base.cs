using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;


namespace DemoQA.Basic
{
    public class BaseSetup
    {
        [ThreadStatic]

        public static IWebDriver driver;
        [SetUp]
        public void Start_Browser()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void SetTestResults()
        {
            driver.Dispose();
        }

    }
}
