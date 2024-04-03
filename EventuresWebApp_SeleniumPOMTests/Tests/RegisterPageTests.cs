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

        [Test, Order(1)]
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
            Assert.True(userHomePage.isLogoutLinkDisplayed(), "The Logout link is NOT displayed!");
            Assert.That(userHomePage.WelcomeMessage, Is.EqualTo($"Welcome, {username}"), "The Welcome message is NOT correct!");
        }
        
        // BUG: The test FAILS because the error message for Confirm Password field is missing
        [Test, Order(2)]
        public void Test_RegisterPage_Register_When_All_Fields_Are_Blank()
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Leave all fields blank
            registerPage.RegisterUser(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.UsernameFieldErrorMessage, Is.EqualTo("The Username field is required."), "The Username field error message is NOT correct!");
            Assert.That(registerPage.EmailFieldErrorMessage, Is.EqualTo("The Email field is required."), "The Email field error message is NOT correct!");
            Assert.That(registerPage.PasswordFieldErrorMessage, Is.EqualTo("The Password field is required."), "The Password field error message is NOT correct!");
            Assert.That(registerPage.ConfirmPasswordFieldErrorMessage, Is.EqualTo("The Confirm Password field is required."), "The Confirm Password field error message is NOT correct!");
            Assert.That(registerPage.FirstNameFieldErrorMessage, Is.EqualTo("The First Name field is required."), "The First Name field error message is NOT correct!");
            Assert.That(registerPage.LastNameFieldErrorMessage, Is.EqualTo("The Last Name field is required."), "The Last Name field error message is NOT correct!");
        }

        // BUG: All tests FAIL because error message for Username field is missing
        [Test, Order(3)]
        [TestCase("abcd", "mail1@somemail.com", "123456", "123456", "Li", "Li")] // BUG: The system allows registration with username which has only 4 characters
        [TestCase("userAß432", "mail2@somemail.com", "123456", "123456", "Li", "Li")]
        [TestCase("userA322^", "mail3@somemail.com", "123456", "123456", "Li", "Li")]
        [TestCase("$userA", "mail4@somemail.com", "123456", "123456", "Li", "Li")]
        [TestCase("userA@", "mail5@somemail.com", "123456", "123456", "Li", "Li")] // BUG: The system allows registration with username which has '@' symbol in it
        [TestCase("userA 123", "mail6@somemail.com", "123456", "123456", "Li", "Li")]
        public void Test_RegisterPage_Register_With_Invalid_Username(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Username field
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.UsernameFieldErrorMessage, Is.EqualTo($"Username '{username}' is invalid, can only contain letters or digits."), "The Username field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo($"Username '{username}' is invalid, can only contain letters or digits."), "The Validation Summary error message is NOT correct!");
        }

        // BUG: The test FAILS because the error message for Username field is missing
        [Test, Order(4)]
        public void Test_RegisterPage_Register_With_Already_Used_Username()
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Username field (use already taken username)
            registerPage.RegisterUser("guest", "guest@guestmail.com", "123456", "123456", "John", "Doe");

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.UsernameFieldErrorMessage, Is.EqualTo("Username 'guest' is already taken."), "The Username field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("Username 'guest' is already taken."), "The Validation Summary error message is NOT correct!");
        }

        [Test, Order(5)]
        [TestCase("userB1", "randomemail.com", "123456", "123456", "John", "John")]
        [TestCase("userB2", "randomemail@.com", "123456", "123456", "John", "John")]
        [TestCase("userB3", "@randomemail.com", "123456", "123456", "John", "John")]
        [TestCase("userB4", "randomemail@something@.com", "123456", "123456", "John", "John")]
        [TestCase("userB5", "randomemail@something", "123456", "123456", "John", "John")] // BUG: The system allows registration with invalid email
        [TestCase("userB6", "randomemail@something.", "123456", "123456", "John", "John")]
        [TestCase("userB7", "randomemail @ something.com", "123456", "123456", "John", "John")]
        [TestCase("userB8", "random email@something.com", "123456", "123456", "John", "John")]
        [TestCase("userB9", "randomemail@something.invalid", "123456", "123456", "John", "John")] // BUG: The system allows registration with invalid email
        [TestCase("userB10", "randomemail", "123456", "123456", "John", "John")]
        [TestCase("userB11", "randomemail@", "123456", "123456", "John", "John")]
        [TestCase("userB12", "randomemail#something.com", "123456", "123456", "John", "John")]
        public void Test_RegisterPage_Register_With_Invalid_Email(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Email field
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.EmailFieldErrorMessage, Is.EqualTo("The Email field is not a valid e-mail address."), "The Email field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The Email field is not a valid e-mail address."), "The Validation Summary error message is NOT correct!");
        }

        // BUG: The test FAILS because the system allows to register with an already used email
        [Test, Order(6)]
        public void Test_RegisterPage_Register_With_Already_Used_Email()
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Email field (use already taken email)
            registerPage.RegisterUser("userC", "gmailtest@gmail.com", "123456", "123456", "John", "Doe");

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.EmailFieldErrorMessage, Is.EqualTo("The Email address is already used."), "The Email field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The Email address is already used."), "The Validation Summary error message is NOT correct!");
        }

        [Test, Order(7)]
        [TestCase("userD1", "validmail1@valid.com", "12345", "12345", "John", "Doe")]
        [TestCase("userD2", "validmail2@valid.com", "123456789012345678901", "123456789012345678901", "John", "Doe")] // BUG: The system allows to register with password length of 21 chars
        public void Test_RegisterPage_Register_With_Invalid_Password(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Password field
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.PasswordFieldErrorMessage, Is.EqualTo("The Password must be at least 6 and at max 20 characters long."), "The Password field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The Password must be at least 6 and at max 20 characters long."), "The Validation Summary error message is NOT correct!");
        }

        // BUG: Both tests FAIL because the system allows to register with passwords which DO NOT match
        [Test, Order(8)]
        [TestCase("userE1", "somevalid1@valid.com", "123456", "654321", "Peter", "Parker")]
        [TestCase("userE2", "somevalid2@valid.com", "12345678901234567890", "09876543211234567890", "Peter", "Parker")]
        public void Test_RegisterPage_Register_With_Invalid_Confirm_Password(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Confirm Password field (does NOT match Password)
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.ConfirmPasswordFieldErrorMessage, Is.EqualTo("The Confirm Password must match the Password."), "The Confirm Password field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The Confirm Password must match the Password."), "The Validation Summary error message is NOT correct!");
        }

        // BUG: ALL tests FAIL because there is no validation for First Name field
        [Test, Order(9)]
        [TestCase("random03041", "random03041@email.com", "123456", "123456", "A", "Parker")]
        [TestCase("random03042", "random03042@email.com", "123456", "123456", "1", "Parker")]
        [TestCase("random03043", "random03043@email.com", "123456", "123456", "12", "Parker")]
        [TestCase("random03044", "random03044@email.com", "123456", "123456", "#", "Parker")]
        [TestCase("random03045", "random03045@email.com", "123456", "123456", "##", "Parker")]
        [TestCase("random03046", "random03046@email.com", "123456", "123456", " Alice ", "Parker")]
        [TestCase("random03047", "random03047@email.com", "123456", "123456", "S@mantha", "Parker")]
        [TestCase("random03048", "random03048@email.com", "123456", "123456", "Elizabeth!", "Parker")]
        [TestCase("random03049", "random03049@email.com", "123456", "123456", "Mary123", "Parker")]
        [TestCase("random03040", "random03040@email.com", "123456", "123456", "John#", "Parker")]
        public void Test_RegisterPage_Register_With_Invalid_First_Name(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT First Name field
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.FirstNameFieldErrorMessage, Is.EqualTo("The First Name field must consist of only letters and be at least 2 characters long."), "The First Name field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The First Name field must consist of only letters and be at least 2 characters long."), "The Validation Summary error message is NOT correct!");
        }

        // BUG: ALL tests FAIL because there is no validation for Last Name field
        [Test, Order(10)]
        [TestCase("random04031", "random04031@email.com", "123456", "123456", "John", "A")]
        [TestCase("random04032", "random04032@email.com", "123456", "123456", "John", "1")]
        [TestCase("random04033", "random04033@email.com", "123456", "123456", "John", "12")]
        [TestCase("random04034", "random04034@email.com", "123456", "123456", "John", "$")]
        [TestCase("random04035", "random04035@email.com", "123456", "123456", "John", "**")]
        [TestCase("random04036", "random04036@email.com", "123456", "123456", "John", " Toney ")]
        [TestCase("random04037", "random04037@email.com", "123456", "123456", "John", "L@mpard")]
        [TestCase("random04038", "random04038@email.com", "123456", "123456", "John", "Parker!")]
        [TestCase("random04039", "random04039@email.com", "123456", "123456", "John", "Parker123")]
        [TestCase("random04030", "random04030@email.com", "123456", "123456", "John", "Johnson#")]
        public void Test_RegisterPage_Register_With_Invalid_Last_Name(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Arrange: Go to Register page 
            registerPage.NavigateToRegisterPage();

            // Act: Populate all fields with valid credentials EXCEPT Last Name field
            registerPage.RegisterUser(username, email, password, confirmPassword, firstName, lastName);

            // Assert: Verify that the user is still located on the Register page and he/she sees the warning messages
            Assert.True(registerPage.isRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.That(registerPage.LastNameFieldErrorMessage, Is.EqualTo("The Last Name field must consist of only letters and be at least 2 characters long."), "The Last Name field error message is NOT correct!");
            Assert.That(registerPage.ValidationSummaryErrorMessage, Is.EqualTo("The Last Name field must consist of only letters and be at least 2 characters long."), "The Validation Summary error message is NOT correct!");
        }
    }
}