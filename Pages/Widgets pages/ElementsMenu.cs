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
    public class ElementsMenu : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsMenu()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Menu']")]
        private readonly IWebElement menuTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Main Item 1')]")]
        private readonly IWebElement mainItem1;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Main Item 2')]")]
        private readonly IWebElement mainItem2;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Main Item 3')]")]
        private readonly IWebElement mainItem3;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Main Item 2')]//following-sibling::ul")]
        private readonly IWebElement subMenu;

        public void ClickMainItem1()
        {
            helperMethod.elementScrollIntoView(menuTab);
            menuTab.Click();
            mainItem1.Click();
        }

        public void ClickMainItem2()
        {
            helperMethod.elementScrollIntoView(menuTab);
            menuTab.Click();
            Thread.Sleep(2000);
            mainItem2.Click();
            Thread.Sleep(5000);
        }

        public void ClickMainItem3()
        {
            helperMethod.elementScrollIntoView(menuTab);
            menuTab.Click();
            mainItem3.Click();
        }

        public bool IsSubMenuVisible()
        {
            try
            {
                return subMenu.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetSubMenuText()
        {
            return subMenu.Text;
        }
    }

}
