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
    public class EarnPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public EarnPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickearntargetButton => By.XPath("//div[@class='item']//i[contains(@class,'dollar icon')]/following::i[contains(@class,'write icon')][1]");
        private By EarnTargetSelect => By.Name("availabiltyTarget");
        private By EarnTargetValue => By.XPath("//div[@class='item']//i[contains(@class,'dollar icon')]/following-sibling::span/select/option[@selected]");
        private By AvailabilityUpdatedMessage => By.XPath("//div[contains(@class,'ui message') or contains(@class,'toast')][contains(text(),'Availability updated')]");

        public void Clickearn()
        {
            driver.FindElement(ClickearntargetButton).Click();
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement selectElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EarnTargetSelect));

                SelectElement dropdown = new SelectElement(selectElement);
                dropdown.SelectByText("Between $500 and $1000 per month");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Option could not be selected. Possibly backend validation prevents change.");
            }
        }
        public string EarnTargetUpdated()
        {
            try
            {
                return driver.FindElement(AvailabilityUpdatedMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
