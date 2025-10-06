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
    public class CertificateTest
    {
        private LoginPages loginPages;
        private CertificatePage certificatePage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            certificatePage = new CertificatePage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void TestCertificates()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            certificatePage.TestCertificate();
            string message = certificatePage.GetAlreadyExistMessage();
            Assert.That(message, Is.EqualTo("This information is already exist."), "Expected 'already exist' message not displayed.");
        }
    }
}
