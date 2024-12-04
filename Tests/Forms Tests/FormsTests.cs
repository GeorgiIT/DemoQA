using DemoQA.Basic;
using DemoQA.Pages;
using DemoQA.Pages.NewFolder;


namespace DemoQA.Tests.NewFolder
{
    public class FormsTests:BaseSetup
    {
        [Test]
        public void VerifyFormSubmission()
        {
            new HomePage()
                .clickFormsTab();
            new FormsPage()
                .FillForm("John", "Doe", "john.doe@example.com", "Male", "1234567890")
                .SubmitForm();
        }
    }
}
