using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Drivers;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectMars.Utilities.Configue;


namespace ProjectMars.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private LoginPages loginPages;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void Validlogin()
        {
            //DriverFactory.initDriver();
            //var waitHelper = new WaitHelpers(DriverFactory.driver);
            //var loginPages = new LoginPages(DriverFactory.driver, waitHelper);

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            Assert.That(loginPages.VerifyLogo(), Is.True, "Mars logo is not displayed");
            DriverFactory.TearDown();
        }
        [Test]
        public void InvalidEmailLoginTest()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("wrongemail@example.com", Config.password);
            loginPages.clickLoginbtn();
            DriverFactory.TearDown();
            string toastText = loginPages.GetEmailConfirmPopupText(5);
            Assert.That(toastText, Is.EqualTo("Confirm your email"), "Expected email confirmation toast not displ*/ayed");
        }
        [Test]
        public void Invalidusername()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("  Ragula6@gmail.com  ", Config.password);
            loginPages.clickLoginbtn();
            string text = loginPages.GetErrorMessage(5);
            Assert.That(text, Is.EqualTo("Please enter a valid email address"), "not displayed");

            DriverFactory.TearDown();
        }
        [Test]
        public void InvalidPasswordmessage()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, "Ragu");
            loginPages.clickLoginbtn();
            string textmsg = loginPages.passwordErrormsg(5);
            Assert.That(textmsg, Is.EqualTo("Password must be at least 6 characters"), "not displayed");
        }
        [Test]
        public void Emptyusernamepassword()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("", "");
            loginPages.clickLoginbtn();
            string textmessages = loginPages.usernamepasswordInvalidmsg(5);
            Assert.That(textmessages, Is.EqualTo("Please enter a valid email address"), "not displayed");
            string textmessages2 = loginPages.usernamepasswordInvalidmsgg(5);
            Assert.That(textmessages2, Is.EqualTo("Password must be at least 6 characters"), "not displayed");

        }

    }
}
