using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Source.Pages
{
    public class HomePage
    {
        private string _url = "https://demoqa.com/";
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
