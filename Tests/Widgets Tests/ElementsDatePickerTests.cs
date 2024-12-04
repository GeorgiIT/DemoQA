using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;

namespace DemoQA.Tests.Widgets_Tests
{
    public class ElementsDatePickerTests:BaseSetup
    {
        [Test]
        public void VerifyDatePickerSelection()
        {
            new HomePage().clickWidgetsTab();
            var datePickerPage = new ElementsDatePicker();
            datePickerPage.OpenDatePicker();
            datePickerPage.SelectDay("1");
            string selectedDate = datePickerPage.GetSelectedDate();
            Assert.That(selectedDate.Contains("01"), Is.True, "The selected date does not match the expected date.");
        }

    }
}
