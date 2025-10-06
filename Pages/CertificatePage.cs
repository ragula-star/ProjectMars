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
    public class CertificatePage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public CertificatePage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickCertificate => By.XPath("//a[text()='Certifications']");
        private By ClickCertificateAddnewButton => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private By ClickCertificateAward => By.XPath("//input[@placeholder='Certificate or Award']");
        private By ClickCertificateAwardFrom => By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']");
        private By ClickCertificateAwardYear => By.Name("certificationYear");
        private By ClickCertificateAddfinal => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        private By CertificateTableRows => By.XPath("//div[@id='account-profile-section']//table/tbody/tr");
        private By AlreadyExistMessage => By.XPath("//div[contains(text(),'This information is already exist')]");

        public void TestCertificate()
        {
            driver.FindElement(ClickCertificate).Click();
            driver.FindElement(ClickCertificateAddnewButton).Click();
            driver.FindElement(ClickCertificateAward).SendKeys("best testing engineer");
            driver.FindElement(ClickCertificateAwardFrom).SendKeys("Microsoft");

            IWebElement awardYearDropdown = driver.FindElement(ClickCertificateAwardYear);
            SelectElement select = new SelectElement(awardYearDropdown);
            select.SelectByValue("2023");
            driver.FindElement(ClickCertificateAddfinal).Click();

        }
        public bool IsCertificateAdded(string certificateName)
        {
            var rows = driver.FindElements(CertificateTableRows);
            foreach (var row in rows)
            {
                if (row.Text.Contains(certificateName))
                {
                    return true;
                }
            }
            return false;
        }
        public string GetAlreadyExistMessage(int timeoutInSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AlreadyExistMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

    }
}
