using DemoQA.Pages.Widgets_pages;
using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Basic;

namespace DemoQA.Tests.Widgets_Tests
{
    public class selectMenuTests:BaseSetup
    {

    [Test]
    public void VerifyOldSelectMenuOption()
    {
        new HomePage().clickWidgetsTab();
        var selectMenuPage = new ElementsSelectMenu();
        selectMenuPage.SelectOldMenuOption("Red");
    }

}
}
