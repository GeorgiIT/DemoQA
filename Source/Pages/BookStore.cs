using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Source.Pages
{
    public class BookStore
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "searchBox")]
        private IWebElement _searchTextBox;
        [FindsBy(How = How.ClassName, Using = "rt-tbody")]
        private IWebElement _searchBoxResults;

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement _loginBtn;


        public BookStore(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void SearchBox(string searchText)
        {
            _searchTextBox.SendKeys(searchText);
        }

        public (string, string, string) GetSearchResultsText()
        {
            // Get the raw text from _searchBoxResults
            string rawText = _searchBoxResults.Text;

            // Split the text by new line ("\r\n")
            string[] parts = rawText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Ensure we have at least three parts (Title, Author, Publisher)
            if (parts.Length >= 3)
            {
                string title = parts[0].Trim();       // First part is the Title
                string author = parts[1].Trim();      // Second part is the Author
                string publisher = parts[2].Trim();   // Third part is the Publisher

                return (title, author, publisher);
            }
            else
            {
                // If the format is invalid or doesn't contain enough parts
                return ("Invalid book information", "", "");
            }
        }


    }
}