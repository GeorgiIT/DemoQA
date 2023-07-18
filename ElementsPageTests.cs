using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace DemoQA
{
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            // for mac "/Users/georgi/Desktop/Google Chrome.app/Contents/MacOS/Google Chrome"
            // for win "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void testingMenuOpeningsAndUrls()
        {
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(2000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);
            string randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;


            Assert.AreEqual(driver.Url, "https://demoqa.com/elements");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);




            //Forms page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(2)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/forms");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);



            //AlertsWindows page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(3)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/alertsWindows");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);


            //Widgets page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(4)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/widgets");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);



            //Interaction page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/interaction");
            Assert.AreEqual(randomTextFromThePage, "Please select an item from left to start practice.");

            driver.Navigate().Back();
            Thread.Sleep(1000);


            //books page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(6)")).Click();
            Thread.Sleep(1000);
            randomTextFromThePage = driver.FindElement(By.CssSelector("#app > div > div > div.pattern-backgound.playgound-header > div")).Text;

            Assert.AreEqual(driver.Url, "https://demoqa.com/books");
            Assert.AreEqual(randomTextFromThePage, "Book Store");

            driver.Navigate().Back();
            Thread.Sleep(1000);



        }

        [Test]
        public void elements_TextBoxFormRegistrationWithCorrectData()
        {
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(1000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));
            bool textButtonShowed = elementsOptions.Displayed;
            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            driver.FindElement(By.Id("item-0")).Click();

            string name = "Georgi Todorov";
            string email = "georgiit98@gmail.com";
            string currentAddress = "Burgas, Bulgaria";
            string permanentAddress = "Burgas, Bulgaria";
            //Filling the form data

            driver.FindElement(By.Id("userName")).SendKeys(name);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);

            //button with frame
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitButton);

            Thread.Sleep(1000);

            string actualStoredName = driver.FindElement(By.Id("name")).Text;
            string actualStoredEmail = driver.FindElement(By.Id("email")).Text;


            // Wait for the "currentAddress" field to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Wait for the "currentAddress" field to be visible and enabled
            IWebElement currentAddressField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("currentAddress")));
            wait.Until(d => currentAddressField.Enabled && !string.IsNullOrEmpty(currentAddressField.GetAttribute("value")));

            // Access the "currentAddress" field
            string actualStoredCurrentAddress = currentAddressField.GetAttribute("value");


            // permanent
            IWebElement permanentAddressField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("permanentAddress")));
            wait.Until(d => permanentAddressField.Enabled && !string.IsNullOrEmpty(currentAddressField.GetAttribute("value")));

            // Access the "currentAddress" field
            string actualStoredPermanentAddress = permanentAddressField.GetAttribute("value");

            //test
            Assert.That(actualStoredName.Contains(name));
            Assert.That(actualStoredEmail.Contains(email));
            Assert.That(actualStoredCurrentAddress.Contains(currentAddress));
            Assert.That(actualStoredPermanentAddress.Contains(permanentAddress));
        }

        [Test]
        public void checkBoxClicking_allFoldersShowedButtonTest()
        {

            driver.Url = "https://demoqa.com/";
            Thread.Sleep(1000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));
            bool textButtonShowed = elementsOptions.Displayed;
            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            driver.FindElement(By.Id("item-1")).Click();

            driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all")).Click();



            IWebElement desktopFolderOpened = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(1) > ol > li:nth-child(2) > span > label > span.rct-title"));
            Assert.That(desktopFolderOpened.Displayed);

            IWebElement documents_workSpace_FolderOpened = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(1) > ol > li:nth-child(1) > span > label > span.rct-title"));
            IWebElement documents_office_FolderOpened = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(2) > ol > li:nth-child(2) > span > label > span.rct-title"));
            Assert.That(documents_office_FolderOpened.Displayed);
            Assert.That(documents_workSpace_FolderOpened.Displayed);

            IWebElement downloadsFolderOpened = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol > li:nth-child(1) > span > label > span.rct-title"));
            Assert.That(downloadsFolderOpened.Displayed);
        }
        [Test]
        public void checkBoxClicking_allFoldersHiddenButtonTest()
        {

            driver.Url = "https://demoqa.com/";
            Thread.Sleep(1000);

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));

            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            driver.FindElement(By.Id("item-1")).Click();
            //clicking first to expand all folders
            driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all")).Click();
            IWebElement desktopFolderOpenedOptions = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(1) > ol > li:nth-child(2) > span > label > span.rct-title"));
            bool desktopFolderOpened = desktopFolderOpenedOptions.Displayed;
            Thread.Sleep(1000);

            // Collapse them all
            driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-collapse-all")).Click();

            bool desktopFolderCollapsed;

            IWebElement desktopFolderCollapsedOptions = driver.FindElement(By.CssSelector("#tree-node > ol > li"));
            desktopFolderCollapsed = desktopFolderCollapsedOptions.Displayed;




            // Assert that the folders are hidden after collapsing
            Assert.IsTrue(desktopFolderCollapsed, "The desktop folders are hidden after collapsing.");

        }

        [Test]
        public void checkboxMenuChechkingArrowsButtons()
        {
            driver.Url = "https://demoqa.com/";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));

            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            driver.FindElement(By.Id("item-1")).Click();

            // Finding the button for Home folder
            driver.FindElement(By.CssSelector("#tree-node > ol > li > span > button")).Click();

            IWebElement insideHomeFolderFiles = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol"));
            bool foldersInsideHomeDirectory = insideHomeFolderFiles.Displayed;

            //Making sure that folders inside Home directory are visible
            Assert.That(foldersInsideHomeDirectory); // expected TRUE

            //Finding and clicking on the documents folder
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > span > button")).Click();

            IWebElement insideDocumentsFolderFiles = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol"));
            bool foldersInsideDocumentsDirectory = insideDocumentsFolderFiles.Displayed;

            //Making sure that folders inside Documents directory are visible
            Assert.That(foldersInsideDocumentsDirectory); // expected TRUE


            // Finding and clicking on a folder inside documents directory, folder name is WorkSpace
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol > li:nth-child(1) > span > button")).Click();

            IWebElement InsideWorkSpaceFolderFiles = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol"));
            bool filesInsideWorkSpaceFolder = InsideWorkSpaceFolderFiles.Displayed;

            //Making sure that folders inside WorkSpace directory are visible
            Assert.That(filesInsideWorkSpaceFolder); // TRUE



            // Now I have to check that they are hidding correctly ----------------->
            // Clicking on WorkSpace folder
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol > li:nth-child(1) > span > button")).Click();

            // Wait for the element to become invisible (hidden)

            try
            {
                filesInsideWorkSpaceFolder = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol")));
            }
            catch (WebDriverTimeoutException)
            {
                filesInsideWorkSpaceFolder = true; // The element is  hidden
            }

            // Assert files in WorkSpace are hidden
            Assert.IsTrue(filesInsideWorkSpaceFolder, "The dropdown menu is hidden correctly.");

            //clicking on documents folder to hide it
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > span > button")).Click();
            bool isHidden;
            try
            {
                isHidden = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol")));
            }
            catch (WebDriverTimeoutException)
            {
                isHidden = true; // The element is  hidden
            }
            // Assert files in Documents are hidden
            Assert.IsTrue(isHidden, "The dropdown menu is hidden correctly.");

            //Hidding the home menu files 
            driver.FindElement(By.CssSelector("#tree-node > ol > li > span > button")).Click();

            try
            {
                isHidden = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#tree-node > ol > li > ol > li.rct-node.rct-node-parent.rct-node-expanded > ol")));
            }
            catch (WebDriverTimeoutException)
            {
                isHidden = true; // The element is  hidden
            }
            // Assert files in Home files are hidden
            Assert.IsTrue(isHidden, "The dropdown menu is hidden correctly.");
        }

        [Test]
        public void checkBoxMenuSelectingTests()
        {
            driver.Url = "https://demoqa.com/";

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));

            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("item-1"))).Click();

            //Selecting test ---->
            IWebElement homeElement = driver.FindElement(By.CssSelector("#tree-node > ol > li > span > label > span.rct-checkbox > svg"));
            bool isSelected = homeElement.Selected;

            if (!isSelected)
            {
                homeElement.Click();
            }
            IList<IWebElement> homeResults = driver.FindElements(By.ClassName("text-success"));

            //here I use equivalence partitioning testing to save time
            Assert.That(homeResults[0].Text, Is.EqualTo("home"));
            Assert.That(homeResults[6].Text, Is.EqualTo("react"));
            Assert.That(homeResults[16].Text, Is.EqualTo("excelFile"));

            //Test with equivalence partitioning method
            driver.Navigate().Refresh();

            //Opening the entire menu to select random files
            driver.FindElement(By.CssSelector("#tree-node > ol > li > span > button")).Click();
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(1) > span > button")).Click();
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > span > button")).Click();


            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(3) > span > button")).Click();


            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(1) > span > button")).Click();
            driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(2) > span > button")).Click();

            //Notes file

            IWebElement notesFile = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(1) > ol > li:nth-child(1) > span > label > span.rct-checkbox > svg"));
            isSelected = notesFile.Selected;
            if (!isSelected)
            {
                notesFile.Click();
            }

            //Veu file
            IWebElement veuFile = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(1) > ol > li:nth-child(3) > span > label > span.rct-checkbox > svg"));
            isSelected = veuFile.Selected;
            if (!isSelected)
            {
                veuFile.Click();
            }

            //Private file
            IWebElement privateFile = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li:nth-child(2) > ol > li:nth-child(2) > span > label > span.rct-checkbox > svg"));
            isSelected = privateFile.Selected;
            if (!isSelected)
            {
                privateFile.Click();
            }

            //word file

            // Scroll to the "wordFile" element
            IWebElement wordFile = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(3) > ol > li:nth-child(1) > span > label > span.rct-checkbox > svg"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", wordFile);

            // Wait for the element to become clickable and then click it
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement clickableWordFile = wait.Until(ExpectedConditions.ElementToBeClickable(wordFile));
            clickableWordFile.Click();


            //Tests
            IList<IWebElement> selectedFiles = driver.FindElements(By.ClassName("text-success"));

            Assert.That(selectedFiles[0].Text, Is.EqualTo("notes"));
            Assert.That(selectedFiles[1].Text, Is.EqualTo("veu"));
            Assert.That(selectedFiles[2].Text, Is.EqualTo("private"));
            Assert.That(selectedFiles[3].Text, Is.EqualTo("wordFile"));


        }

        [Test]
        public void radioButtonTest()
        {
            driver.Url = "https://demoqa.com/";

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));

            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("item-2"))).Click();

            //Clicking on Yes button
            IWebElement yesButon = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div:nth-child(2) > div:nth-child(2) > label"));
            yesButon.Click();

            string textFromRadioButton = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div:nth-child(2) > p > span")).Text;
            Assert.That(textFromRadioButton, Is.EqualTo("Yes"));

            // clicking on impressive button
            IWebElement impressiveButton = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div:nth-child(2) > div:nth-child(3) > label"));
            impressiveButton.Click();

            textFromRadioButton = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div:nth-child(2) > p > span")).Text;

            Assert.That(textFromRadioButton, Is.EqualTo("Impressive"));

        }

        [Test]
        public void webTablesAddingwithValidInformationTests()
        {
            driver.Url = "https://demoqa.com/";

            //Elements page
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();
            Thread.Sleep(1000);

            IWebElement elementsOptions = driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > div > ul"));

            bool textButtonHidden = !elementsOptions.Displayed;

            if (textButtonHidden)
            {
                driver.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")).Click();

            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("item-3"))).Click();
            driver.FindElement(By.Id("addNewRecordButton")).Click();

            driver.FindElement(By.Id("firstName")).SendKeys("Georgi");
            driver.FindElement(By.Id("lastName")).SendKeys("Todorov");
            driver.FindElement(By.Id("userEmail")).SendKeys("georgiit98@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("salary")).SendKeys("2500");
            driver.FindElement(By.Id("department")).SendKeys("QA");

            driver.FindElement(By.Id("submit")).Click();

         

            string infoFromTable = driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody > div:nth-child(4) > div")).Text;
            

            string[] rowData = infoFromTable.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Trim each value in the rowData array to remove leading and trailing spaces
            string firstName = rowData[0].Trim();
            string lastName = rowData[1].Trim();
            string age = rowData[2].Trim();
            string email = rowData[3].Trim();
            string salary = rowData[4].Trim();
            string department = rowData[5].Trim();

            Assert.That(firstName, Is.EqualTo("Georgi"));
            Assert.That(lastName, Is.EqualTo("Todorov"));
            Assert.That(email, Is.EqualTo("georgiit98@gmail.com"));
            Assert.That(age, Is.EqualTo("25"));
            Assert.That(salary, Is.EqualTo("2500"));
            Assert.That(department, Is.EqualTo("QA"));

        }
        




        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}