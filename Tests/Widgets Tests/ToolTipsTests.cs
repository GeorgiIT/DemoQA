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
    public class ToolTipsTests: BaseSetup
    {
        [Test]
        public void VerifyButtonTooltipText()
        {
            new HomePage().clickWidgetsTab();
            var toolTipsPage = new ElementsToolTips();
            toolTipsPage.HoverOverButtonWithTooltip();
            string tooltipText = toolTipsPage.GetTooltipText();
            Assert.That(tooltipText, Is.EqualTo("You hovered over the Button"), "Tooltip text for the button is incorrect.");
        }

        [Test]
        public void VerifyTextFieldTooltipText()
        {
            new HomePage().clickWidgetsTab();
            var toolTipsPage = new ElementsToolTips();
            toolTipsPage.HoverOverTextFieldWithTooltip();
            string tooltipText = toolTipsPage.GetTooltipText();
            Assert.That(tooltipText, Is.EqualTo("You hovered over the text field"), "Tooltip text for the text field is incorrect.");
        }

    }
}
