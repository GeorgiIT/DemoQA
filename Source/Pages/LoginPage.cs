using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Source.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

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

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        public string LoginAndCatchingTheErrorMsg(string username, string password)
        {
            _usernameInputField.SendKeys(username);
            _passwordInputField.SendKeys(password);

            _loginBtn.Click();
            Thread.Sleep(500);

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