using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class ChatPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public ChatPage(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By ChatLink => By.XPath("//a[@class='item' and contains(., 'Chat')]");
        public void ClickChat()
        {
            IWebElement chatElement = driver.FindElement(ChatLink);
            chatElement.Click();
        }
    }
}
