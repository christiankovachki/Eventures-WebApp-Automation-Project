using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class UserHomePageTests : BaseTest
    {

        [Test]
        public void Test_UserHomePage_User_Logout()
        {
            // Arrange: Go to Home page
            homePage.NavigateToHomePage();

            // Act: After successful log in, click the Logout link from the Navigation Bar
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            userHomePage.ClickLogoutLink();

            // Assert: Verify the user is successfully Logged Out from the system
            Assert.True(homePage.isLoginLinkFromNavDisplayed(), "The Login link from the Navigation Bar is NOT displayed!");
            Assert.True(homePage.isLoginLinkFromPageDisplayed(), "The Login link from the Main Page is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_AllEventsLink_OnPage()
        {
            // Arrange: Go to Home page
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on All Events link, located on the Main Page
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            var allEventsPage = userHomePage.ClickAllEventsLinkFromPage();

            // Assert: Verify the URL has changed to "All Events" page and the page displays the "All Events" header and a "Create New" link.
            Assert.True(allEventsPage.isAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(allEventsPage.PageHeader, Is.EqualTo("All Events"), "The Page Header is NOT correct!");
            Assert.That(allEventsPage.isCreateNewLinkDisplayed(), "The Create New link is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_AllEventsLink_InNavigation()
        {
            // Arrange: Go to Home page
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on All Events link, located in the Navigation bar
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            var allEventsPage = userHomePage.ClickAllEventsLinkFromNav();

            // Assert: Verify the URL has changed to "All Events" page and the page displays the "All Events" header and a "Create New" link.
            Assert.True(allEventsPage.isAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(allEventsPage.PageHeader, Is.EqualTo("All Events"), "The Page Header is NOT correct!");
            Assert.That(allEventsPage.isCreateNewLinkDisplayed(), "The Create New link is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_CreateEventLink_OnPage()
        {
            // Arrange: Go to Home page
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on New Event link, located on the Main Page
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            var createEventPage = userHomePage.ClickCreateEventLinkFromPage();

            // Assert: Verify the URL has changed to "Create Event" page and the page displays the "Create New Event" header and a "Back to List" link.
            Assert.True(createEventPage.isCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.PageHeader, Is.EqualTo("Create New Event"), "The Page Header is NOT correct!");
            Assert.That(createEventPage.isBackToListLinkDisplayed(), "The Back To List link is NOT displayed!");
        }

        // BUG: The test FAILS because the Create Event link in the Navigation bar is not clickable
        [Test]
        public void Test_UserHomePage_CreateEventLink_InNavigation()
        {
            // Arrange: Go to Home page
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on New Event link, located in the Navigation bar
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            var createEventPage = userHomePage.ClickCreateEventLinkFromNav();

            // Assert: Verify the URL has changed to "Create Event" page and the page displays the "Create New Event" header and a "Back to List" link.
            Assert.True(createEventPage.isCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.PageHeader, Is.EqualTo("Create New Event"), "The Page Header is NOT correct!");
            Assert.That(createEventPage.isBackToListLinkDisplayed(), "The Back To List link is NOT displayed!");
        }
    }
}