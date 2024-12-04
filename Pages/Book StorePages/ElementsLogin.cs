

using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.Book_StorePages
{
    public class ElementsLogin : BaseSetup
    {
        private HelperMethods helperMethod;

        public ElementsLogin()
        {
            helperMethod = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Login']")]
        private readonly IWebElement bookLogin;

        [FindsBy(How = How.XPath, Using = "//input[@id='userName']")]
        private readonly IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "login")]
        private readonly IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//p[@id='name']")]
        private readonly IWebElement loginMessage;


        public void clickLoginTab()
        {
            helperMethod.elementScrollIntoView(bookLogin);
            bookLogin.Click();
        }

        public void EnterUsername(string username)
        {
            usernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            helperMethod.elementScrollIntoView(loginButton);
            loginButton.Click();
            Thread.Sleep(10000);
        }

        public void verifyLogin()
        {
            Assert.That(driver.FindElement(By.XPath("//button[text()= 'Log out']")).Displayed,Is.True, "Login not done");
        }
        public string GetErrorMessage()
        {
            Thread.Sleep(10000);

            helperMethod.elementScrollIntoView(loginMessage);
            return loginMessage.Text;
        }
    }

}
