using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateListTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_the_page_createList_student_if_logged_in()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
            _driver.FindElement(By.Id("file")).SendKeys("C:\\dev\\abc.csv");
            _driver.FindElement(By.Id("button-upload")).Click();

            try
            {
                _driver.FindElement(By.Id("createList-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant createList-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_see_the_page_createList_student_not_if_logged_in()
        {
           ;
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");

            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant createList-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_creatList_should_redirect_on_resultCreateList()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
            _driver.FindElement(By.Id("file")).SendKeys("C:\\dev\\abc.csv");
            _driver.FindElement(By.Id("button-upload")).Click();
            _driver.FindElement(By.Id("createList-button")).Click();

            try
            {
                _driver.FindElement(By.Id("resultCreateList-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant resultCreateList-page non trouvé sur la page.");
            }
        }
    }
}
