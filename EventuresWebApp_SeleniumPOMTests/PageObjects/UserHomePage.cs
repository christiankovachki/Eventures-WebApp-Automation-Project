using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class UserHomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Events/All']")]
        private IWebElement _allEventsFromLink;

        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Events/Create']")]
        private IWebElement _createEventFromLink;

        [FindsBy(How = How.CssSelector, Using = "h1.text-center")]
        private IWebElement _welcomeMessage;

        public UserHomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string WelcomeMessage { get => _welcomeMessage.Text; }
    }
}