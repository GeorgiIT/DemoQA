using DemoQA.Basic;
using DemoQA.Pages.Elements_Pages;

namespace DemoQA.Tests.Elements_Tests
{
    public class ElementsLinksTests:BaseSetup
    {
        [Test]
        public void VerifyCreatedLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickCreatedAndVerifyMessage();
        }

        [Test]
        public void VerifyNoContentLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickNoContentAndVerifyMessage();
        }

        [Test]
        public void VerifyMovedPermanentlyLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickMovedPermanentlyAndVerifyMessage();
        }

        [Test]
        public void VerifyBadRequestLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickBadRequestAndVerifyMessage();
        }

        [Test]
        public void VerifyUnauthorizedLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickUnauthorizedAndVerifyMessage();
        }

        [Test]
        public void VerifyForbiddenLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickForbiddenAndVerifyMessage();
        }

        [Test]
        public void VerifyNotFoundLinkWorking()
        {
            HomeTests.clickElements();
            new ElementsWebLinksPage()
                .clickLinksTabs()
                .ClickNotFoundAndVerifyMessage();
        }
    }
}
