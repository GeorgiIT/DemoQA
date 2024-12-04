using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQA.Pages.Widgets_pages
{
    public class ElementsAccordion: BaseSetup
    {
        HelperMethods helperMethod;

        public ElementsAccordion()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Accordian']")]
        private readonly IWebElement accordian;

        [FindsBy(How = How.XPath, Using = "//div[@id='section1Heading']")]
        private readonly IWebElement firstAccordionHeader;

        [FindsBy(How = How.XPath, Using = "//div[@id='section2Heading']")]
        private readonly IWebElement secondAccordionHeader;

        [FindsBy(How = How.XPath, Using = "//div[@id='section3Heading']")]
        private readonly IWebElement thirdAccordionHeader;

        [FindsBy(How = How.XPath, Using = "//div[@id='section1Content']")]
        private readonly IWebElement firstAccordionContent;

        [FindsBy(How = How.XPath, Using = "//div[@id='section2Content']")]
        private readonly IWebElement secondAccordionContent;

        [FindsBy(How = How.XPath, Using = "//div[@id='section3Content']")]
        private readonly IWebElement thirdAccordionContent;

        public void ClickFirstAccordion()
        {
            helperMethod.elementScrollIntoView(accordian);
            accordian.Click();
            helperMethod.elementScrollIntoView(firstAccordionHeader);
            firstAccordionHeader.Click();
        }

        public void ClickSecondAccordion()
        {
            helperMethod.elementScrollIntoView(accordian);
            accordian.Click();
            helperMethod.elementScrollIntoView(secondAccordionHeader);
            secondAccordionHeader.Click();
            Thread.Sleep(2000);

        }

        public void ClickThirdAccordion()
        {
            helperMethod.elementScrollIntoView(accordian);
            accordian.Click();
            helperMethod.elementScrollIntoView(thirdAccordionHeader);
            thirdAccordionHeader.Click();
            Thread.Sleep(2000);
        }

        public string GetFirstAccordionContent()
        {
            accordian.Click();
            helperMethod.elementScrollIntoView(firstAccordionContent);
            return firstAccordionContent.Text;
        }

        public string GetSecondAccordionContent()
        {
            return secondAccordionContent.Text;
        }

        public string GetThirdAccordionContent()
        {
            return thirdAccordionContent.Text;
        }
    }

}
