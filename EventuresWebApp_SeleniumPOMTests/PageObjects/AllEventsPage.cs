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

        public AllEventsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool isAllEventsUrlCorrect()
        {
            return isUrlCorrect(AllEventsUrl);
        }

        public bool isCreateNewLinkDisplayed()
        {
            return _createNewLink.Displayed;
        }

        public string PageHeader { get => _pageHeader.Text; }
    }
}