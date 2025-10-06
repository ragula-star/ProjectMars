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
    public class DashboardTest
    {
        private LoginPages loginPages;
        private DashboardPage dashboardPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            dashboardPage = new DashboardPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void testDash()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            dashboardPage.ClickDash();
        }
    }
}
