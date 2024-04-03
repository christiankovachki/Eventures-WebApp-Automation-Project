using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventuresWebApp_SeleniumPOMTests.PageObjects
{
    public class CreateEventPage : BasePage
    {
        private const string CreateEventUrl = BaseUrl + "/Events/Create";

        public CreateEventPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool isCreateEventUrlCorrect()
        {
            return isUrlCorrect(CreateEventUrl);
        }
    }
}