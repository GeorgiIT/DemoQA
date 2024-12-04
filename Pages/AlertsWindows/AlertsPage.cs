using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.AlertsWindows
{
    public class AlertsPage: BaseSetup
    {
        public AlertsPage()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Alerts']")]
        private readonly IWebElement alerts;

        [FindsBy(How = How.Id, Using = "alertButton")]
        private readonly IWebElement alertButton;

        [FindsBy(How = How.Id, Using = "confirmButton")]
        private readonly IWebElement confirmButton;

        [FindsBy(How = How.Id, Using = "promtButton")]
        private readonly IWebElement promptButton;

        public void ClickAlertButton()
        {
            alerts.Click();
            new HelperMethods(driver).elementScrollIntoView(alertButton);
            alertButton.Click();
            // Wait for alert to appear and accept it
            driver.SwitchTo().Alert().Accept();
        }

        public void ClickConfirmButton()
        {
            alerts.Click(); 
            new HelperMethods(driver).elementScrollIntoView(confirmButton);
            confirmButton.Click();
            // Wait for alert to appear
            var alert = driver.SwitchTo().Alert();
            alert.Accept(); // You can also use alert.Dismiss() for cancelling
        }

        public string ClickPromptButton(string inputText)
        {
            alerts.Click();
            new HelperMethods(driver).elementScrollIntoView(promptButton);
            promptButton.Click();
            var alert = driver.SwitchTo().Alert();
            alert.SendKeys(inputText); // Enter text into the prompt
            alert.Accept(); // Accept the prompt

            // After accepting, retrieve any text from the webpage if necessary
            // This assumes there’s some confirmation text displayed on the page
            return driver.FindElement(By.Id("promptResult")).Text; // Update with the actual element
        }
    }
}
