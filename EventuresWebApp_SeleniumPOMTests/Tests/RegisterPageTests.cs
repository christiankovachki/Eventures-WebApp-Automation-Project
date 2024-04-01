using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class RegisterPageTests : BaseTest
    {
        private RegisterPage registerPage;

        [SetUp]
        protected void RegisterSetUp()
        {
            registerPage = new RegisterPage(driver);
        }

        [TestCase("", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "")]
        public void Test_RegisterPage_Register_With_Valid_Credentials(string username, string email, string password, string confirmPassword, string firstName, string lastName) 
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials
            var userHomePage = registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is redirected to his/hers Home Page
            Assert.True(headerPage.isLogoutLinkDisplayed(), "The Logout link is NOT displayed!");
            Assert.That(userHomePage.WelcomeMessage, Is.EqualTo($"Welcome, {username}"), "The Welcome message is NOT correct!");
        }
    }
}