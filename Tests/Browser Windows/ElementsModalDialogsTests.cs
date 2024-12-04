using DemoQA.Pages.AlertsWindows;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;

namespace DemoQA.Tests.Browser_Windows
{
    public class ElementsModalDialogsTests:BaseSetup
    {
        [Test]
        public void VerifySmallModalDialog()
        {
            new HomePage().clickAlertsTab();
            var modalDialogsPage = new ElementsModalDialogs();
            modalDialogsPage.OpenSmallModal();
            string headerText = modalDialogsPage.GetModalHeaderText();

            Assert.That(headerText, Is.EqualTo("Small Modal"), "The header text in the small modal does not match.");

            // Close the modal
            modalDialogsPage.CloseModal();
        }

        [Test]
        public void VerifyLargeModalDialog()
        {
            new HomePage().clickAlertsTab(); 
            var modalDialogsPage = new ElementsModalDialogs();

            modalDialogsPage.OpenLargeModal();
            string headerText = modalDialogsPage.GetModalHeaderText();

            Assert.That(headerText, Is.EqualTo("Large Modal"), "The header text in the large modal does not match.");

            modalDialogsPage.CloseModal();
        }

    }
}
