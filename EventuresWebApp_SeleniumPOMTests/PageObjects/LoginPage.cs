using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class LoginPage : BasePage
    {
        private const string LoginUrl = BaseUrl + "/Identity/Account/Login";

        [FindsBy(How = How.Id, Using = "account")]
        private IWebElement _loginForm;

        [FindsBy(How = How.Id, Using = "Input_Username")]
        private IWebElement _usernameField;

        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = "button.btn")]
        private IWebElement _logInButton;

        [FindsBy(How = How.Id, Using = "Input_Username-error")]
        private IWebElement _requiredUsernameMessage;

        [FindsBy(How = How.Id, Using = "Input_Password-error")]
        private IWebElement _requiredPasswordMessage;

        [FindsBy(How = How.CssSelector, Using = ".validation-summary-errors li")]
        private IWebElement _invalidAttemptMessage;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string RequiredUsernameMessage { get => _requiredUsernameMessage.Text; }

        public string RequiredPasswordMessage { get => _requiredPasswordMessage.Text; }

        public string InvalidAttemptMessage { get => _invalidAttemptMessage.Text; }

        public void NavigateToLogInPage()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToHomePage();
            homePage.ClickLoginLinkFromPage();
            WaitUrlToBe(LoginUrl);
            WaitForVisibilityOfElement(_loginForm);
        }

        public UserHomePage LogInUser(string username, string password)
        {
            TypeInField(_usernameField, username);
            TypeInField(_passwordField, password);

            ClickOnElement(_logInButton);

            return new UserHomePage(driver);
        }

        public bool IsLogInFormDisplayed()
        {
            return IsElementDisplayed(_loginForm);
        }

        public bool IsLoginUrlCorrect()
        {
            return IsUrlCorrect(LoginUrl);
        }
    }
}