using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsBrokenLinksPage:BaseSetup
    {
        HelperMethods helperMethods;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Broken Links - Images']")]
        private readonly IWebElement Brokenlinks;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Click Here for Valid Link']")]
        private readonly IWebElement validLink;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Click Here for Broken Link']")]
        private readonly IWebElement brokenLink;

        public ElementsBrokenLinksPage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }


        public ElementsBrokenLinksPage clickBrokenLinksTabs()
        {
            helperMethods.elementScrollIntoView(Brokenlinks);
            Brokenlinks.Click();
            Thread.Sleep(2000);
            return this;
        }
        // Click and verify methods
        public ElementsBrokenLinksPage ClickBrokenLinkAndVerifyUrl()
        {
            helperMethods.elementScrollIntoView(brokenLink);
            brokenLink.Click();
            Thread.Sleep(2000);
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/status_codes/500"), "URL does not match for Broken Link");
            return this;
        }

        public ElementsBrokenLinksPage ClickValidLinkAndVerifyUrl()
        {
            helperMethods.elementScrollIntoView(validLink);
            validLink.Click();
            Thread.Sleep(2000);
            Assert.That(driver.Url, Is.EqualTo("https://demoqa.com/"), "URL does not match for Valid Link");
            return this;
        }

        private void SwitchToNewTab()
        {
            var newWindowHandle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newWindowHandle);
        }
    }
}
