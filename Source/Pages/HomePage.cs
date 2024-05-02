using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Source.Drivers;
using SeleniumExtras.PageObjects;

namespace DemoQA.Source.Pages
{
    public class HomePage : Driver
    {
        private string _url = "https://demoqa.com/";
        private IWebDriver _webDriver;
        public HomePage()
        {
            PageFactory.InitElements(_driver, this);
        }
    }
}
