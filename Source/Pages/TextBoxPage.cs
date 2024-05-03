using DemoQA.Source.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Source.Pages
{
    public class TextBoxPage : Driver
    {

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _fullnameInput;
        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement _emailInput;
        [FindsBy(How = How.Id, Using = "currentAddress")]
        private IWebElement _currentAddressInput;
        [FindsBy(How = How.Id, Using = "permanentAddress")]
        private IWebElement _permanentAddressInput;
        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _submitBtn;
        [FindsBy(How = How.Id, Using = "output")]
        private IWebElement _resultBox;



        public TextBoxPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void TextBoxRegistration(string fullname, string email, string currentAddress, string pernamentAddress)
        {
            
            _driver.Manage().Window.Maximize();
            Thread.Sleep(500);
            _fullnameInput.SendKeys(fullname);
            _emailInput.SendKeys(email);
            _currentAddressInput.SendKeys(currentAddress);
            _permanentAddressInput.SendKeys(pernamentAddress);

            IWebElement submitButton = _driver.FindElement(By.Id("submit"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);

            _submitBtn.Click();
        }

        public Dictionary<string, string> GetResult()
        {
            // Assuming _resultBox.Text contains the formatted string
            string resultBoxContent = _resultBox.Text;

            // Split the content by "\r\n" to get individual lines
            string[] lines = resultBoxContent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Create a dictionary to store key-value pairs
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            // Process each line to extract key-value pairs
            foreach (string line in lines)
            {
                // Split each line by ":" to separate key and value
                string[] parts = line.Split(new char[] { ':' }, 2);

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();       // Trim whitespace from the key
                    string value = parts[1].Trim();     // Trim whitespace from the value

                    keyValuePairs[key] = value;         // Add key-value pair to the dictionary
                }
            }

            return keyValuePairs;
        }
    }
}
