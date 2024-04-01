using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventuresWebApp_SeleniumPOMTests.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;
        protected HeaderPage headerPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            homePage = new HomePage(driver);
            headerPage = new HeaderPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}