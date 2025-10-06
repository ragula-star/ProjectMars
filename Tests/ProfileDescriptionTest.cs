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
    public class ProfileDescriptionTest
    {
        private LoginPages loginPages;
        private ProfileDescriptionPage profileDescriptionPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            profileDescriptionPage = new ProfileDescriptionPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void TestDescriptionInvalid()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.FillProfileDescription();
            string message = loginPages.GetSuccessMessage();
            Assert.That(message, Is.EqualTo("Description has been saved successfully"), "Success message not displayed!");
        }
    }
}
