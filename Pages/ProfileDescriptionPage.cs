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
    public class ProfileDescriptionPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public ProfileDescriptionPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickDescriptionEditIcon => By.XPath("//i[@class='outline write icon']");
        private By ClickDescriptionOnProfile => By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']");
        private By ClickDescriptionOnprofileSaveBtn => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button");

        private By DescriptionSuccessMessage => By.XPath("//div[contains(text(),'Description has been saved successfully')]");

        public void FillProfileDescription()
        {
            driver.FindElement(ClickDescriptionEditIcon).Click();
            driver.FindElement(ClickDescriptionOnProfile).Click();
            string longText = new string('A', 6001);
            IWebElement descriptionField = driver.FindElement(ClickDescriptionOnProfile);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('input'));", descriptionField, longText);
            driver.FindElement(ClickDescriptionOnprofileSaveBtn).Click();


        }
        public string GetSuccessMessage(int timeoutSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(DescriptionSuccessMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
    }
}
