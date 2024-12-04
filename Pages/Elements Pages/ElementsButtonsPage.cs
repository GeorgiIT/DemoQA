using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsButtonsPage: BaseSetup
    {
        HelperMethods helperMethods;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Buttons']")]
        private readonly IWebElement buttonsTab;
        [FindsBy(How = How.Id, Using = "doubleClickBtn")]
        private readonly IWebElement doubleClickButton;
        [FindsBy(How = How.Id, Using = "rightClickBtn")]
        private readonly IWebElement rightClickButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Click Me']")]
        private readonly IWebElement dynamicClickButton;
        [FindsBy(How = How.Id, Using = "doubleClickMessage")]
        private readonly IWebElement doubleClickedSuccessMessage;
        [FindsBy(How = How.Id, Using = "rightClickMessage")]
        private readonly IWebElement rightClickSuccessMessage;
        [FindsBy(How = How.Id, Using = "dynamicClickMessage")]
        private readonly IWebElement dynamicClickSuccessMessage;


        public ElementsButtonsPage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        public ElementsButtonsPage clickButtonTabs()
        {
            buttonsTab.Click();
            return this;
        }
        public ElementsButtonsPage clickDoubleClickButton()
        {
            new Actions(driver).DoubleClick(doubleClickButton).Perform();
            Thread.Sleep(2000);
            return this;
        }

        public ElementsButtonsPage verifyDoubleClickedMessageDisplayed()
        {
            Assert.That(doubleClickedSuccessMessage.Displayed, Is.True, "DoubleClick is not clicked please check!!!!");
            return this;
        }

        public ElementsButtonsPage clickRightClickButton()
        {
            helperMethods.elementScrollIntoView(rightClickButton);
            new Actions(driver).MoveToElement(rightClickButton).ContextClick().Perform();
            Thread.Sleep(2000);
            return this;
        }
        
        public ElementsButtonsPage verifyRightClickedMessageDisplayed()
        {
            helperMethods.elementScrollIntoView(rightClickSuccessMessage);
            Assert.That(rightClickSuccessMessage.Displayed, Is.True, "Right Click button is not clicked please check!!!!");
            return this;
        }
        public ElementsButtonsPage clickDynamicClickButton()
        {
            helperMethods.elementScrollIntoView(dynamicClickButton);
            dynamicClickButton.Click();
            Thread.Sleep(2000);
            return this;
        }

        public ElementsButtonsPage verifyDynamicClickedMessageDisplayed()
        {
            Assert.That(dynamicClickSuccessMessage.Displayed, Is.True, "dynamic Click button is not clicked please check!!!!");
            return this;
        }
    }
}
