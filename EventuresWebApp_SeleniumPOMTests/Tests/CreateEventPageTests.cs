using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class CreateEventPageTests : BaseTest
    {
        private CreateEventPage createEventPage;
        private AllEventsPage allEventsPage;

        [SetUp]
        protected void CreateEventSetUp()
        {
            createEventPage = new CreateEventPage(driver);
            allEventsPage = new AllEventsPage(driver);
        }

        [TestCase("Auto Event 1", "Some Place 1", "1", "0")]
        [TestCase("Auto Event 2", "Some Place 2", "100", "10.0")]
        [TestCase("Auto Event 3", "Some Place 3", "1000", "1000")]
        public void Test_CreateEventPage_CreateEvent_ValidData(string eventName, string eventPlace, string totalTickets, string pricePerTicket)
        {
            // Arrange: Go to All Events page and get the initial count of events, then go to Create Event page
            allEventsPage.NavigateToAllEventsPage();
            int initialEventsCount = allEventsPage.TableRows.Count;
            allEventsPage.ClickCreateNewLink();

            // Act: Fill in valid event details
            createEventPage.ValidEventDetails(eventName, eventPlace, totalTickets, pricePerTicket);
            int currentEventsCount = allEventsPage.TableRows.Count;

            // Assert: Verify that the user is redirected to the "All Events" page, the events count has increased by 1 and the newly created event is displayed
            Assert.True(allEventsPage.IsAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(currentEventsCount, Is.EqualTo(initialEventsCount + 1), "The Event count hasn't increased!");
            Assert.True(allEventsPage.VerifyEventIsCreated(eventName, eventPlace, "guest"), "The newly created event isn't displayed!");
        }

        // BUG: The test FAILS because the 'Back to List' link is not clickable
        [Test]
        public void Test_CreateEventPage_BackToListLink()
        {
            // Arrange: Go to Create Event page
            createEventPage.NavigateToCreateEventPage();

            // Act: Click on 'Back to List' link
            createEventPage.ClickBackToListButton();

            // Assert: Verify the URL has changed to "All Events" page and the page displays the "All Events" header.
            Assert.True(allEventsPage.IsAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(allEventsPage.PageHeader, Is.EqualTo("All Events"), "The Page Header is NOT correct!");
        }

        [Test]
        public void Test_CreateEventPage_CreateEvent_When_All_Fields_Are_Blank()
        {
            // Arrange: Go to Create Event page
            createEventPage.NavigateToCreateEventPage();

            // Act: Clear all event details and click on the 'Create' button.
            createEventPage.EmptyEventDetails();

            // Assert: Verify that the user remains on the "Create Event" page and an error messages for each field indicating the invalid input is displayed.
            Assert.True(createEventPage.IsCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.NameFieldErrorMessage, Is.EqualTo("The Name field is required."), "The Name field error message is NOT correct!");
            Assert.That(createEventPage.PlaceFieldErrorMessage, Is.EqualTo("The Place field is required."), "The Place field error message is NOT correct!");
            Assert.That(createEventPage.StartDateErrorMessage, Is.EqualTo("The Start field is required."), "The Start Date field error message is NOT correct!");
            Assert.That(createEventPage.EndDateErrorMessage, Is.EqualTo("The End field is required."), "The End Date field error message is NOT correct!");
            Assert.That(createEventPage.TotalTicketsFieldErrorMessage, Is.EqualTo("The TotalTickets field is required."), "The TotalTickets field error message is NOT correct!");
            Assert.That(createEventPage.PricePerTicketFieldErrorMessage, Is.EqualTo("The PricePerTicket field is required."), "The PricePerTicket field error message is NOT correct!");
        }

        [TestCase("1001")]
        [TestCase("-1")]
        [TestCase("0")] // BUG: The system allows to create an event with 0 total tickets
        public void Test_CreateEventPage_CreateEvent_Invalid_Total_Tickets(string totalTickets)
        {
            // Arrange: Go to Create Event page
            createEventPage.NavigateToCreateEventPage();

            // Act: Fill in invalid total tickets details 
            createEventPage.InvalidTotalTicketsDetails(totalTickets);

            // Assert: Verify that the user remains on the "Create Event" page and an error messages for the invalid input is displayed.
            Assert.True(createEventPage.IsCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.TotalTicketsFieldErrorMessage, Is.EqualTo("Total Tickets must be a positive number and less than 1000."), "The Total Tickets field error message is NOT correct!");
        }

        [TestCase("1000.01")]
        [TestCase("1001")]
        [TestCase("-0.1")]
        [TestCase("-1")]
        public void Test_CreateEventPage_CreateEvent_Invalid_Price_Per_Ticket(string pricePerTicket)
        {
            // Arrange: Go to Create Event page
            createEventPage.NavigateToCreateEventPage();

            // Act: Fill in invalid price per ticket details 
            createEventPage.InvalidPricePerTicketDetails(pricePerTicket);

            // Assert: Verify that the user remains on the "Create Event" page and an error messages for the invalid input is displayed.
            Assert.True(createEventPage.IsCreateEventUrlCorrect(), "The URL is NOT correct!");
            Assert.That(createEventPage.PricePerTicketFieldErrorMessage, Is.EqualTo("Price Per Ticket must be a positive number and less than 1000."), "The Price Per Ticket field error message is NOT correct!");
        }
    }
}