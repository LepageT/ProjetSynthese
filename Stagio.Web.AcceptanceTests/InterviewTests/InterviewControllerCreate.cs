using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Stagio.Web.AcceptanceTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreate : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_add_interview_if_logged_in()
        {
            AuthentificateTestUser(StudentUsername, StudentPassword);

            _driver.Navigate().GoToUrl("http://thomarelau.local/Interview/Create");

            try
            {
                _driver.FindElement(By.Id("interview-add"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant interview-add non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void student_should_not_be_able_to_see_the_page_to_add_interview_if_not_logged_in_and_redirected_to_login()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Interview/Create");

            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant login-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void student_should_be_able_to_add_interview()
        {
            AuthentificateTestUser(StudentUsername, StudentPassword);

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
            }
        }
    }
}
