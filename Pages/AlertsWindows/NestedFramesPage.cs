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
    public class NestedFramesPage:BaseSetup
    {
        HelperMethods helperMethod;
        public NestedFramesPage()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Frames']")]
        private readonly IWebElement nestedFrames;

        [FindsBy(How = How.Id, Using = "frame1")]
        private readonly IWebElement parentFrame;

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@srcdoc, 'Child Iframe')]")]
        private readonly IWebElement childFrame;

        public void SwitchToParentFrame()
        {
            helperMethod.elementScrollIntoView(nestedFrames);
            nestedFrames.Click();
            helperMethod.elementScrollIntoView(parentFrame);
            driver.SwitchTo().Frame(parentFrame);
        }

        public void SwitchToChildFrame()
        {
            helperMethod.elementScrollIntoView(childFrame);
            driver.SwitchTo().Frame(childFrame);
        }

        public string GetTextFromParentFrame()
        {
            return driver.FindElement(By.XPath("//h1")).Text; 
        }

        public string GetTextFromChildFrame()
        {
            return driver.FindElement(By.XPath("//p[text()='Child Iframe']")).Text; 
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
