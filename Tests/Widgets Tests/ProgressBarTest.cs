using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;

namespace DemoQA.Tests.Widgets_Tests
{
    public class ProgressBarTest:BaseSetup
    {
        //[Test]
        public void VerifyProgressBarStartsAndCompletes()
        {
            new HomePage().clickWidgetsTab();
            var progressBarPage = new ElementsProgressBar();

            // Start the progress bar
            progressBarPage.StartProgressBar();
            System.Threading.Thread.Sleep(15000); // Adjust sleep time based on actual duration
            string progressValue = progressBarPage.GetProgressBarValue();

            // Verify the progress value has reached 100
            Assert.That(progressValue, Is.EqualTo("100"), "The progress bar did not reach 100%.");
        }

        [Test]
        public void VerifyProgressBarReset()
        {
            new HomePage().clickWidgetsTab();
            var progressBarPage = new ElementsProgressBar();

            progressBarPage.StartProgressBar();
            System.Threading.Thread.Sleep(15000); 
            progressBarPage.ResetProgressBar();
            string progressValueAfterReset = progressBarPage.GetProgressBarValue();
            Assert.That(progressValueAfterReset, Is.EqualTo("0"), "The progress bar did not reset to 0%.");
        }

    }
}
