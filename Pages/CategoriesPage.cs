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
    public class CategoriesPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public CategoriesPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By CategoriesContainer => By.XPath("//div[@class='five wide column' and .//h3[text()='Categories']]");
        private By DigitalMarketingLink => By.XPath(".//a[text()='Digital Marketing']");
        private By NoResultsMessage => By.XPath("//div[@class='ui grid']/h3");

        public void SelectDigitalMarketingCategory()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement container = wait.Until(drv => drv.FindElement(CategoriesContainer));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", container);
            IWebElement digitalMarketingLink = container.FindElement(DigitalMarketingLink);
            digitalMarketingLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(digitalMarketingLink));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", digitalMarketingLink);
        }
        public string GetNoResultsMessage()
        {
            return driver.FindElement(NoResultsMessage).Text;
        }
    }
}
