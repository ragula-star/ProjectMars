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
    public class EarnTest
    {
        private LoginPages loginPages;
        private EarnPage earnPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            earnPage = new EarnPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void Testearn()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.Clickearn();
            string msg = loginPages.EarnTargetUpdated();
            Assert.That(msg, Is.EqualTo("Availability updated"), "no messages");









        }
    }
}
