using System;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_create_his_profil()
        {
            

            /*_driver.Navigate().GoToUrl("http://thomarelau.local/Student/Create");

            try
            {
                _driver.FindElement(By.Id("create-student"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant edit-page non trouvé sur la page.");
            }*/
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void student_create_should_redirect_to_index_if_created()
        {
            /*const string MATRICULE = "1031739";
            const string FIRSTNAME = "Thomas";
            const string LASTNAME = "Lepage";
            const string PHONE = "1234567890";
            const string PASSWORD = "123456ABC";
            const string EMAIL = "bob@hotmail.com";
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Create");
            _driver.FindElement(By.Id("Matricule")).SendKeys(MATRICULE);
            _driver.FindElement(By.Id("FirstName")).SendKeys(FIRSTNAME);
            _driver.FindElement(By.Id("LastName")).SendKeys(LASTNAME);
            _driver.FindElement(By.Id("Telephone")).SendKeys(PHONE);
            _driver.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("PasswordConfirmation")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("ConfirmEmail")).SendKeys(EMAIL);

            _driver.FindElement(By.Id("create-button")).Click();
            try
            {
                _driver.FindElement(By.Id("home-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant home-page non trouvé sur la page.");
            }*/
            Assert.IsTrue(false);
        }
    }
}
