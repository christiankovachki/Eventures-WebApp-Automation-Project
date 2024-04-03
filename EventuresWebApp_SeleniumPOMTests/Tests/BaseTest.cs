using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;

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
            driver.Close();
        }
    }
}