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
    public class ManageRequestTest
    {
        private LoginPages loginPages;
        private ManageRequestPage manageRequestPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            manageRequestPage = new ManageRequestPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void VerifyNoReceivedRequestsMessage()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();

            loginPages.ClickMouseHover();
            string message = loginPages.GetReceivedRequestMessage();

            Assert.That(message, Is.EqualTo("You do not have any received requests!"),
                "The expected message was not displayed.");
        }
    }
}
