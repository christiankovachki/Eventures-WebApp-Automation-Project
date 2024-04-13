using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class AllEventsPage : BasePage
    {
        private const string AllEventsUrl = BaseUrl + "/Events/All";

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'All Events')]")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create New')]")]
        private IWebElement _createNewLink;

        [FindsBy(How = How.CssSelector, Using = ".table th")]
        private readonly IList<IWebElement> _tableColumnsHeaders;

        [FindsBy(How = How.CssSelector, Using = ".table tbody tr")]
        private readonly IList<IWebElement> _tableRows;
        
        public string PageHeader { get => _pageHeader.Text; }

        public IList<IWebElement> TableRows { get => _tableRows; }

        public AllEventsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToAllEventsPage()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToHomePage();
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            userHomePage.ClickAllEventsLinkFromPage();
            WaitUrlToBe(AllEventsUrl);
            WaitForVisibilityOfElement(_pageHeader);
        }

        public bool isAllEventsUrlCorrect()
        {
            return isUrlCorrect(AllEventsUrl);
        }

        public bool isCreateNewLinkDisplayed()
        {
            return _createNewLink.Displayed;
        }

        public CreateEventPage ClickCreateNewLink()
        {
            ClickOnElement(_createNewLink);

            return new CreateEventPage(driver);
        }

        public bool VerifyEventIsCreated(string eventName, string eventPlace, string owner)
        {
            int nameColumnIndex = GetColumnIndex("Name");
            int placeColumnIndex = GetColumnIndex("Place");
            int ownerColumnIndex = GetColumnIndex("Owner");

            foreach (var row in _tableRows)
            {
                IList<IWebElement> cells = row.FindElements(By.CssSelector("tbody tr td"));
                string eventNameCellText = cells[nameColumnIndex].Text;
                string eventPlaceCellText = cells[placeColumnIndex].Text;
                string ownerCellText = cells[ownerColumnIndex].Text;

                if (eventName.Equals(eventNameCellText) && eventPlace.Equals(eventPlaceCellText) && owner.Equals(ownerCellText))
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteEvent(string owner)
        {
            int ownerColumnIndex = GetColumnIndex("Owner");
            int actionsColumnIndex = GetColumnIndex("Actions");
            int rowIndex = 1;

            foreach (var row in _tableRows)
            {
                IList<IWebElement> cells = row.FindElements(By.CssSelector("tbody tr td"));
                string ownerCellText = cells[ownerColumnIndex].Text;

                if (owner.Equals(ownerCellText))
                {
                    string attribute = row.FindElement(By.XPath($"//tbody/tr[{rowIndex}]/td[{actionsColumnIndex + 1}]/a")).GetAttribute("href");
                    int lastSlashIndex = attribute.LastIndexOf('/');
                    string digitsAsString = attribute.Substring(lastSlashIndex + 1);

                    IWebElement deleteButton = row.FindElement(By.XPath($"//a[@href='/Events/Delete/{digitsAsString}']"));
                    ClickOnElement(deleteButton);

                    IWebElement confirmDeleteButton = driver.FindElement(By.CssSelector(".btn[value = 'Delete']"));
                    ClickOnElement(confirmDeleteButton);
                    break;
                }

                rowIndex++;
            }
        }

        public void EditEvent(string fieldName, string newData, string owner)
        {
            int ownerColumnIndex = GetColumnIndex("Owner");
            int actionsColumnIndex = GetColumnIndex("Actions");
            int rowIndex = 1;

            foreach (var row in _tableRows)
            {
                IList<IWebElement> cells = row.FindElements(By.CssSelector("tbody tr td"));
                string ownerCellText = cells[ownerColumnIndex].Text;

                if (owner.Equals(ownerCellText))
                {
                    string attribute = row.FindElement(By.XPath($"//tbody/tr[{rowIndex}]/td[{actionsColumnIndex + 1}]/a[2]")).GetAttribute("href");
                    int lastSlashIndex = attribute.LastIndexOf('/');
                    string digitsAsString = attribute.Substring(lastSlashIndex + 1);

                    IWebElement editButton = row.FindElement(By.XPath($"//a[@href='/Events/Edit/{digitsAsString}']"));
                    ClickOnElement(editButton);

                    EditEventField(fieldName, newData);

                    IWebElement confirmEditButton = driver.FindElement(By.CssSelector(".btn[value = 'Edit']"));
                    ClickOnElement(confirmEditButton);
                    break;
                }

                rowIndex++;
            }
        }

        public bool VerifyEventIsEdited(string eventName, string owner)
        {
            int nameColumnIndex = GetColumnIndex("Name");
            int ownerColumnIndex = GetColumnIndex("Owner");

            foreach (var row in _tableRows)
            {
                IList<IWebElement> cells = row.FindElements(By.CssSelector("tbody tr td"));
                string eventNameCellText = cells[nameColumnIndex].Text;
                string ownerCellText = cells[ownerColumnIndex].Text;

                if (eventName.Equals(eventNameCellText) && owner.Equals(ownerCellText))
                {
                    return true;
                }
            }

            return false;
        }

        private void EditEventField(string fieldName, string newData)
        {
            switch (fieldName)
            {
                case "Name":
                    IWebElement nameField = driver.FindElement(By.Id("Name"));
                    nameField.Clear();
                    TypeInField(nameField, newData);
                    break;
                case "Place":
                    IWebElement placeField = driver.FindElement(By.Id("Place"));
                    placeField.Clear();
                    TypeInField(placeField, newData);
                    break;
                case "Total Tickets":
                    IWebElement totalTicketsField = driver.FindElement(By.Id("TotalTickets"));
                    totalTicketsField.Clear();
                    TypeInField(totalTicketsField, newData);
                    break;
                case "Price Per Ticket":
                    IWebElement pricePerTicketField = driver.FindElement(By.Id("PricePerTicket"));
                    pricePerTicketField.Clear();
                    TypeInField(pricePerTicketField, newData);
                    break;
            }
        }

        private int GetColumnIndex(string columnName)
        {
            int index = -1;

            foreach (var column in _tableColumnsHeaders)
            {
                if (columnName.Equals(column.Text))
                {
                    index = _tableColumnsHeaders.IndexOf(column);
                    break;
                }
            }

            return index;
        }
    }
}