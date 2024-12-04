using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.Widgets_pages
{
    public class ElementsTabs : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsTabs()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Tabs']")]
        private readonly IWebElement tabs;

        [FindsBy(How = How.XPath, Using = "//div[@class='nav nav-tabs']")]
        private readonly IWebElement tabsContainer;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-what']//p")]
        private readonly IWebElement whatTabContent;

        [FindsBy(How = How.XPath, Using = "//*[@id='demo-tabpane-origin']//p[1]")]
        private readonly IWebElement originTabContent;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-use']//p")]
        private readonly IWebElement useTabContent;

        public void ClickWhatTab()
        {
            ClickTab("What");
        }

        public void ClickOriginTab()
        {
            ClickTab("Origin");
        }

        public void ClickUseTab()
        {
            ClickTab("Use");
        }

        private void ClickTab(string tabName)
        {
            helperMethod.elementScrollIntoView(tabs);
            tabs.Click();
            var tab = driver.FindElement(By.XPath($"//*[contains(@class, 'nav-tabs')]//a[text()='{tabName}']"));
            tab.Click();
        }

        private IWebElement GetTabContent(string tabName)
        {
            return tabName switch
            {
                "What" => whatTabContent,
                "Origin" => originTabContent,
                "Use" => useTabContent,
                _ => throw new ArgumentException("Invalid tab name")
            };
        }

        public string GetCurrentTabContent()
        {
            if (whatTabContent.Displayed) return whatTabContent.Text;
            if (originTabContent.Displayed) return originTabContent.Text;
            if (useTabContent.Displayed) return useTabContent.Text;
            return string.Empty;
        }
    }

}
