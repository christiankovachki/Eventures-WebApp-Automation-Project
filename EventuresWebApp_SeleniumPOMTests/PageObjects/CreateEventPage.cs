using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class CreateEventPage : BasePage
    {
        private const string CreateEventUrl = BaseUrl + "/Events/Create";

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'Create New Event')]")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Back to List')]")]
        private IWebElement _backToListLink;

        public CreateEventPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool isCreateEventUrlCorrect()
        {
            return isUrlCorrect(CreateEventUrl);
        }

        public bool isBackToListLinkDisplayed()
        {
            return _backToListLink.Displayed;
        }

        public string PageHeader { get => _pageHeader.Text; }
    }
}