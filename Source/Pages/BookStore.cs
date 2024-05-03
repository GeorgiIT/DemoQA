using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Source.Drivers;

namespace DemoQA.Source.Pages
{
    public class BookStore : Driver
    {

        [FindsBy(How = How.Id, Using = "searchBox")]
        private IWebElement _searchTextBox;
        [FindsBy(How = How.ClassName, Using = "rt-tbody")]
        private IWebElement _searchBoxResults;

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement _loginBtn;


        public BookStore()
        {
            PageFactory.InitElements(_driver, this);
        }
        public void SearchBox(string searchText)
        {
            _searchTextBox.SendKeys(searchText);
        }

        public (string, string, string) GetSearchResultsText()
        {
            string title;
            string author;
            string publisher;

            if (_searchBoxResults == null)
            {
                return ("null result", "", ""); // Returning a tuple containing strings
            }

            // Get the raw text from _searchBoxResults
            string rawText = _searchBoxResults.Text;

            

            // Split the text by new line ("\r\n")
            string[] parts = rawText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Ensure we have at least three parts (Title, Author, Publisher)
            if (parts.Length >= 3)
            {
                title = parts[0].Trim();       // First part is the Title
                author = parts[1].Trim();      // Second part is the Author
                publisher = parts[2].Trim();   // Third part is the Publisher

                return (title, author, publisher);
            }
            else
            {
                // If the format is invalid or doesn't contain enough parts
                return ("The book is not found", "", "");
            }
        }

        public List<(string title, string author, string publisher)> GetSearchMultipleResultsText()
        {
            if (_searchBoxResults == null)
            {
                return new List<(string, string, string)>(); // Return empty list for null search results
            }

            string rawText = _searchBoxResults.Text;
            string[] parts = rawText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<(string title, string author, string publisher)> results = new List<(string, string, string)>();

            for (int i = 0; i < parts.Length; i += 3)
            {
                if (i + 2 < parts.Length)
                {
                    string title = parts[i].Trim();
                    string author = parts[i + 1].Trim();
                    string publisher = parts[i + 2].Trim();

                    results.Add((title, author, publisher));
                }
            }

            return results;
        }
    }
}