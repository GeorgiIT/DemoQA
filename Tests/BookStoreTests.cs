using DemoQA.Source.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DemoQA.Source.Drivers;

namespace DemoQA.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class BookStoreTests : Driver
    {
        private IWebDriver _webDriver;
        private string _url = "https://demoqa.com/books";

        // TO DO more tests
        [Test]
        public void SearchBook_WithExistingSearch_ShouldSucceed()
        {
            BookStore bs = new BookStore();
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
        [Test]
        public void SearchBook_WithNonExistingInput_ShouldFail()
        {
            BookStore bs = new BookStore();
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);
            bs.SearchBox("some non existing book");

            // Get the title, author, and publisher from the search results
            (string title, string author, string publisher) = bs.GetSearchResultsText();

            // Assert that the retrieved title, author, and publisher match the expected values
            Assert.That(title, Is.EqualTo("The book is not found"), "Title should match the expected else condition");
            Assert.That(author, Is.EqualTo(""), "Author should be empty string");
            Assert.That(publisher, Is.EqualTo(""), "Publisher should be empty string");

        }
        [Test]
        public void SearchBook_WithMultipleResults_ShouldSucceed()
        {
            BookStore bs = new BookStore();
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);
            bs.SearchBox("design");

            // Get the list of titles, authors, and publishers from the search results
            List<(string title, string author, string publisher)> searchResults = bs.GetSearchMultipleResultsText();

            // Assert that at least one book result is returned
            Assert.That(searchResults.Count, Is.GreaterThan(0), "Expected at least one book result");

            // Check each search result to find the expected book
            bool foundExpectedBook = false;
            foreach (var result in searchResults)
            {
                string title = result.title;
                string author = result.author;
                string publisher = result.publisher;

                // Check if the current book matches the expected values
                if (title == "Learning JavaScript Design Patterns" &&
                    author == "Addy Osmani" &&
                    publisher == "O'Reilly Media")
                {
                    foundExpectedBook = true;
                    break; // Stop searching once the expected book is found
                }
            }

            // Assert that the expected book was found in the search results
            Assert.That(foundExpectedBook, Is.True, "Expected book not found in the search results");
        }


    }
}