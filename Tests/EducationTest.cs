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
    public class EducationTest
    {
        private LoginPages loginPages;
        private EducationPage educationPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            educationPage = new EducationPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void TestEducationNegative()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            educationPage.NegativeTestEducation();
            string errorMessage = educationPage.GetEducationErrorMessage();
            Assert.That(errorMessage, Is.EqualTo("Please enter all the fields"), "Expected error message not displayed!");
        }
    }
}
