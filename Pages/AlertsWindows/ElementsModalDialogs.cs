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
    public class ElementsModalDialogs:BaseSetup
    {

        public ElementsModalDialogs()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Modal Dialogs']")]
        private readonly IWebElement modalDialogs;

        [FindsBy(How = How.Id, Using = "showSmallModal")]
        private readonly IWebElement smallModalButton;

        [FindsBy(How = How.Id, Using = "showLargeModal")]
        private readonly IWebElement largeModalButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'example-modal-sizes-title')]")]
        private readonly IWebElement modalHeader;

        [FindsBy(How = How.ClassName, Using = "close")]
        private readonly IWebElement closeButton;

        public void OpenSmallModal()
        {
            new HelperMethods(driver).elementScrollIntoView(modalDialogs);
            modalDialogs.Click();
            smallModalButton.Click();
        }

        public void OpenLargeModal()
        {
            new HelperMethods(driver).elementScrollIntoView(modalDialogs);
            modalDialogs.Click();
            largeModalButton.Click();
        }

        public string GetModalHeaderText()
        {
            return modalHeader.Text;
        }

        public void CloseModal()
        {
            closeButton.Click();
        }
    }

}
