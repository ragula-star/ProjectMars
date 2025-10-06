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
    public class EducationPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public EducationPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickEducation => By.XPath("//a[text()='Education']");
        private By ClickEducateADDNew => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private By ClickEducationAdd => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]");
        private By EducationErrorMessage => By.XPath("//div[contains(text(),'Please enter all the fields')]");

        public void NegativeTestEducation()
        {
            driver.FindElement(ClickEducation).Click();
            driver.FindElement(ClickEducateADDNew).Click();
            driver.FindElement(ClickEducationAdd).Click();
        }
        public string GetEducationErrorMessage(int timeoutInSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EducationErrorMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
    }

}
