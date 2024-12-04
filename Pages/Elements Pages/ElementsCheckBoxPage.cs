

using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsCheckBoxPage : BaseSetup
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Check Box']")]
        private readonly IWebElement checkBoxTab;
        [FindsBy(How = How.XPath, Using = "//label[@for='tree-node-home']//span[@class='rct-checkbox']")]
        private readonly IWebElement homeCheckBox;
        [FindsBy(How = How.XPath, Using = "//span[text()= 'You have selected :']")]
        private readonly IWebElement checkedBoxMessage;

        public ElementsCheckBoxPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public ElementsCheckBoxPage clickCheckBoxTab()
        {
            checkBoxTab.Click();
            return this;
        }
        public ElementsCheckBoxPage clickCheckBoxHome()
        {
            homeCheckBox.Click();
            return this;
        }

        public ElementsCheckBoxPage verifyCheckBoxCheckedMessage()
        {
            Assert.That(checkedBoxMessage.Displayed, Is.True, "CheckBox is not checked please check!!!!");
            return this;
        }

    }
}
