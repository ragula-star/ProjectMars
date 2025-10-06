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
    public class ProfileTitlePage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public ProfileTitlePage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ProfileTitle => By.XPath("//div[@class='title' and contains(.,'Ra Gula')]");
        private By VerifyprofileName => By.CssSelector("div.title");
        private By UserDropdown => By.XPath("//span[contains(@class,'ui dropdown') and contains(.,'Hi Ra')]");
        private By ChangePasswordLink => By.XPath("//div[@class='menu transition visible']//a[text()='Change Password']");
        private By CurrentPassword => By.XPath("//input[@placeholder='Current Password']");
        private By NewPassword => By.XPath("//input[@placeholder='New Password']");
        private By ConfirmPassword => By.XPath("//input[@placeholder='Confirm Password']");
        private By SavePasswordButton => By.XPath("//div[@class='field']/button[@type='button' and text()='Save']");
        private By TransactionLink => By.XPath("//a[@href='/Account/Transaction']");
        private By CurrentBalance => By.XPath("//div[@class='ui mini right floated statistic']/div[@class='value']");

        private By ClicksearchIcon => By.XPath("//input[@placeholder='Search skills']");
        private By ClickTestAutomation => By.XPath("//a[@role='listitem' and contains(., 'Test Automation')]");


        public string CheckProfile(int timeoutSeconds)
        {

            try
            {
                driver.FindElement(ProfileTitle).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(VerifyprofileName));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public void GoToChangePassword()
        {
            driver.FindElement(UserDropdown).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(ChangePasswordLink).Displayed);
            driver.FindElement(ChangePasswordLink).Click();
        }
        public void ChangePassword(string oldPwd, string newPwd)
        {

            driver.FindElement(UserDropdown).Click();
            driver.FindElement(ChangePasswordLink).Click();
            driver.FindElement(CurrentPassword).Clear();
            driver.FindElement(CurrentPassword).SendKeys(oldPwd);
            driver.FindElement(NewPassword).Clear();
            driver.FindElement(NewPassword).SendKeys(newPwd);
            driver.FindElement(ConfirmPassword).Clear();
            driver.FindElement(ConfirmPassword).SendKeys(newPwd);

            driver.FindElement(SavePasswordButton).Click();
        }
        public void OpenTransactionPage()
        {
            driver.FindElement(UserDropdown).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement transactionLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TransactionLink));
            transactionLink.Click();

        }

        public string GetCurrentBalance()
        {
            return driver.FindElement(CurrentBalance).Text;
        }
        public void ClickIcon()
        {
            IWebElement input = driver.FindElement(ClicksearchIcon);
            input.Clear();
            input.SendKeys("Test Automation");
            input.SendKeys(Keys.Enter);
        }
        public void ClickTestAuto()
        {
            driver.FindElement(ClickTestAutomation).Click();
        }
    }
}
