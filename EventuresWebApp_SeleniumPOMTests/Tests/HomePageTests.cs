﻿using EventuresWebApp_SeleniumPOMTests.PageObjects;
using NUnit.Framework;

namespace EventuresWebApp_SeleniumPOMTests.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
    {
        [Test]
        public void Test_HomePage_LoginPageLink_InNavigation()
        {
            // Arrange: Go to Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: Click on the Login link, located in the Navigation bar
            var loginPage = homePage.ClickLoginLinkFromNav();

            // Assert: Verify the user is redirected to Log In page and the user can see the Log In form
            Assert.True(loginPage.IsLoginUrlCorrect(), "The URL is NOT correct!");
            Assert.True(loginPage.IsLogInFormDisplayed(), "The Log In form is NOT visible!");
        }

        [Test]
        public void Test_HomePage_LoginPageLink_OnMainPage()
        {
            // Arrange: Go to Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: Click on the Login link, located on the Main page
            var loginPage = homePage.ClickLoginLinkFromPage();

            // Assert: Verify the user is redirected to Log In page and the user can see the Log In form
            Assert.True(loginPage.IsLoginUrlCorrect(), "The URL is NOT correct!");
            Assert.True(loginPage.IsLogInFormDisplayed(), "The Log In form is NOT visible!");
        }

        [Test]
        public void Test_HomePage_RegisterPageLink_InNavigation()
        {
            // Arrange: Go to Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: Click on the Register link, located in the Navigation bar
            var registerPage = homePage.ClickRegisterLinkFromNav();

            // Assert: Verify the user is redirected to Register page and the user can see the Register form
            Assert.True(registerPage.IsRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.True(registerPage.IsRegisterFormDisplayed(), "The Register form is NOT visible!");
        }

        [Test]
        public void Test_HomePage_RegisterPageLink_OnMainPage()
        {
            // Arrange: Go to Home page on the Eventures web application
            homePage.NavigateToHomePage();

            // Act: Click on the Register link, located on the Main page
            var registerPage = homePage.ClickRegisterLinkFromPage();

            // Assert: Verify the user is redirected to Register page and the user can see the Register form
            Assert.True(registerPage.IsRegisterUrlCorrect(), "The URL is NOT correct!");
            Assert.True(registerPage.IsRegisterFormDisplayed(), "The Register form is NOT visible!");
        }
    }
}