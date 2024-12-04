using DemoQA.Basic;
using DemoQA.NewFolder;
using DemoQA.Pages;


namespace DemoQA.Tests
{
    public class ElementsTextBoxTests: BaseSetup
    {
        [Test]
        public static void TextBox_WithValidData_ShouldSucceed()
        {
            ElementsTextBoxPage textBoxes = new ElementsTextBoxPage();
            HomeTests.clickElements();
            textBoxes.TextBoxRegistrationForm(TestValues.fullname, TestValues.email, TestValues.currentAddress, TestValues.permanentAddress);
            Dictionary<string, string> result = textBoxes.GetResult();
            Assert.That(result["Name"], Is.EqualTo(TestValues.fullname), "Name should match");
            Assert.That(result["Email"], Is.EqualTo(TestValues.email), "Email should match");
            Assert.That(result["Current Address"], Is.EqualTo(TestValues.currentAddress), "Current Address should match");
            Assert.That(result["Permananet Address"], Is.EqualTo(TestValues.permanentAddress), "Permanent Address should match");
        }

    }
}
