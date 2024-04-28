using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Source.Pages
{
    public class RegistrationPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement _firstNameInputField;
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement _lastNameInputField;
        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _usernameInputField;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.Id, Using = "register")]
        private IWebElement _registerBtn;
        [FindsBy(How = How.Id, Using = "gotologin")]
        private IWebElement _backToLoginBtn;
        [FindsBy(How = How.Id, Using = "recaptcha-anchor")]
        private IWebElement _imNotARobotCheckBoxBtn;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void Registration(string username, string password, string firstName, string lastName)
        {

            _firstNameInputField.SendKeys(firstName);
            _lastNameInputField.SendKeys(lastName);
            _usernameInputField.SendKeys(username);
            _passwordInputField.SendKeys(password);

            _imNotARobotCheckBoxBtn.Click();
            Thread.Sleep(500);

            _registerBtn.Click();
            // I need to find a way to deal with captcha
        }
    }
}