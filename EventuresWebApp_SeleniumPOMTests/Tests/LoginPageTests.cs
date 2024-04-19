using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        private LoginPage loginPage;

        [SetUp]
        protected void LogInSetUp()
        { 
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Test_LoginPage_LogIn_With_Valid_Credentials()
        {
            // Arrange: Go to Log In page 
            loginPage.NavigateToLogInPage();

            // Act: Populate Username and Password fields with valid credentials
            var userHomePage = loginPage.LogInUser("guest", "guest");

            // Assert: Verify that the user is redirected to his/hers Home Page
            Assert.True(userHomePage.IsLogoutLinkDisplayed(), "The Logout link is NOT displayed!");
            Assert.That(userHomePage.WelcomeMessage, Is.EqualTo("Welcome, guest"), "The Welcome message is NOT correct!");
        }

        [Test]
        public void Test_LoginPage_LogIn_With_Blank_Fields()
        {
            // Arrange: Go to Log In page 
            loginPage.NavigateToLogInPage();

            // Act: Leave Username and Password fields blank
            loginPage.LogInUser(string.Empty, string.Empty);

            // Assert: Verify that the user is still located on the Log In page and he/she sees the warning messages
            Assert.True(loginPage.IsLogInFormDisplayed(), "The Log In form is NOT visible!");
            Assert.That(loginPage.RequiredUsernameMessage, Is.EqualTo("The Username field is required."), "The message for required Username is NOT correct!");
            Assert.That(loginPage.RequiredPasswordMessage, Is.EqualTo("The Password field is required."), "The message for required Password is NOT correct!");
        }

        [TestCase("guest", "tseug")]
        [TestCase("tseug", "guest")]
        [TestCase("tseug", "tseug")]
        public void Test_LoginPage_LogIn_With_Invalid_Credentials(string username, string password)
        {
            // Arrange: Go to Log In page 
            loginPage.NavigateToLogInPage();

            // Act: Populate Username and Password fields with invalid credentials
            loginPage.LogInUser(username, password);

            // Assert: Verify that the user is still located on the Log In page and he/she sees the invalid attempt message
            Assert.True(loginPage.IsLogInFormDisplayed(), "The Log In form is NOT visible!");
            Assert.That(loginPage.InvalidAttemptMessage, Is.EqualTo("Invalid login attempt."), "The Invalid Attempt Message is NOT correct!");
        }
    }
}