

using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using DemoQA.Basic;

namespace DemoQA.Tests.Widgets_Tests
{
    public class ElementsAutoCompleteTests:BaseSetup
    {
        [Test]
        public void VerifySingleInputAutoComplete()
        {
            new HomePage().clickWidgetsTab();
            var autoCompletePage = new ElementsAutoComplete();

            autoCompletePage.EnterSingleInput("bla");

            autoCompletePage.SelectAutoCompleteOption("Black");

        }

        //[Test]
        public void VerifyMultipleInputAutoComplete()
        {
            new HomePage().clickWidgetsTab();
            var autoCompletePage = new ElementsAutoComplete();

            // Enter multiple inputs
            autoCompletePage.EnterMultipleInput("Bla");
            autoCompletePage.SelectAutoCompleteOption("Black");
            autoCompletePage.EnterMultipleInput("Blu");
            autoCompletePage.SelectAutoCompleteOption("Blue");
        }

    }
}
