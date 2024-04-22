using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class CreateEventPage : BasePage
    {
        private const string CreateEventUrl = BaseUrl + "/Events/Create";

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'Create New Event')]")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.CssSelector, Using = "form[action = '/Events/Create']")]
        private IWebElement _createNewEventForm;

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement _nameField;

        [FindsBy(How = How.Id, Using = "Place")]
        private IWebElement _placeField;

        [FindsBy(How = How.Id, Using = "Start")]
        private IWebElement _startDate;

        [FindsBy(How = How.Id, Using = "End")]
        private IWebElement _endDate;

        [FindsBy(How = How.Id, Using = "TotalTickets")]
        private IWebElement _totalTicketsField;

        [FindsBy(How = How.Id, Using = "PricePerTicket")]
        private IWebElement _pricePerTicketField;

        [FindsBy(How = How.Id, Using = "Name-error")]
        private IWebElement _nameFieldErrorMessage;
        
        [FindsBy(How = How.Id, Using = "Place-error")]
        private IWebElement _placeFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Start-error")]
        private IWebElement _startDateErrorMessage;

        [FindsBy(How = How.Id, Using = "End-error")]
        private IWebElement _endDateErrorMessage;
        
        [FindsBy(How = How.Id, Using = "TotalTickets-error")]
        private IWebElement _totalTicketsFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "PricePerTicket-error")]
        private IWebElement _pricePerTicketFieldErrorMessage;

        [FindsBy(How = How.XPath, Using = "//input[@value = 'Create']")]
        private IWebElement _createButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Back to List')]")]
        private IWebElement _backToListButton;

        public CreateEventPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string PageHeader { get => _pageHeader.Text; }

        public string NameFieldErrorMessage { get => _nameFieldErrorMessage.Text; }

        public string PlaceFieldErrorMessage { get => _placeFieldErrorMessage.Text; }

        public string StartDateErrorMessage { get => _startDateErrorMessage.Text; }

        public string EndDateErrorMessage { get => _endDateErrorMessage.Text; }

        public string TotalTicketsFieldErrorMessage { get => _totalTicketsFieldErrorMessage.Text; }

        public string PricePerTicketFieldErrorMessage { get => _pricePerTicketFieldErrorMessage.Text; }

        public void NavigateToCreateEventPage()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToHomePage();
            var loginPage = homePage.ClickLoginLinkFromPage();
            var userHomePage = loginPage.LogInUser("guest", "guest");
            userHomePage.ClickCreateEventLinkFromPage();
            WaitUrlToBe(CreateEventUrl);
            WaitForVisibilityOfElement(_createNewEventForm);
        }

        public bool IsCreateEventUrlCorrect()
        {
            return IsUrlCorrect(CreateEventUrl);
        }

        public bool IsBackToListLinkDisplayed()
        {
            return IsElementDisplayed(_backToListButton);
        }

        public AllEventsPage ClickBackToListButton()
        {
            ClickOnElement(_backToListButton);

            return new AllEventsPage(driver);
        }

        public void EnterInvalidTotalTicketsDetails(string totalTickets)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            ClearFieldData(_totalTicketsField);
            TypeInField(_totalTicketsField, totalTickets);

            ClickOnElement(_createButton);
        }

        public void EnterInvalidPricePerTicketDetails(string pricePerTicket)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            ClearFieldData(_pricePerTicketField);
            TypeInField(_pricePerTicketField, pricePerTicket);

            ClickOnElement(_createButton);
        }

        public AllEventsPage EnterValidEventDetails(string eventName, string eventPlace, string totalTickets, string pricePerTicket)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            ClearFieldData(_nameField);
            TypeInField(_nameField, eventName);

            ClearFieldData(_placeField);
            TypeInField(_placeField, eventPlace);

            ClearFieldData(_totalTicketsField);
            TypeInField(_totalTicketsField, totalTickets);

            ClearFieldData(_pricePerTicketField);
            TypeInField(_pricePerTicketField, pricePerTicket);

            ClickOnElement(_createButton);

            return new AllEventsPage(driver);
        }

        public void ClearEventDetailsFields()
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            ClearFieldData(_nameField);
            ClearFieldData(_placeField);
            ClearFieldData(_startDate);
            ClearFieldData(_endDate);
            ClearFieldData(_totalTicketsField);
            ClearFieldData(_pricePerTicketField);

            ClickOnElement(_createButton);
        }
    }
}