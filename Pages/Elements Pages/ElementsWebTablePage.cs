using DemoQA.Basic;
using DemoQA.Helper;
using DemoQA.NewFolder;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsWebTablePage: BaseSetup
    {

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Web Tables']")]
        private readonly IWebElement webTables;

        [FindsBy(How = How.Id, Using = "searchBox")]
        private readonly IWebElement searchBox;
       
        [FindsBy(How = How.Id, Using = "basic-addon2")]
        private readonly IWebElement searchButton;
        
        [FindsBy(How = How.Id, Using = "addNewRecordButton")]
        private readonly IWebElement addButton;

        [FindsBy(How = How.Id, Using = "firstName")]
        private readonly IWebElement firstNameEditText;

        [FindsBy(How = How.Id, Using = "lastName")]
        private readonly IWebElement lastNameEditText;

        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement emailEditText;

        [FindsBy(How = How.Id, Using = "age")]
        private readonly IWebElement ageEditText;

        [FindsBy(How = How.Id, Using = "salary")]
        private readonly IWebElement salaryEditText;

        [FindsBy(How = How.Id, Using = "department")]
        private readonly IWebElement departmentEditText;

        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement submitButton;


        public ElementsWebTablePage()
        {
            //helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        public ElementsWebTablePage clickWebTablesTabs()
        {
            webTables.Click();
            return this;
        }

        public ElementsWebTablePage enterTextToSearch()
        {
            searchBox.SendKeys(TestValues.testToSearch);
            return this;
        }

        public ElementsWebTablePage clickSearchButton()
        {
            searchButton.Click();
            return this;
        }

        public ElementsWebTablePage verifySearchRecord()
        {
            IWebElement searchResult = driver.FindElement(By.XPath("//div[text()='"+TestValues.testToSearch+"']"));
            Assert.That(searchResult.Displayed, Is.True, "Wrong Search Results");
            return this;
        }

        public ElementsWebTablePage clickAddButton()
        {
            addButton.Click();
            return this;
        }

        public ElementsWebTablePage addNewRecordAndVerify()
        {
            firstNameEditText.SendKeys("Test");
            lastNameEditText.SendKeys("Test");
            emailEditText.SendKeys("Test@gmail.com");
            ageEditText.SendKeys("25");
            salaryEditText.SendKeys("25000");
            departmentEditText.SendKeys("Test");
            submitButton.Click();
            Thread.Sleep(5000);
            IWebElement searchResult = driver.FindElement(By.XPath("//div[text()='Test']"));
            Assert.That(searchResult.Displayed, Is.True, "Wrong Search Results");
            return this;
        }
    }
}
