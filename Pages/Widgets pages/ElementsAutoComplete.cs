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
    public class ElementsAutoComplete : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsAutoComplete()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Auto Complete']")]
        private readonly IWebElement autoCompleteTab;

        [FindsBy(How = How.Id, Using = "autoCompleteSingleInput")]
        private readonly IWebElement singleInputField;

        [FindsBy(How = How.Id, Using = "autoCompleteMultipleInput")]
        private readonly IWebElement multipleInputField;

        [FindsBy(How = How.XPath, Using = "//div[@class='auto-complete__menu']")]
        private readonly IWebElement autoCompleteMenu;

        public void EnterSingleInput(string input)
        {
            helperMethod.elementScrollIntoView(autoCompleteTab);
            autoCompleteTab.Click();
            helperMethod.elementScrollIntoView(singleInputField);
            singleInputField.Clear();
            Thread.Sleep(2000);
            singleInputField.SendKeys(input);
            Thread.Sleep(2000);
        }

        public void EnterMultipleInput(string input)
        {
            helperMethod.elementScrollIntoView(autoCompleteTab);
            autoCompleteTab.Click();
            helperMethod.elementScrollIntoView(multipleInputField);
            multipleInputField.Clear();
            multipleInputField.SendKeys(input);
        }

        public void SelectAutoCompleteOption(string optionText)
        {
            var option = driver.FindElement(By.XPath($"//div[contains(@class,'auto-complete__menu')]//div[text()='{optionText}']"));
            helperMethod.elementScrollIntoView(option);
            option.Click();
        }
    }

}
