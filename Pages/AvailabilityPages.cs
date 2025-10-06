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
    public class AvailabilityPages
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public AvailabilityPages(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By AvailabilityEditIcon => By.XPath("//div[.//strong[text()='Availability']]//i[contains(@class,'write icon')]");
        private By PartTimeOption => By.XPath("//div[@class='ui visible dropdown']//span[text()='Part Time']");

        public void SelectAvailabilityPartTime()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement editIcon = driver.FindElement(AvailabilityEditIcon);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editIcon);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editIcon)).Click();
            IWebElement partTime = wait.Until(driver =>
            {
                try
                {
                    return driver.FindElement(PartTimeOption);
                }
                catch
                {
                    return null;
                }
            });
            partTime.Click();
        }
    }
}
