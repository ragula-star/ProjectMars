using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Utilities
{
    public class WaitHelpers
    {
        private readonly IWebDriver driver;
        public WaitHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WaitForElementVisible(By Locator, int Seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(Locator));
        }
        public IWebElement WaitForElementClickable(By locator, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
