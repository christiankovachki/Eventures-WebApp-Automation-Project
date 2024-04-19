using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class UserHomePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "dropdownMenuLink")]
        private IWebElement _eventsDropdownMenuLink;

        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Events/All']")]
        private IWebElement _allEventsLinkFromPage;

        [FindsBy(How = How.CssSelector, Using = ".dropdown-item[href='/Events/All']")]
        private IWebElement _allEventsLinkFromNav;

        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Events/Create']")]
        private IWebElement _createEventLinkFromPage;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create Event')]")]
        private IWebElement _createEventLinkFromNav;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Logout')]")]
        private IWebElement _logoutLink;

        [FindsBy(How = How.CssSelector, Using = "h1.text-center")]
        private IWebElement _welcomeMessage;

        public UserHomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string WelcomeMessage { get => _welcomeMessage.Text; }

        public AllEventsPage ClickAllEventsLinkFromPage()
        {
            ClickOnElement(_allEventsLinkFromPage);

            return new AllEventsPage(driver);
        }

        public AllEventsPage ClickAllEventsLinkFromNav()
        {
            ClickOnElement(_eventsDropdownMenuLink);
            ClickOnElement(_allEventsLinkFromNav);

            return new AllEventsPage(driver);
        }

        public CreateEventPage ClickCreateEventLinkFromPage()
        {
            ClickOnElement(_createEventLinkFromPage);

            return new CreateEventPage(driver);
        }

        public CreateEventPage ClickCreateEventLinkFromNav()
        {
            ClickOnElement(_eventsDropdownMenuLink);
            ClickOnElement(_createEventLinkFromNav);

            return new CreateEventPage(driver);
        }

        public HomePage ClickLogoutLink()
        {
            ClickOnElement(_logoutLink);

            return new HomePage(driver);
        }

        public bool IsLogoutLinkDisplayed()
        {
            return IsElementDisplayed(_logoutLink);
        }
    }
}