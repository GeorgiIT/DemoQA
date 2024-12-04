using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages.Widgets_pages
{
    public class ElementsToolTips : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsToolTips()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Tool Tips']")]
        private readonly IWebElement toolTips;

        [FindsBy(How = How.Id, Using = "toolTipButton")]
        private readonly IWebElement buttonWithTooltip;

        [FindsBy(How = How.Id, Using = "toolTipTextField")]
        private readonly IWebElement textFieldWithTooltip;

        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-inner']")]
        private readonly IWebElement tooltip;

        public void HoverOverButtonWithTooltip()
        {
            helperMethod.elementScrollIntoView(toolTips);
            toolTips.Click();
            var script = "var event = new MouseEvent('mouseover', { bubbles: true }); arguments[0].dispatchEvent(event);";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, buttonWithTooltip);
            Thread.Sleep(5000);
        }

        public void HoverOverTextFieldWithTooltip()
        {
            helperMethod.elementScrollIntoView(toolTips);
            toolTips.Click();
            helperMethod.elementScrollIntoView(textFieldWithTooltip);
            var script = "var event = new MouseEvent('mouseover', { bubbles: true }); arguments[0].dispatchEvent(event);";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, textFieldWithTooltip);
            Thread.Sleep(5000);
        }

        public string GetTooltipText()
        {
            return tooltip.Text;
        }
    }

}
