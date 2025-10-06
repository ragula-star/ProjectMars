using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public DashboardPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickDashboard => By.XPath("//a[text()='Dashboard']");
        private By VerifyDashboardMessage => By.XPath("//h1");

        public string ClickDash(int timeoutSeconds = 5)
        {
            try
            {
                driver.FindElement(ClickDashboard).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(VerifyDashboardMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }

        }
    }
}
