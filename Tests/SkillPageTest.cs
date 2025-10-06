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
    public class SkillPageTest
    {
        private LoginPages loginPages;
        private SkillPage skillPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            skillPage = new SkillPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void TestSkillsPositive()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.PositiveSkills();
        }
        [Test]
        public void NegativeSkills()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickSkills();
            string errorMessage = loginPages.SkillErrorMessages();
            Assert.That(errorMessage, Is.EqualTo("Please enter skill and experience level"), "Validation message not displayed");


        }
    }
}
