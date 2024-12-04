using DemoQA.Basic;
using DemoQA.Pages.Elements_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Tests
{
    public class ElementsRadioButtonTests: BaseSetup
    {

        [Test]
        public static void CheclBoxShouldCheckedAndMessageDisplayed()
        {
            HomeTests.clickElements();
            new ElementsCheckBoxPage().clickCheckBoxTab()
                .clickCheckBoxHome()
                .verifyCheckBoxCheckedMessage();
        }
    }
}
