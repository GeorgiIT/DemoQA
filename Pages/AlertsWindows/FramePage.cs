using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.AlertsWindows
{
    public class FramePage:BaseSetup
    {
        
        public FramePage()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Frames']")]
        private readonly IWebElement frames;

        [FindsBy(How = How.Id, Using = "frame1")]
        private readonly IWebElement firstFrame;

        [FindsBy(How = How.Id, Using = "frame2")]
        private readonly IWebElement secondFrame;

        public void SwitchToFirstFrame()
        {
            new HelperMethods(driver).elementScrollIntoView(frames);
            frames.Click();
            new HelperMethods(driver).elementScrollIntoView(firstFrame);
            driver.SwitchTo().Frame(firstFrame);
            Thread.Sleep(3000);
        }

        public void SwitchToSecondFrame()
        {
            frames.Click();
            new HelperMethods(driver).elementScrollIntoView(secondFrame);
            driver.SwitchTo().Frame(secondFrame);
        }

        public string GetTextFromFirstFrame()
        {
            return driver.FindElement(By.Id("sampleHeading")).Text; 
        }

        public string GetTextFromSecondFrame()
        {
            new HelperMethods(driver).elementScrollIntoView(driver.FindElement(By.Id("sampleHeading")));
            return driver.FindElement(By.Id("sampleHeading")).Text; 
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
