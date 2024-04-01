using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class RegisterPage : BasePage
    {
        private const string RegisterUrl = BaseUrl + "/Identity/Account/Register";

        [FindsBy(How = How.CssSelector, Using = "form[method = 'post']")]
        private IWebElement _registerForm;

        [FindsBy(How = How.Id, Using = "Input_Username")]
        private IWebElement _usernameField;

        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement _emailField;

        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "Input_ConfirmPassword")]
        private IWebElement _confirmPasswordField;

        [FindsBy(How = How.Id, Using = "Input_FirstName")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.Id, Using = "Input_LastName")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.CssSelector, Using = "button.btn")]
        private IWebElement _registerButton;

        [FindsBy(How = How.Id, Using = "Input_Username-error")]
        private IWebElement _usernameFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Input_Email-error")]
        private IWebElement _emailFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Input_Password-error")]
        private IWebElement _passwordFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Input_ConfirmPassword-error")]
        private IWebElement _confirmPasswordFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Input_FirstName-error")]
        private IWebElement _firstNameFieldErrorMessage;

        [FindsBy(How = How.Id, Using = "Input_LastName-error")]
        private IWebElement _lastNameFieldErrorMessage;

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToRegisterPage()
        {
            HomePage homePage = new HomePage(driver);

            homePage.NavigateToHomePage();
            homePage.ClickRegisterLink();
            WaitUrlToBe(RegisterUrl);
            WaitForVisibilityOfElement(_registerForm);
        }

        public UserHomePage RegisterUser(string username, string email, string password, string confirmPassword, string firstName, string lastName)
        {
            TypeInField(_usernameField, username);
            TypeInField(_emailField, email);
            TypeInField(_passwordField, password);
            TypeInField(_confirmPasswordField, confirmPassword);
            TypeInField(_firstNameField, firstName);
            TypeInField(_lastNameField, lastName);

            ClickOnElement(_registerButton);

            return new UserHomePage(driver);
        }

        public bool isRegisterFormDisplayed()
        {
            return _registerForm.Displayed;
        }

        public string UsernameFieldErrorMessage { get => _usernameFieldErrorMessage.Text; }
        public string EmailFieldErrorMessage { get => _emailFieldErrorMessage.Text; }
        public string PasswordFieldErrorMessage { get => _passwordFieldErrorMessage.Text; }
        public string ConfirmPasswordFieldErrorMessage { get => _confirmPasswordFieldErrorMessage.Text; }
        public string FirstNameFieldErrorMessage { get => _firstNameFieldErrorMessage.Text; }
        public string LastNameFieldErrorMessage { get => _lastNameFieldErrorMessage.Text; }
    }
}