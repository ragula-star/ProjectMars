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
    public class ShareskillPages
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public ShareskillPages (IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));
        }
        private By ClickShareSkill => By.XPath("//a[text()='Share Skill']");
        private By Clicksave => By.XPath("//input[@value='Save']");
        private By ShareSkillErrorMessage => By.XPath("//div[contains(text(),'Please complete the form correctly')]");
        private By FillShareSkillTitle => By.XPath("//input[@placeholder='Write a title to describe the service you provide.']");
        private By FillShareSkillDiscription => By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']");
        private By FillShareSkillCategory => By.XPath("//select[@name='categoryId']");
        private By FillShareSkillTags => By.XPath("//input[@placeholder='Add new tag']");
        private By FillShareSkillServiceType => By.XPath("//input[@value='1']");
        private By FillShareSkillLocationType => By.XPath("//input[@name='locationType']");
        private By FillShareSkillTrade => By.XPath("//input[@name='skillTrades']");
        private By FillShareSkillSkillExchange => By.CssSelector("input.ReactTags__tagInputField");
        private By FillShareSkillWorkSample => By.XPath("//i[@class='huge plus circle icon padding-25']");
        private By FillShareSkillActive => By.XPath("//input[@name='isActive']");

        public void ShareSkill()
        {
            driver.FindElement(ClickShareSkill).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            driver.FindElement(Clicksave).Click();
        }
        public string ShareskillNotify(int timeoutSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement bothError = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ShareSkillErrorMessage));
                return bothError.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public void FillShareSkillForm()
        {
            driver.FindElement(ClickShareSkill).Click();
            driver.FindElement(FillShareSkillTitle).SendKeys("Selenium Automation");
            driver.FindElement(FillShareSkillDiscription).SendKeys("Automation skill");

            IWebElement categoryDropdown = driver.FindElement(FillShareSkillCategory);
            SelectElement select = new SelectElement(categoryDropdown);
            select.SelectByText("Test Automation");

            IWebElement tagsElement = driver.FindElement(FillShareSkillTags);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", tagsElement);
            tagsElement.SendKeys("Automation");
            tagsElement.SendKeys(Keys.Enter);

            driver.FindElement(FillShareSkillServiceType).Click();
            driver.FindElement(FillShareSkillLocationType).Click();

            IJavaScriptExecutor jss = (IJavaScriptExecutor)driver;
            jss.ExecuteScript("window.scrollBy(0,500);");

            driver.FindElement(FillShareSkillSkillExchange).SendKeys("tester");

            //IWebElement upload = driver.FindElement(FillShareSkillWorkSample);
            //upload.SendKeys(@"C:\Users\muthu\OneDrive\Pictures\Screenshots\Screenshot 2025-09-28 121207.png");

            driver.FindElement(FillShareSkillActive).Click();
            driver.FindElement(Clicksave).Click();


        }
    }
}
