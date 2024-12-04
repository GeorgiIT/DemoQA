using DemoQA.Basic;
using DemoQA.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.Elements_Pages
{
    public class ElementsDownloadUpload:BaseSetup
    {
        HelperMethods helperMethods;
        public ElementsDownloadUpload()
        {
            helperMethods = new HelperMethods(driver);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'collapse show')]//span[text()= 'Upload and Download']")]
        private readonly IWebElement downloadUploadTab;

        [FindsBy(How = How.Id, Using = "uploadFile")]
        private readonly IWebElement uploadInput;

        [FindsBy(How = How.Id, Using = "downloadButton")]
        private readonly IWebElement downloadButton;

        [FindsBy(How = How.Id, Using = "uploadedFilePath")]
        private readonly IWebElement uploadedFilePath;

        public ElementsDownloadUpload UploadFile(string filePath)
        {
            uploadInput.SendKeys(filePath);
            return this;
        }

        public ElementsDownloadUpload clickUploadTabs()
        {
            helperMethods.elementScrollIntoView(downloadUploadTab);
            downloadUploadTab.Click();
            Thread.Sleep(2000);
            return this;
        }

        public ElementsDownloadUpload ClickDownloadAndVerifyFile()
        {
            downloadButton.Click();
            // Add a delay to wait for the file to download (adjust time as needed)
            Thread.Sleep(3000);
            new Actions(driver).KeyDown(Keys.Enter);

            // Verify the file has been downloaded
            string downloadedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sampleFile.jpeg"); // Update the filename
            Assert.That(File.Exists(downloadedFilePath),Is.True, "Downloaded file does not exist.");
            return this;
        }
    }
}
