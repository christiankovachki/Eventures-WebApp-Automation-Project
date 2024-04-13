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

        public string PageHeader { get => _pageHeader.Text; }

        public string NameFieldErrorMessage { get => _nameFieldErrorMessage.Text; }

        public string PlaceFieldErrorMessage { get => _placeFieldErrorMessage.Text; }

        public string StartDateErrorMessage { get => _startDateErrorMessage.Text; }

        public string EndDateErrorMessage { get => _endDateErrorMessage.Text; }

        public string TotalTicketsFieldErrorMessage { get => _totalTicketsFieldErrorMessage.Text; }

        public string PricePerTicketFieldErrorMessage { get => _pricePerTicketFieldErrorMessage.Text; }

        public CreateEventPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

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

        public bool isCreateEventUrlCorrect()
        {
            return isUrlCorrect(CreateEventUrl);
        }

        public bool isBackToListLinkDisplayed()
        {
            return _backToListButton.Displayed;
        }

        public AllEventsPage ClickBackToListButton()
        {
            ClickOnElement(_backToListButton);
            return new AllEventsPage(driver);
        }

        public void InvalidTotalTicketsDetails(string totalTickets)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            _totalTicketsField.Clear();
            TypeInField(_totalTicketsField, totalTickets);

            ClickOnElement(_createButton);
        }

        public void InvalidPricePerTicketDetails(string pricePerTicket)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            _pricePerTicketField.Clear();
            TypeInField(_pricePerTicketField, pricePerTicket);

            ClickOnElement(_createButton);
        }

        public AllEventsPage ValidEventDetails(string eventName, string eventPlace, string totalTickets, string pricePerTicket)
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            _nameField.Clear();
            TypeInField(_nameField, eventName);

            _placeField.Clear();
            TypeInField(_placeField, eventPlace);

            _totalTicketsField.Clear();
            TypeInField(_totalTicketsField, totalTickets);

            _pricePerTicketField.Clear();
            TypeInField(_pricePerTicketField, pricePerTicket);

            ClickOnElement(_createButton);

            return new AllEventsPage(driver);
        }

        public void EmptyEventDetails()
        {
            WaitForVisibilityOfElement(_createNewEventForm);

            _nameField.Clear();
            _placeField.Clear();
            _startDate.Clear();
            _endDate.Clear();
            _totalTicketsField.Clear();
            _pricePerTicketField.Clear();

            ClickOnElement(_createButton);
        }
    }
}