using DemoQA.Basic;
using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Tests.Widgets_Tests
{
    public class AccordionTests:BaseSetup
    {
        [Test]
        public void VerifyFirstAccordionContent()
        {
            new HomePage().clickWidgetsTab(); 
            var accordionPage = new ElementsAccordion();
            string contentText = accordionPage.GetFirstAccordionContent();
            Assert.That(contentText.Contains("Lorem Ipsum is simply dummy text of the printing and typesetting industry"),Is.True, "The content in the first accordion does not match.");
        }

        [Test]
        public void VerifySecondAccordionContent()
        {
            new HomePage().clickWidgetsTab(); 
            var accordionPage = new ElementsAccordion();
            accordionPage.ClickSecondAccordion();

            string contentText = accordionPage.GetSecondAccordionContent();
            Assert.That(contentText.Contains("Contrary to popular belief, Lorem Ipsum is not simply random text."),Is.True, "The content in the second accordion does not match.");
        }

        [Test]
        public void VerifyThirdAccordionContent()
        {
            new HomePage().clickWidgetsTab(); 
            var accordionPage = new ElementsAccordion();
            accordionPage.ClickThirdAccordion();
            string contentText = accordionPage.GetThirdAccordionContent();
            Assert.That(contentText.Contains("It is a long established fact that a reader will be distracted by the readable content of a page"),Is.True, "The content in the third accordion does not match.");
        }

    }
}
