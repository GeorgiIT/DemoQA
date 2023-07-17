using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            // for mac "/Users/georgi/Desktop/Google Chrome.app/Contents/MacOS/Google Chrome"
            // for win "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void  testingMenuOpeningsAndUrls()
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

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}