using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Xml.Linq;


namespace DemoQA.Pages
{
    public class HomePage: BaseSetup
    {
        HelperMethods helperMethods;
        String ecpectedElementsUrl = "https://demoqa.com/elements";

        [FindsBy(How = How.XPath, Using = "//h5[text()='Elements']")]
        private readonly IWebElement elements;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Forms']")]
        private readonly IWebElement forms;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Alerts, Frame & Windows']")]
        private readonly IWebElement alertsWindows;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Widgets']")]
        private readonly IWebElement widgets;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Book Store Application']")]
        private readonly IWebElement bookStoreApplication;

        public HomePage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        public HomePage clickElementTab() {
            helperMethods.elementScrollIntoView(elements);
            elements.Click();
            Thread.Sleep(5000);
            return this;
        }

        public HomePage verifyElementPage()
        {
            String actualUrl = driver.Url.ToString();
            Assert.That(actualUrl, Is.EqualTo(ecpectedElementsUrl));
            return this;


        }
        public HomePage clickFormsTab()
        {
            helperMethods.elementScrollIntoView(forms);
            forms.Click();
            return this;
        }
        public HomePage clickAlertsTab()
        {
            helperMethods.elementScrollIntoView(alertsWindows);
            alertsWindows.Click();
            Thread.Sleep(5000);
            return this;
        }
        public HomePage clickWidgetsTab()
        {
            helperMethods.elementScrollIntoView(widgets);
            widgets.Click();
            Thread.Sleep(5000);
            return this;
        }

        public HomePage clickBookStoreTab()
        {
            helperMethods.elementScrollIntoView(bookStoreApplication);
            bookStoreApplication.Click();
            Thread.Sleep(5000);
            return this;
        }
    }
}
