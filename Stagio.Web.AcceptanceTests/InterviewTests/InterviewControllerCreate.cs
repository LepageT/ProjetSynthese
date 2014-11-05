using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreate : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_add_interview_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            CreateInterviewStudentPage.GoTo();

            Assert.IsTrue(CreateInterviewStudentPage.IsDisplayed);

        }

        [TestMethod]
        public void student_should_not_be_able_to_see_the_page_to_add_interview_if_not_logged_in_and_redirected_to_login()
        {
            CreateInterviewStudentPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
            
        }

        [TestMethod]
        public void student_should_be_able_to_add_interview()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            CreateInterviewStudentPage.GoTo();
            CreateInterviewStudentPage.AddInterview();

            Assert.IsTrue(CreateInterviewStudentPage.ConfirmationIsDisplayed);

            /*AuthentificateTestUser(StudentUsername, StudentPassword);

            _driver.Navigate().GoToUrl("http://thomarelau.local/Interview/Create");

            const string DATE = "2014-12-21";

            IWebElement oSelection = _driver.FindElement(By.Id("StageId"));
            SelectElement dropdown = new SelectElement(oSelection);
            dropdown.SelectByIndex(1);

            _driver.FindElement(By.Id("Date")).Clear();
            _driver.FindElement(By.Id("Date")).SendKeys(DATE);
            _driver.FindElement(By.Id("create-interview")).Click();

            try
            {
                _driver.FindElement(By.Id("interview-confirmation"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant interview-confirmation non trouvé sur la page.");
            }*/
        }
    }
}
