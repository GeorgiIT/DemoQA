using DemoQA.Basic;
using DemoQA.Pages;
using DemoQA.Pages.AlertWindows;

namespace DemoQA.Tests.Browser_Windows

{
    public class ElementsBrowserWindowsTests:BaseSetup
    {
        [Test]
        public void VerifyNewTabFunctionality()
        {
            new HomePage().clickAlertsTab();
            var browserWindowsPage = new ElementsBrowserWindows();

            // Click the button to open a new tab
            browserWindowsPage.ClickNewTab();

            // Verify the URL of the new tab
            string expectedTabUrl = "https://demoqa.com/sample"; // Update with the expected URL for the new tab
            Assert.That(browserWindowsPage.GetCurrentUrl(), Is.EqualTo(expectedTabUrl), "The URL for the new tab does not match.");

            // Close the tab and switch back to the original tab
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [Test]
        public void VerifyNewWindowFunctionality()
        {
            new HomePage().clickAlertsTab();
            var browserWindowsPage = new ElementsBrowserWindows();

            // Click the button to open a new window
            browserWindowsPage.ClickNewWindow();

            // Verify the URL of the new window
            string expectedWindowUrl = "https://demoqa.com/sample"; // Update with the expected URL for the new window
            Assert.That(browserWindowsPage.GetCurrentUrl(), Is.EqualTo(expectedWindowUrl), "The URL for the new window does not match.");

            // Close the window and switch back to the original window
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [Test]
        public void VerifyMessageWindowFunctionality()
        {
            new HomePage().clickAlertsTab();
            var browserWindowsPage = new ElementsBrowserWindows();

            browserWindowsPage.ClickMessageWindow();

            // Close the window and switch back to the original window
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

    }
}
