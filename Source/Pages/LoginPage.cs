using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using DemoQA.Source.Drivers;

namespace DemoQA.Source.Pages
{
    public class LoginPage : Driver
    {
        private IWebDriver _webDriver;

        [FindsBy(How = How.Id, Using = "newUser")]
        private IWebElement _newUserBtn;
        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement _loginBtn;
        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _usernameInputField;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passwordInputField;
        [FindsBy(How = How.Id, Using = "output")]
        private IWebElement _outputMsg;

        public LoginPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        
        public string LoginAndCatchingTheErrorMsg(string username, string password)
        {
            _usernameInputField.SendKeys(username);
            _passwordInputField.SendKeys(password);

            _loginBtn.Click();
            Thread.Sleep(1000);

            return _outputMsg.Text;
        }
        public void Login(string username, string password)
        {
            _usernameInputField.SendKeys(username);
            _passwordInputField.SendKeys(password);

            _loginBtn.Click();
        }
    }
}