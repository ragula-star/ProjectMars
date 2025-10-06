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
    public class CategoriesTest
    {
        private LoginPages loginPages;
        private CategoriesPage categoriesPage;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);
            categoriesPage = new CategoriesPage(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void TestDigitalButton()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            categoriesPage.SelectDigitalMarketingCategory();
            string actualMessage = categoriesPage.GetNoResultsMessage();
            Assert.That(actualMessage, Is.EqualTo("No results found, please select a new category!"));
        }
    }
}
