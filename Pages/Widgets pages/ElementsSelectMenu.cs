using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.Widgets_pages
{
    public class ElementsSelectMenu : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsSelectMenu()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Select Menu']")]
        private readonly IWebElement selectMenu;

        [FindsBy(How = How.Id, Using = "oldSelectMenu")]
        public readonly IWebElement oldSelectMenu;

        [FindsBy(How = How.Id, Using = "react-select-2-input")]
        private readonly IWebElement newSelectMenu;

        [FindsBy(How = How.XPath, Using = "//div[@id='react-select-2-option-0']")]
        private readonly IWebElement firstOption;

        [FindsBy(How = How.XPath, Using = "//div[@id='react-select-2-option-1']")]
        private readonly IWebElement secondOption;

        [FindsBy(How = How.XPath, Using = "//div[@id='react-select-2-option-2']")]
        private readonly IWebElement thirdOption;

        public void SelectOldMenuOption(string option)
        {
            helperMethod.elementScrollIntoView(selectMenu);
            selectMenu.Click();
            helperMethod.elementScrollIntoView(oldSelectMenu);
            var selectElement = new SelectElement(oldSelectMenu);
            selectElement.SelectByText(option);
            Thread.Sleep(10000);
        }

        public void SelectNewMenuOption(string option)
        {
            newSelectMenu.Click();

            // Click the desired option based on the provided text
            if (option.Equals("Option 1"))
                firstOption.Click();
            else if (option.Equals("Option 2"))
                secondOption.Click();
            else if (option.Equals("Option 3"))
                thirdOption.Click();
        }
    }

}
