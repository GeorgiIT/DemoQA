using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Source.Pages
{
    public class ProfilePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "searchBox")]
        private IWebElement _searchTextBox;
        [FindsBy(How = How.ClassName, Using = "rt-tbody")]
        private IWebElement _searchBoxResults;
        // to do buttons
    }
}