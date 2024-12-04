using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;
using NUnit.Framework;

namespace DemoQA.Tests.Widgets_Tests
{
    public class MenuTests:BaseSetup
    {
        [Test]
        public void VerifyMainItem1()
        {
            new HomePage().clickWidgetsTab();
            var menuPage = new ElementsMenu();
            menuPage.ClickMainItem1();
            Assert.That(menuPage.IsSubMenuVisible(),Is.False, "Submenu for Main Item 1 should not be visible.");
        }

        [Test]
        public void VerifyMainItem2()
        {
            new HomePage().clickWidgetsTab();
            var menuPage = new ElementsMenu();
            menuPage.ClickMainItem2();

            // Verify submenu is displayed
            Assert.That(menuPage.IsSubMenuVisible(), Is.True, "Submenu for Main Item 2 should be visible.");

        }

        [Test]
        public void VerifyMainItem3()
        {
            new HomePage().clickWidgetsTab();
            var menuPage = new ElementsMenu();

            // Click on Main Item 3
            menuPage.ClickMainItem3();

            // Verify expected behavior or content
            Assert.That(menuPage.IsSubMenuVisible(),Is.False, "Submenu for Main Item 3 should not be visible.");
        }

    }
}
