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

namespace DemoQA.Tests.Widgets_Tests
{
    public class ElementsSlider : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsSlider()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Slider']")]
        private readonly IWebElement slider;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'range-slider__tooltip--bottom')]")]
        private readonly IWebElement sliderInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='sliderValue']")]
        private readonly IWebElement sliderValueDisplay;

        public void SetSliderValue(int value)
        {
            helperMethod.elementScrollIntoView(slider);
            slider.Click();
            Actions actions = new Actions(driver);
            actions.DragAndDropToOffset(sliderInput, value, 0).Perform(); // Adjust the value based on the slider's range
        }

        public string GetSliderValue()
        {
            return sliderValueDisplay.GetAttribute("value");
        }
    }

}
