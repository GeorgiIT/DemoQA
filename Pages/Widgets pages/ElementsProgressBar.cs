using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.Widgets_pages
{
    public class ElementsProgressBar : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsProgressBar()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Progress Bar']")]
        private readonly IWebElement progressBarTab;

        [FindsBy(How = How.Id, Using = "startStopButton")]
        private readonly IWebElement startStopButton;

        [FindsBy(How = How.Id, Using = "resetButton")]
        private readonly IWebElement resetButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='progressbar']")]
        private readonly IWebElement progressBar;

        public void StartProgressBar()
        {
            helperMethod.elementScrollIntoView(progressBarTab);
            progressBarTab.Click();
            helperMethod.elementScrollIntoView(startStopButton);
            startStopButton.Click();
        }

        public void ResetProgressBar()
        {
            resetButton.Click();
        }

        public string GetProgressBarValue()
        {
            return progressBar.GetAttribute("aria-valuenow"); // Get the current value of the progress bar
        }
    }

}
