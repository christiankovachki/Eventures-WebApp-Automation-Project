using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class BasePage
    {
        protected const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:81";
        protected IWebDriver driver;
        private WebDriverWait wait;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        protected void ClickOnElement(IWebElement webElement)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            webElement.Click();
        }

        protected void TypeInField(IWebElement webElement, string input)
        {
            WaitForVisibilityOfElement(webElement);
            webElement.SendKeys(input);
        }

        protected void WaitForVisibilityOfElement(IWebElement webElement)
        {
            wait.Until(x => webElement.Displayed);
        }

        protected void WaitUrlToBe(string url)
        {
            wait.Until(ExpectedConditions.UrlToBe(url));
        }

        protected bool isUrlCorrect(string url)
        {
            return driver.Url.Equals(url);
        }
    }
}