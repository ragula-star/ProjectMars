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
    public class ManageRequestPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public ManageRequestPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ClickManageRequest => By.XPath("//div[text()='Manage Requests']");
        private By MovetoSendRequest => By.XPath("//a[@href='/Home/ReceivedRequest']//*[@id=\"received-request-section\"]/section[1]/div/div[1]/div/a[1]");
        private By VerifyMessages => By.XPath("//div[@class='ui container']/h3");

        public void ClickMouseHover()
        {


            driver.FindElement(ClickManageRequest).Click();
            driver.FindElement(ClickManageRequest).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(@class,'menu') and contains(@class,'visible')]")
            ));


            IWebElement receivedRequests = driver.FindElement(By.XPath("//a[@href='/Home/ReceivedRequest']"));
            receivedRequests.Click();
        }
        public string GetReceivedRequestMessage()
        {
            try
            {
                return driver.FindElement(VerifyMessages).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
