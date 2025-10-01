using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectMars.Pages
{
    public class LoginPages
    {
        private readonly IWebDriver driver;
        private readonly WaitHelpers waitHelpers;
        public LoginPages(IWebDriver driver, WaitHelpers waitHelpers)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.waitHelpers = waitHelpers ?? throw new ArgumentNullException(nameof(waitHelpers));

        }
        private By Clicksign => By.XPath("//a[text()='Sign In']");
        private By EmailInput => By.XPath("//input[@placeholder='Email address']");
        private By PasswordInput => By.XPath("//input[@placeholder='Password']");
        private By LoginButton => By.XPath("//button[text()='Login']");
        private By Logobutton => By.XPath("//a[@href='/']");
        private By popupMessage => By.XPath("//div[contains(@class,'popup') and text()='Confirm your email']");
        private By UsernameErrorMessage => By.XPath("//input[@placeholder='Email address']/following-sibling::div[contains(@class,'prompt')]");

        private By PasswordErrorMessage => By.XPath("//input[@placeholder='Password']/following-sibling::div[contains(@class,'prompt')]");
        //private By clickjoin => By.XPath("//button[text()='Join']");
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
        private By ClickProfileSkills => By.XPath("//a[text()='Skills']");
        private By AddNewButton => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private By AddButton => By.XPath("//input[@type='button' and @value='Add']");
        private By SkillErrorMessage => By.XPath("//div[contains(text(),'Please enter skill and experience level')]");
        private By Addskillinskills => By.XPath("//input[@placeholder='Add Skill']");
        private By AddChooseSkillLevel => By.XPath("//option[text()='Choose Skill Level']");
        private By ClickCertificate => By.XPath("//a[text()='Certifications']");
        private By ClickCertificateAddnewButton => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private By ClickCertificateAward => By.XPath("//input[@placeholder='Certificate or Award']");
        private By ClickCertificateAwardFrom => By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']");
        private By ClickCertificateAwardYear => By.Name("certificationYear");
        private By ClickCertificateAddfinal => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        private By CertificateTableRows => By.XPath("//div[@id='account-profile-section']//table/tbody/tr");
        private By AlreadyExistMessage => By.XPath("//div[contains(text(),'This information is already exist')]");
        private By ClickEducation => By.XPath("//a[text()='Education']");
        private By ClickEducateADDNew => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private By ClickEducationAdd => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]");
        private By EducationErrorMessage => By.XPath("//div[contains(text(),'Please enter all the fields')]");
        private By ClickDescriptionEditIcon => By.XPath("//i[@class='outline write icon']");
        private By ClickDescriptionOnProfile => By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']");
        private By ClickDescriptionOnprofileSaveBtn => By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button");

        private By DescriptionSuccessMessage => By.XPath("//div[contains(text(),'Description has been saved successfully')]");
        private By ClickDashboard => By.XPath("//a[text()='Dashboard']");
        private By VerifyDashboardMessage => By.XPath("//h1");
        private By ClickManageRequest => By.XPath("//div[text()='Manage Requests']");
        private By MovetoSendRequest => By.XPath("//a[@href='/Home/ReceivedRequest']//*[@id=\"received-request-section\"]/section[1]/div/div[1]/div/a[1]");
        private By VerifyMessages => By.XPath("//div[@class='ui container']/h3");
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
        private By ChatLink => By.XPath("//a[@class='item' and contains(., 'Chat')]");
        private By SignOutButton => By.XPath("//button[contains(@class,'ui green basic button') and text()='Sign Out']");
        private By CategoriesContainer => By.XPath("//div[@class='five wide column' and .//h3[text()='Categories']]");
        private By DigitalMarketingLink => By.XPath(".//a[text()='Digital Marketing']");
        private By NoResultsMessage => By.XPath("//div[@class='ui grid']/h3");
        private By AvailabilityEditIcon => By.XPath("//div[.//strong[text()='Availability']]//i[contains(@class,'write icon')]");
        private By PartTimeOption => By.XPath("//div[@class='ui visible dropdown']//span[text()='Part Time']");
        private By ClickearntargetButton => By.XPath("//div[@class='item']//i[contains(@class,'dollar icon')]/following::i[contains(@class,'write icon')][1]");
        private By EarnTargetSelect => By.Name("availabiltyTarget");
        private By EarnTargetValue => By.XPath("//div[@class='item']//i[contains(@class,'dollar icon')]/following-sibling::span/select/option[@selected]");
        private By AvailabilityUpdatedMessage => By.XPath("//div[contains(@class,'ui message') or contains(@class,'toast')][contains(text(),'Availability updated')]");
        public void ClickAddNewSkill()
        {
            driver.FindElement(AddNewButton).Click();
        }

        public void ClickSignIn()
        {
            driver.FindElement(Clicksign).Click();
        }
        public void EnterusernamePassword(string username, string password)
        {
            driver.FindElement(EmailInput).Clear();
            driver.FindElement(EmailInput).SendKeys(username);
            driver.FindElement(PasswordInput).Clear();
            driver.FindElement(PasswordInput).SendKeys(password);

        }
        public void clickLoginbtn()
        {
            driver.FindElement(LoginButton).Click();
        }
        public bool VerifyLogo()
        {


            return driver.FindElement(Logobutton).Displayed;
        }
        public string GetEmailConfirmPopupText(int timeoutInSeconds = 15)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement popup = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(popupMessage));
                return popup.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public string GetErrorMessage(int timeoutInSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UsernameErrorMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }



        }
        public string passwordErrormsg(int timeoutInSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement PassErrormsg = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(PasswordErrorMessage));
                return PassErrormsg.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public string usernamepasswordInvalidmsg(int timeoutSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement bothError = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UsernameErrorMessage));
                return bothError.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public string usernamepasswordInvalidmsgg(int timeoutSeconds = 5)

        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement bothError = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(PasswordErrorMessage));
                return bothError.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
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
        public string ClickDash(int timeoutSeconds = 5)
        {
            try
            {
                driver.FindElement(ClickDashboard).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(VerifyDashboardMessage));
                return message.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }

        }
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
        public void ClickChat()
        {
            IWebElement chatElement = driver.FindElement(ChatLink);
            chatElement.Click();
        }
        public void ClickSignOut()
        {
           
            IWebElement signOut = driver.FindElement(SignOutButton);
            signOut.Click();
        }
        public void SelectDigitalMarketingCategory()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement container = wait.Until(drv => drv.FindElement(CategoriesContainer));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", container);
            IWebElement digitalMarketingLink = container.FindElement(DigitalMarketingLink);
            digitalMarketingLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(digitalMarketingLink));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", digitalMarketingLink);
        }
        public string GetNoResultsMessage()
        {
            return driver.FindElement(NoResultsMessage).Text;
        }
        public void SelectAvailabilityPartTime()
        {
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           IWebElement editIcon = driver.FindElement(AvailabilityEditIcon);
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editIcon);
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editIcon)).Click();
           IWebElement partTime = wait.Until(driver =>
            {
                try
                {
                    return driver.FindElement(PartTimeOption);
                }
                catch
                {
                    return null;
                }
            });
           partTime.Click();
        }
        public void Clickearn()
        {
            driver.FindElement(ClickearntargetButton).Click();
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement selectElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EarnTargetSelect));

                SelectElement dropdown = new SelectElement(selectElement);
                dropdown.SelectByText("Between $500 and $1000 per month");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Option could not be selected. Possibly backend validation prevents change.");
            }
        }
        public string EarnTargetUpdated()
        {
            try
            {
                return driver.FindElement(AvailabilityUpdatedMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

    }
}


    







    


