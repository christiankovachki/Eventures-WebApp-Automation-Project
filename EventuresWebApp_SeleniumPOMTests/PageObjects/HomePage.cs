using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Login']")]
        private IWebElement _loginLink;

        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Register']")]
        private IWebElement _registerLink;

        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
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
    }
}