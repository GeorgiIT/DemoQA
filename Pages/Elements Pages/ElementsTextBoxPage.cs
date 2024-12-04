using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages
{
    public class ElementsTextBoxPage: BaseSetup
    {
        HelperMethods helperMethods;

        //TextBoxes
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Text Box']")]
        private readonly IWebElement textBoxTab;
        [FindsBy(How = How.Id, Using = "userName")]
        private readonly IWebElement fullnameInput;
        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement emailInput; 
        [FindsBy(How = How.Id, Using = "currentAddress")]
        private IWebElement currentAddressInput;
        [FindsBy(How = How.Id, Using = "permanentAddress")]
        private readonly IWebElement permanentAddressInput;
        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement submitButton;
        [FindsBy(How = How.Id, Using = "output")]
        private readonly IWebElement resultBox;
        
        public ElementsTextBoxPage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        public void TextBoxRegistrationForm(string fullname, string email, string currentAddress, string pernamentAddress) {
            textBoxTab.Click();
            helperMethods.implicitWait(5);
            fullnameInput.SendKeys(fullname);
            emailInput.SendKeys(email);
            currentAddressInput.SendKeys(currentAddress);
            permanentAddressInput.SendKeys(pernamentAddress);
            helperMethods.elementScrollIntoView(submitButton);
            submitButton.Click();

        }
        public Dictionary<string, string> GetResult()
        {
            // Assuming _resultBox.Text contains the formatted string
            string resultBoxContent = resultBox.Text;

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
