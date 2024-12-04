using DemoQA.Basic;
using DemoQA.Pages;

namespace DemoQA.Tests
{
    public class HomeTests : BaseSetup
    {
        [Test]
        public static void clickElements()
        {
            new HomePage()
                .clickElementTab()
                .verifyElementPage();
        }

    }
}
