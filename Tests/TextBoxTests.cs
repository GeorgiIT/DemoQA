using DemoQA.Source.Drivers;
using DemoQA.Source.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class TextBoxTests : Driver
    {
        private string _url = "https://demoqa.com/text-box";

         // TO DO more tests
        [Test]
        public void TextBox_WithValidData_ShouldSucceed()
        {
            _driver.Navigate().GoToUrl(_url);
            string fullname = "Georgi Todorov";
            string email = "georgiit98@gmail.com";
            string currentAddress = "Bulgaria Burgas";
            string permanentAddress = "Bulgaria Burgas"; // Remove leading space from "perAddress"

            // Instantiate TextBoxPage and perform registration
            TextBoxPage page = new TextBoxPage();
            page.TextBoxRegistration(fullname, email, currentAddress, permanentAddress);

            // Retrieve the result after registration
            Dictionary<string, string> result = page.GetResult();

            // Assert the expected values in the result dictionary
            Assert.That(result["Name"], Is.EqualTo(fullname), "Name should match");
            Assert.That(result["Email"], Is.EqualTo(email), "Email should match");
            Assert.That(result["Current Address"], Is.EqualTo(currentAddress), "Current Address should match");
            Assert.That(result["Permananet Address"], Is.EqualTo(permanentAddress), "Permanent Address should match");
        }
    }
}
