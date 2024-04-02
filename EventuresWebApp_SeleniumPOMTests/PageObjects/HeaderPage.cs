using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class HeaderPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Login']")]
        private IWebElement _loginLink;
        
        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Register']")]
        private IWebElement _registerLink;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), \"Logout\")]")]
        private IWebElement _logoutLink;

        [FindsBy(How = How.Id, Using = "dropdownMenuLink")]
        private IWebElement _eventsDropdownMenuLink;

        [FindsBy(How = How.CssSelector, Using = ".dropdown-item[href='/Events/All']")]
        private IWebElement _allEventsFromDropdown;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create Event')]")]
        private IWebElement _createEventFromDropdown;

        public HeaderPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LoginPage ClickLoginLink()
        {
            ClickOnElement(_loginLink);
            return new LoginPage(driver);
        }

        public RegisterPage ClickRegisterLink()
        {
            ClickOnElement(_registerLink);
            return new RegisterPage(driver);
        }

        public HomePage ClickLogoutLink()
        {
            ClickOnElement(_logoutLink);
            return new HomePage(driver);
        }

        public bool isLogoutLinkDisplayed()
        {
            WaitForVisibilityOfElement(_logoutLink);
            return _logoutLink.Displayed;
        }
    }
}