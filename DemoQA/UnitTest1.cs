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
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void  testingMenuOpeningsAndUrls()
        {
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1) > div > div.avatar.mx-auto.white")).Click();
            Thread.Sleep(1000);
            string randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/text()")).Text;

            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/elements");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            //Forms page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(2) > div > div.avatar.mx-auto.white")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/text()")).Text;

            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/forms");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            //AlertsWindows page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(3) > div > div.card-up")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/text()")).Text;

            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/alertsWindows");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");


            //Widgets page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(4) > div > div.card-body")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/text()")).Text;

            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/widgets");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            //Interaction page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5) > div > div.avatar.mx-auto.white > svg")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/text()")).Text;

            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/interaction");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            //books page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(6) > div > div.card-up")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[1]/div")).Text;
            driver.Navigate().Back();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://demoqa.com/books");
            Assert.AreEqual(randomTextFromThePage, "Book Store");



        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}