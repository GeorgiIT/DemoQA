using DemoQA.Basic;
using DemoQA.Pages.Elements_Pages;

namespace DemoQA.Tests.Elements_Tests
{
    public class ElementsButtonsTests:BaseSetup
    {
        [Test]
        public void verifyButtonClickFunctionality() {
            HomeTests.clickElements();
            new ElementsButtonsPage()
                .clickButtonTabs()
                .clickDoubleClickButton()
                .verifyDoubleClickedMessageDisplayed()
                .clickRightClickButton()
                .verifyRightClickedMessageDisplayed()
                .clickDynamicClickButton()
                .verifyDynamicClickedMessageDisplayed();

        }
    }
}
