using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

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

        [TestCase("userA", "gmailtest@gmail.com", "123456", "123456", "Jo", "Jo")]
        [TestCase("12345", "abvtest@abv.bg", "12345678901234567890", "12345678901234567890", "JOHN", "JOHN")]
        [TestCase("user0", "yahootest@yahoo.com", "passwo", "passwo", "Renée", "Renée")]
        [TestCase("user01", "outlooktest@outlook.com", "passwordpasswordpass", "passwordpasswordpass", "Mary-Jane", "Mary-Jane")]
        [TestCase("01user", "icloudtest@icloud.com", "pass12word", "pass12word", "O'Connor", "O'Connor")]
        [TestCase("01user1", "protontest@protonmail.com", "pass_!@#$%^", "pass_!@#$%^", "Mary Ann", "Mary Ann")]
        [TestCase("user12345abcdef", "mailtest@mail.com", "123!@#$%^", "123!@#$%^", "ElizabethSmith", "ElizabethSmith")]
        [TestCase("0us1er0", "yandextest@yandex.com", "!@#$%^&*-_+", "!@#$%^&*-_+", "elizabeth", "elizabeth")]
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