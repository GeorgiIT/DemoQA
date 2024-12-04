using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsWebLinksPage:BaseSetup
    {
        HelperMethods helperMethods;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Links']")]
        private readonly IWebElement links;

        [FindsBy(How = How.Id, Using = "created")]
        private readonly IWebElement createdLink;

        [FindsBy(How = How.Id, Using = "no-content")]
        private readonly IWebElement noContentLink;

        [FindsBy(How = How.Id, Using = "moved")]
        private readonly IWebElement movedPermanentlyLink;

        [FindsBy(How = How.Id, Using = "bad-request")]
        private readonly IWebElement badRequestLink;

        [FindsBy(How = How.Id, Using = "unauthorized")]
        private readonly IWebElement unauthorizedLink;

        [FindsBy(How = How.Id, Using = "forbidden")]
        private readonly IWebElement forbiddenLink;

        [FindsBy(How = How.Id, Using = "invalid-url")]
        private readonly IWebElement notFoundLink;

        [FindsBy(How = How.Id, Using = "linkResponse")]
        private readonly IWebElement responseMessage;

        public ElementsWebLinksPage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        public ElementsWebLinksPage clickLinksTabs()
        {
            helperMethods.elementScrollIntoView(links);
            links.Click();
            Thread.Sleep(2000);
            return this;
        }
        public ElementsWebLinksPage ClickCreatedAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(createdLink);
            createdLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Search Results"); // Ensure you have createdMessage defined
            return this;
        }

        // Function for No Content link
        public ElementsWebLinksPage ClickNoContentAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(noContentLink);
            noContentLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed,Is.True, "Wrong No Content Results"); // Ensure you have noContentMessage defined
            return this;
        }

        // Function for Moved Permanently link
        public ElementsWebLinksPage ClickMovedPermanentlyAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(movedPermanentlyLink);
            movedPermanentlyLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Moved Permanently Results"); // Ensure you have movedPermanentlyMessage defined
            return this;
        }

        // Function for Bad Request link
        public ElementsWebLinksPage ClickBadRequestAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(badRequestLink);
            badRequestLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Bad Request Results"); // Ensure you have badRequestMessage defined
            return this;
        }

        // Function for Unauthorized link
        public ElementsWebLinksPage ClickUnauthorizedAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(unauthorizedLink);
            unauthorizedLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Unauthorized Results"); // Ensure you have unauthorizedMessage defined
            return this;
        }

        // Function for Forbidden link
        public ElementsWebLinksPage ClickForbiddenAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(forbiddenLink);
            forbiddenLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Forbidden Results"); // Ensure you have forbiddenMessage defined
            return this;
        }

        // Function for Not Found link
        public ElementsWebLinksPage ClickNotFoundAndVerifyMessage()
        {
            helperMethods.elementScrollIntoView(notFoundLink);
            notFoundLink.Click();
            Thread.Sleep(2000);
            Assert.That(responseMessage.Displayed, Is.True, "Wrong Not Found Results"); // Ensure you have notFoundMessage defined
            return this;
        }
    }
}
