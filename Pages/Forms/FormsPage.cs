using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQA.Pages.NewFolder
{
    public class FormsPage: BaseSetup
    {
        HelperMethods helperMethods;
        public FormsPage()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Practice Form']")]
        private readonly IWebElement practiceForm;

        [FindsBy(How = How.Id, Using = "firstName")]
        private readonly IWebElement firstNameInput;

        [FindsBy(How = How.Id, Using = "lastName")]
        private readonly IWebElement lastNameInput;

        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//*[text()='Male']")]
        private readonly IWebElement genderMale;

        [FindsBy(How = How.Id, Using = "gender-radio-2")]
        private readonly IWebElement genderFemale;

        [FindsBy(How = How.Id, Using = "userNumber")]
        private readonly IWebElement phoneInput;

        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement submitButton;

        public FormsPage FillForm(string firstName, string lastName, string email, string gender, string phone)
        {
            //helperMethods.elementScrollIntoView(practiceForm);
            practiceForm.Click();
            firstNameInput.SendKeys(firstName);
            lastNameInput.SendKeys(lastName);
            emailInput.SendKeys(email);
            helperMethods.elementScrollIntoView(emailInput);
            genderMale.Click();
            phoneInput.SendKeys(phone);
            return this;
        }

        public void SubmitForm()
        {
            helperMethods.elementScrollIntoView(submitButton);

            submitButton.Click();
        }
    }
}
