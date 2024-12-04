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
    public class ElementsDatePicker : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsDatePicker()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Date Picker']")]
        private readonly IWebElement datePickerTab;

        [FindsBy(How = How.Id, Using = "datePickerMonthYearInput")]
        private readonly IWebElement dateInputField;


        public void OpenDatePicker()
        {
            helperMethod.elementScrollIntoView(datePickerTab);
            datePickerTab.Click();
            helperMethod.elementScrollIntoView(dateInputField);
            dateInputField.Clear();
            dateInputField.Click();
        }

        public void SelectDay(string day)
        {
            var dayElement = driver.FindElement(By.XPath($"//div[contains(@class, 'react-datepicker__day') and text()='{day}']"));
            dayElement.Click();
        }

        public string GetSelectedDate()
        {
            return dateInputField.GetAttribute("value");
        }
    }

}
