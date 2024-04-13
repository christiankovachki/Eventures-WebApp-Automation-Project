using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class AllEventsPageTests : BaseTest
    {
        private AllEventsPage allEventsPage;

        [SetUp]
        protected void AllEventsSetUp()
        {
            allEventsPage = new AllEventsPage(driver);
        }

        [Test]
        public void Test_AllEventsPage_DeleteEvent()
        {
            // Arrange: Go to All Events page and get the initial count of events
            allEventsPage.NavigateToAllEventsPage();
            int initialEventsCount = allEventsPage.TableRows.Count;

            // Act: Find and delete an Event which has been created by the owner account "guest"
            allEventsPage.DeleteEvent("guest");
            int currentEventsCount = allEventsPage.TableRows.Count;

            // Assert: Verify the user is redirected to the "All Events" page and the deleted event is no longer displayed on the page.
            Assert.True(allEventsPage.isAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.That(currentEventsCount, Is.EqualTo(initialEventsCount - 1), "The Event count hasn't deccreased!");
        }

        [Test]
        public void Test_AllEventsPage_EditEvent_ValidData()
        {
            // Arrange: Go to All Events page
            allEventsPage.NavigateToAllEventsPage();

            // Act: Find and edit the name of an Event which has been created by the owner account "guest"
            string newEventName = "Edited";
            allEventsPage.EditEvent("Name", newEventName, "guest");

            // Assert: Verify the user is redirected to the "All Events" page and the edited event with the updated data is displayed.
            Assert.True(allEventsPage.isAllEventsUrlCorrect(), "The URL is NOT correct!");
            Assert.True(allEventsPage.VerifyEventIsEdited(newEventName, "guest"), "The event which had been edited doesn't have the updated data!");
        }
    }
}