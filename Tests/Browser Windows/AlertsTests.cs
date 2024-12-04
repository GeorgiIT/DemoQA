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
    public class AlertsTests : BaseSetup
    {
        //[Test]
        public void VerifySimpleAlert()
        {
            new HomePage().clickAlertsTab();
            var alertsPage = new AlertsPage();
            // Click the alert button
            alertsPage.ClickAlertButton();

        }

        //[Test]
        public void VerifyConfirmAlert()
        {
            new HomePage().clickAlertsTab();
            var alertsPage = new AlertsPage();

            // Click the confirm button and accept the alert
            alertsPage.ClickConfirmButton();

           
        }

        [Test]
        public void VerifyPromptAlert()
        {
            new HomePage().clickAlertsTab();
            var alertsPage = new AlertsPage();

            // Click the prompt button and provide input
            string inputText = "Hello, World!";
            string resultText = alertsPage.ClickPromptButton(inputText);

            // Verify that the expected result text appears
            Assert.That(resultText, Is.EqualTo($"You entered {inputText}"), "Prompt result text does not match.");
        }

    }
}
