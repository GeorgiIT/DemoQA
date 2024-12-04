using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using DemoQA.Basic;

namespace DemoQA.Tests.Widgets_Tests
{
    public class TabsTests:BaseSetup
    {
        [Test]
        public void VerifyWhatTabContent()
        {
            new HomePage().clickWidgetsTab();
            var tabsPage = new ElementsTabs();
            tabsPage.ClickWhatTab();
            string content = tabsPage.GetCurrentTabContent();
            Assert.That(content.Contains("Lorem Ipsum is simply dummy text of the printing and typesetting industry"),Is.True, "The content of the 'What' tab does not match.");
        }

        [Test]
        public void VerifyOriginTabContent()
        {
            new HomePage().clickWidgetsTab();
            var tabsPage = new ElementsTabs();
            tabsPage.ClickOriginTab();
            string content = tabsPage.GetCurrentTabContent();
            Assert.That(content.Contains("Contrary to popular belief, Lorem Ipsum"),Is.True, "The content of the 'Origin' tab does not match.");
        }

        [Test]
        public void VerifyUseTabContent()
        {
            new HomePage().clickWidgetsTab();
            var tabsPage = new ElementsTabs();
            tabsPage.ClickUseTab();
            string content = tabsPage.GetCurrentTabContent();
            Assert.That(content.Contains("It is a long established fact that a reader will "),Is.True, "The content of the 'Use' tab does not match.");
        }

    }
}
