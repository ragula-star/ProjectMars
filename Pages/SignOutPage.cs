using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class SignOutPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public SignOutPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By SignOutButton => By.XPath("//button[contains(@class,'ui green basic button') and text()='Sign Out']");

        public void ClickSignOut()
        {

            IWebElement signOut = driver.FindElement(SignOutButton);
            signOut.Click();
        }
    }
}
