using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Drivers;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectMars.Utilities.Configue;


namespace ProjectMars.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private LoginPages loginPages;
        [SetUp]
        public void Setup()
        {
            DriverFactory.initDriver();
            DriverFactory.driver.Navigate().GoToUrl(Config.BaseUrl);
            var waitHelper = new WaitHelpers(DriverFactory.driver);
            loginPages = new LoginPages(DriverFactory.driver, waitHelper);

        }
        [Test]
        public void Validlogin()
        {
            //DriverFactory.initDriver();
            //var waitHelper = new WaitHelpers(DriverFactory.driver);
            //var loginPages = new LoginPages(DriverFactory.driver, waitHelper);

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            Assert.That(loginPages.VerifyLogo(), Is.True, "Mars logo is not displayed");
            DriverFactory.TearDown();
        }
        [Test]
        public void InvalidEmailLoginTest()
        {
            
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("wrongemail@example.com", Config.password);
            loginPages.clickLoginbtn();
            DriverFactory.TearDown();
            string toastText = loginPages.GetEmailConfirmPopupText(5);
            Assert.That(toastText, Is.EqualTo("Confirm your email"), "Expected email confirmation toast not displ*/ayed");
        }
        [Test]
        public void Invalidusername()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("  Ragula6@gmail.com  ", Config.password);
            loginPages.clickLoginbtn();
            string text = loginPages.GetErrorMessage(5);
            Assert.That(text, Is.EqualTo("Please enter a valid email address"), "not displayed");

            DriverFactory.TearDown();
        }
        [Test]
        public void InvalidPasswordmessage()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, "Ragu");
            loginPages.clickLoginbtn();
            string textmsg = loginPages.passwordErrormsg(5);
            Assert.That(textmsg, Is.EqualTo("Password must be at least 6 characters"), "not displayed");
        }
        [Test]
        public void Emptyusernamepassword()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword("", "");
            loginPages.clickLoginbtn();
            string textmessages = loginPages.usernamepasswordInvalidmsg(5);
            Assert.That(textmessages, Is.EqualTo("Please enter a valid email address"), "not displayed");
            string textmessages2 = loginPages.usernamepasswordInvalidmsgg(5);
            Assert.That(textmessages2, Is.EqualTo("Password must be at least 6 characters"), "not displayed");
                
        }
        [Test]
        public void NegativeShareSkilll()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ShareSkill();
            string ShareskillMessage = loginPages.ShareskillNotify(5);
            Assert.That(ShareskillMessage, Is.EqualTo("Please complete the form correctly."), "Error message not displayed");
                

        }
        [Test]
        public void SaveShareSkillinfo()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.FillShareSkillForm();
        }
        [Test]
        public void NegativeSkills()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickSkills();
            string errorMessage = loginPages.SkillErrorMessages();
            Assert.That(errorMessage, Is.EqualTo("Please enter skill and experience level"), "Validation message not displayed");


        }
        [Test]
        public void TestSkillsPositive()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.PositiveSkills();
        }
        [Test]
        public void TestCertificates()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.TestCertificate();
            string message = loginPages.GetAlreadyExistMessage();
            Assert.That(message, Is.EqualTo("This information is already exist."), "Expected 'already exist' message not displayed.");
        }
        [Test]
        public void TestEducationNegative()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.NegativeTestEducation();
            string errorMessage = loginPages.GetEducationErrorMessage();
            Assert.That(errorMessage, Is.EqualTo("Please enter all the fields"), "Expected error message not displayed!");
        }
        [Test]
        public void TestDescriptionInvalid()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.FillProfileDescription();
            string message = loginPages.GetSuccessMessage();
            Assert.That(message, Is.EqualTo("Description has been saved successfully"), "Success message not displayed!");
        }
        [Test]
        public void testDash()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickDash();
        }
        [Test]
        public void VerifyNoReceivedRequestsMessage()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();

            loginPages.ClickMouseHover(); 
            string message = loginPages.GetReceivedRequestMessage();

            Assert.That(message, Is.EqualTo("You do not have any received requests!"),
                "The expected message was not displayed.");
        }
        [Test]
        public void VerifyProfileName()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            string messagee = loginPages.CheckProfile(5);
            Assert.That(messagee, Is.EqualTo("Ra Gula"), "Profile name does not match");

        }
        [Test]
        public void TestChangePassword_Success()
        {

            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            string oldPwd = "Ragula123@";
            string newPwd = "Ragula12345@";
            loginPages.ChangePassword(oldPwd, newPwd);
        }
        [Test]
        public void VerifyCurrentBalance()
        {
           
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.OpenTransactionPage();
            loginPages.GetCurrentBalance();

           }
        [Test]
        public void SearchIconTest()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickIcon();
        }
        [Test]
        public void SEarchTestAuto()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickIcon();
            loginPages.ClickTestAuto();
        }
        [Test]
        public void ClickChatTest()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickChat();
        }
        [Test]
        public void Signout()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.ClickSignOut();
        }
        [Test]
        public void TestDigitalButton()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.SelectDigitalMarketingCategory();
            string actualMessage = loginPages.GetNoResultsMessage();
            Assert.That(actualMessage, Is.EqualTo("No results found, please select a new category!"));
        }
        [Test]
        public void TestAvailability()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.SelectAvailabilityPartTime();
        }
        [Test]
        public void Testearn()
        {
            loginPages.ClickSignIn();
            loginPages.EnterusernamePassword(Config.username, Config.password);
            loginPages.clickLoginbtn();
            loginPages.Clickearn();
            string msg = loginPages.EarnTargetUpdated();
            Assert.That(msg, Is.EqualTo("Availability updated"), "no messages");
            

            
            


           


        }

    }

}

    
        
    


    

