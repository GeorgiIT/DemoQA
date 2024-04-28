using DemoQA.Source.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA.Tests
{
    public class BookStoreTests
    {
        private IWebDriver _driver;
        private string _url = "https://demoqa.com/books";

        [OneTimeSetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        // TO DO more tests
        [Test]
        public void SearchBook_WithExistingSearch_ShouldSucceed()
        {
            BookStore bs = new BookStore(_driver);
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);
            bs.SearchBox("You Don't Know JS");

            // Get the title, author, and publisher from the search results
            (string title, string author, string publisher) = bs.GetSearchResultsText();

            // Assert that the retrieved title, author, and publisher match the expected values
            Assert.That(title, Is.EqualTo("You Don't Know JS"), "Title should match the expected value");
            Assert.That(author, Is.EqualTo("Kyle Simpson"), "Author should match the expected value");
            Assert.That(publisher, Is.EqualTo("O'Reilly Media"), "Publisher should match the expected value");

        }





        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}