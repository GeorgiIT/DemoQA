using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace DemoQA
{
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "/Users/georgi/Desktop/Google Chrome.app/Contents/MacOS/Google Chrome";
            // for mac "/Users/georgi/Desktop/Google Chrome.app/Contents/MacOS/Google Chrome"
            // for win "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void testingMenuOpeningsAndUrls()
        {
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);
            string randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;


            Assert.AreEqual(driver.Url, "https://demoqa.com/elements");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);




            //Forms page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(2)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/forms");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);



            //AlertsWindows page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(3)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/alertsWindows");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);


            //Widgets page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(4)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/widgets");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);



            //Interaction page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/interaction");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);


            //books page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(6)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.pattern-backgound.playgound-header > div")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/books");
            Assert.AreEqual(randomTextFromThePage, "Book Store");

            driver.Navigate().Back();
            Thread.Sleep(1000);



        }

        [Test]
        public void elements_TextBoxFormRegistrationWithCorrectData()
        {
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(1000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));
            bool textButtonShowed = elementsOptions.Displayed;
            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            driver.FindElement(By.Id("item-0")).Click();

            string name = "Georgi Todorov";
            string email = "georgiit98@gmail.com";
            string currentAddress = "Burgas, Bulgaria";
            string permanentAddress = "Burgas, Bulgaria";
            //Filling the form data

            driver.FindElement(By.Id("userName")).SendKeys(name);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);

            //button with frame
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitButton);

            Thread.Sleep(1000);

            string actualStoredName = driver.FindElement(By.Id("name")).Text;
            string actualStoredEmail = driver.FindElement(By.Id("email")).Text;
            

            // Wait for the "currentAddress" field to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Wait for the "currentAddress" field to be visible and enabled
            IWebElement currentAddressField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("currentAddress")));
            wait.Until(d => currentAddressField.Enabled && !string.IsNullOrEmpty(currentAddressField.GetAttribute("value")));

            // Access the "currentAddress" field
            string actualStoredCurrentAddress = currentAddressField.GetAttribute("value");


            // permanent
            IWebElement permanentAddressField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("permanentAddress")));
            wait.Until(d => permanentAddressField.Enabled && !string.IsNullOrEmpty(currentAddressField.GetAttribute("value")));

            // Access the "currentAddress" field
            string actualStoredPermanentAddress = permanentAddressField.GetAttribute("value");

            //test
            Assert.That(actualStoredName.Contains(name));
            Assert.That(actualStoredEmail.Contains(email));
            Assert.That(actualStoredCurrentAddress.Contains(currentAddress));
            Assert.That(actualStoredPermanentAddress.Contains(permanentAddress));
        }




        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}