using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    public class BaseTest
    {
        private string screenshotDir = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Screenshots");
        protected IWebDriver driver;
        protected HomePage homePage;

        [OneTimeSetUp]
        public void CleanDir()
        {
            CleanDirectory(screenshotDir);
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            homePage = new HomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure || TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                TakeScreenshot();
            }
            
            driver.Close();
        }

        private void TakeScreenshot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenshot = takesScreenshot.GetScreenshot();
            string fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:dd-MM-yyyy_HH.mm.ss}.png";
            string screenshotPath = Path.Combine(screenshotDir, fileName);
            screenshot.SaveAsFile(screenshotPath);
        }

        private void CleanDirectory(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                else 
                {
                    DirectoryInfo directory = new DirectoryInfo(directoryPath);

                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}