using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Login']")]
        private IWebElement _loginLinkFromPage;

        [FindsBy(How = How.CssSelector, Using = "a.nav-link[href='/Identity/Account/Login']")]
        private IWebElement _loginLinkFromNav;

        [FindsBy(How = How.CssSelector, Using = ".mt-4 [href='/Identity/Account/Register']")]
        private IWebElement _registerLinkFromPage;

        [FindsBy(How = How.CssSelector, Using = "a.nav-link[href='/Identity/Account/Register']")]
        private IWebElement _registerLinkFromNav;

        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public LoginPage ClickLoginLinkFromPage()
        {
            ClickOnElement(_loginLinkFromPage);
            return new LoginPage(driver);
        }

        public LoginPage ClickLoginLinkFromNav()
        {
            ClickOnElement(_loginLinkFromNav);
            return new LoginPage(driver);
        }

        public RegisterPage ClickRegisterLinkFromPage()
        {
            ClickOnElement(_registerLinkFromPage);
            return new RegisterPage(driver);
        }

        public RegisterPage ClickRegisterLinkFromNav()
        {
            ClickOnElement(_registerLinkFromNav);
            return new RegisterPage(driver);
        }
    }
}