using DemoQA.Basic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsRadioButtonPage: BaseSetup
    {

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Radio Button']")]
        private readonly IWebElement radioButtonTab;
        [FindsBy(How = How.XPath, Using = "//label[text()= 'Yes']")]
        private readonly IWebElement radioButtonToSelect;
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'You have selected') and contains(., 'Yes')]")]
        private readonly IWebElement verifyRadioButtonMessage;


        public ElementsRadioButtonPage()
        {
            PageFactory.InitElements(driver, this);
        }
        public ElementsRadioButtonPage clickRadioButtonTab()
        {
            radioButtonTab.Click();
            return this;
        }
        public ElementsRadioButtonPage clickRadioButtonYes()
        {
            radioButtonToSelect.Click();
            Thread.Sleep(10000);
            return this;
        }
        public ElementsRadioButtonPage verifyRadioButtonYesIsSelected()
        {
            Assert.That(verifyRadioButtonMessage.Displayed,Is.True, "Radio button is not clicked please check!!!!");
            return this;
        }
    }
}
