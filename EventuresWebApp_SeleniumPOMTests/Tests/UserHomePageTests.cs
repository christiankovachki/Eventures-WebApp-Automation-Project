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
            // Arrange: Go to the Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on the Logout link from the Navigation bar
            var userHomePage = LogIn();
            userHomePage.ClickLogoutLink();

            // Assert: Verify the user is successfully logged out from the web application
            Assert.True(homePage.IsLoginLinkFromNavDisplayed(), "The Login link from the Navigation Bar is NOT displayed!");
            Assert.True(homePage.IsLoginLinkFromPageDisplayed(), "The Login link from the Main Page is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_AllEventsLink_OnPage()
        {
            // Arrange: Go to the Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on All Events link, located on the Main page
            var userHomePage = LogIn();
            var allEventsPage = userHomePage.ClickAllEventsLinkFromPage();

            // Assert: Verify the URL has changed to All Events page and the page displays the All Events header and a Create New link
            Assert.True(allEventsPage.IsAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(allEventsPage.PageHeader, Is.EqualTo("All Events"), "The Page Header is NOT correct!");
            Assert.That(allEventsPage.IsCreateNewLinkDisplayed(), "The Create New link is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_AllEventsLink_InNavigation()
        {
            // Arrange: Go to the Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on All Events link, located in the Navigation bar
            var userHomePage = LogIn();
            var allEventsPage = userHomePage.ClickAllEventsLinkFromNav();

            // Assert: Verify the URL has changed to All Events page and the page displays the All Events header and a Create New link
            Assert.True(allEventsPage.IsAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(allEventsPage.PageHeader, Is.EqualTo("All Events"), "The Page Header is NOT correct!");
            Assert.That(allEventsPage.IsCreateNewLinkDisplayed(), "The Create New link is NOT displayed!");
        }

        [Test]
        public void Test_UserHomePage_CreateEventLink_OnPage()
        {
            // Arrange: Go to the Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on New Event link, located on the Main page
            var userHomePage = LogIn();
            var createEventPage = userHomePage.ClickCreateEventLinkFromPage();

            // Assert: Verify the URL has changed to Create Event page and the page displays the Create New Event header and a Back to List link
            Assert.True(createEventPage.IsCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.PageHeader, Is.EqualTo("Create New Event"), "The Page Header is NOT correct!");
            Assert.That(createEventPage.IsBackToListLinkDisplayed(), "The Back To List link is NOT displayed!");
        }

        // BUG: The test FAILS because the Create Event link in the Navigation bar is not clickable
        [Test]
        public void Test_UserHomePage_CreateEventLink_InNavigation()
        {
            // Arrange: Go to the Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: After successful log in, click on New Event link, located in the Navigation bar
            var userHomePage = LogIn();
            var createEventPage = userHomePage.ClickCreateEventLinkFromNav();

            // Assert: Verify the URL has changed to Create Event page and the page displays the Create New Event header and a Back to List link
            Assert.True(createEventPage.IsCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.PageHeader, Is.EqualTo("Create New Event"), "The Page Header is NOT correct!");
            Assert.That(createEventPage.IsBackToListLinkDisplayed(), "The Back To List link is NOT displayed!");
        }

        private UserHomePage LogIn()
        {
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");

            return userHomePage;
        }
    }
}