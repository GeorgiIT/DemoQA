using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQA.Pages.AlertWindows

{
    public class ElementsBrowserWindows:BaseSetup
    {
        HelperMethods helperMethod;

        public ElementsBrowserWindows()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Browser Windows']")]
        private readonly IWebElement browserWindows;

        [FindsBy(How = How.Id, Using = "windowButton")]
        private readonly IWebElement newWindowButton;

        [FindsBy(How = How.Id, Using = "tabButton")]
        private readonly IWebElement newTabButton;

        [FindsBy(How = How.Id, Using = "messageWindowButton")]
        private readonly IWebElement messageWindowButton;

        public void ClickNewTab()
        {
            browserWindows.Click();
            helperMethod.elementScrollIntoView(newTabButton);
            newTabButton.Click();
            SwitchToNewTab();
        }

        public void ClickNewWindow()
        {
            browserWindows.Click();
            helperMethod.elementScrollIntoView(newWindowButton);
            newWindowButton.Click();
            SwitchToNewWindow();
        }

        public void ClickMessageWindow()
        {
            browserWindows.Click();

            helperMethod.elementScrollIntoView(messageWindowButton);
            messageWindowButton.Click();
            SwitchToNewWindow();
        }

        private void SwitchToNewTab()
        {
            var newTabHandle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newTabHandle);
        }

        private void SwitchToNewWindow()
        {
            var newWindowHandle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newWindowHandle);
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }
    }

}
