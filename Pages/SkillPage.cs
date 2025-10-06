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
    public class SkillPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public SkillPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickProfileSkills => By.XPath("//a[text()='Skills']");
        private By AddNewButton => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private By AddButton => By.XPath("//input[@type='button' and @value='Add']");
        private By SkillErrorMessage => By.XPath("//div[contains(text(),'Please enter skill and experience level')]");
        private By Addskillinskills => By.XPath("//input[@placeholder='Add Skill']");
        private By AddChooseSkillLevel => By.XPath("//option[text()='Choose Skill Level']");

        public void ClickSkills()
        {
            driver.FindElement(ClickProfileSkills).Click();
            driver.FindElement(AddNewButton).Click();
            driver.FindElement(AddButton).Click();
        }
        public string SkillErrorMessages(int timeoutSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement bothError = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SkillErrorMessage));
                return bothError.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }

        }
        public void PositiveSkills()
        {
            driver.FindElement(ClickProfileSkills).Click();
            driver.FindElement(AddNewButton).Click();
            driver.FindElement(Addskillinskills).SendKeys("Tester");

            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SelectElement select = new SelectElement(skillLevelDropdown);
            select.SelectByText("Beginner");
            driver.FindElement(AddButton).Click();
        }

    }

}
