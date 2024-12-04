using DemoQA.Basic;
using DemoQA.Pages;
using DemoQA.Pages.AlertsWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Tests.Browser_Windows
{
    public class NestedFrameTest:BaseSetup
    {
        [Test]
        public void VerifyTextInParentFrame()
        {
            new HomePage().clickAlertsTab(); 
            var nestedFramesPage = new NestedFramesPage();
            nestedFramesPage.SwitchToParentFrame();
            string parentFrameText = nestedFramesPage.GetTextFromParentFrame();
            Assert.That(parentFrameText, Is.EqualTo("This is a sample page"), "The text in the parent frame does not match.");
            nestedFramesPage.SwitchToDefaultContent();
        }

        //[Test]
        public void VerifyTextInChildFrame()
        {
            new HomePage().clickAlertsTab(); 
            var nestedFramesPage = new NestedFramesPage();

            nestedFramesPage.SwitchToParentFrame();
            nestedFramesPage.SwitchToChildFrame();
            string childFrameText = nestedFramesPage.GetTextFromChildFrame();
            Assert.That(childFrameText, Is.EqualTo("Child Iframe"), "The text in the child frame does not match.");
            nestedFramesPage.SwitchToDefaultContent();
        }

    }
}
