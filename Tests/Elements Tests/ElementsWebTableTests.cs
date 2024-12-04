using DemoQA.Basic;
using DemoQA.Pages.Elements_Pages;


namespace DemoQA.Tests.Elements_Tests
{
    public class ElementsWebTableTests:BaseSetup
    {
        //[Test]
        public void verifySearchOnWebTable()
        {
            HomeTests.clickElements();
            new ElementsWebTablePage()
                .clickWebTablesTabs()
                .enterTextToSearch()
                .verifySearchRecord();

        }
        [Test]
        public void verifyAddRecordWorking()
        {
            HomeTests.clickElements();
            new ElementsWebTablePage()
                .clickWebTablesTabs()
                .clickAddButton()
                .addNewRecordAndVerify();

        }
    }
}
