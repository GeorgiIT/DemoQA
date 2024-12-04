using DemoQA.Basic;
using DemoQA.Pages.Elements_Pages;


namespace DemoQA.Tests.Elements_Tests
{
    public class ElementsBrokenLinksTests:BaseSetup
    {
        [Test]
        public void VerifyBrokenLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsBrokenLinksPage()
                .clickBrokenLinksTabs()
                .ClickBrokenLinkAndVerifyUrl();
        }

        [Test]
        public void VerifyValidLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsBrokenLinksPage()
                .clickBrokenLinksTabs()
                .ClickValidLinkAndVerifyUrl();
        }

    }
}
