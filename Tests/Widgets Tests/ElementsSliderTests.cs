using DemoQA.Basic;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Tests.Widgets_Tests
{
    public class ElementsSliderTests:BaseSetup
    {
        [Test]
        public void VerifySliderValue()
        {
            new HomePage().clickWidgetsTab();
            var sliderPage = new ElementsSlider();

            // Set the slider value to a specific point (e.g., 50)
            sliderPage.SetSliderValue(50);

            // Get the displayed slider value and verify it
            string displayedValue = sliderPage.GetSliderValue();
            Assert.That(displayedValue, Is.EqualTo("25"), "The displayed slider value does not match the expected value.");
        }

    }
}
