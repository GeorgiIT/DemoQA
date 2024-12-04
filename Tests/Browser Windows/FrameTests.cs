using DemoQA.Basic;
using DemoQA.Pages;
using DemoQA.Pages.AlertsWindows;


namespace DemoQA.Tests.Browser_Windows
{
    public class FrameTests:BaseSetup
    {
        [Test]
        public void VerifyTextInFirstFrame()
        {
            new HomePage().clickAlertsTab(); 
            var framesPage = new FramePage();

            framesPage.SwitchToFirstFrame();
            string frameText = framesPage.GetTextFromFirstFrame();
            Assert.That(frameText, Is.EqualTo("This is a sample page"), "The text in the first frame does not match.");
            framesPage.SwitchToDefaultContent();
        }

        [Test]
        public void VerifyTextInSecondFrame()
        {
            new HomePage().clickAlertsTab();
            var framesPage = new FramePage();
            framesPage.SwitchToSecondFrame();
            string frameText = framesPage.GetTextFromSecondFrame();
            Assert.That(frameText, Is.EqualTo("This is a sample page"), "The text in the second frame does not match.");
            framesPage.SwitchToDefaultContent();
        }

    }
}
