﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorCreateTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_create_an_account_with_valid_invitation()
        {
            /*_driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Create?token=123456");

            try
            {
                _driver.FindElement(By.Id("create-coordinator-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant create-coordinator-page non trouvé sur la page");
            }*/
        }

        [TestMethod]
        public void coordinator_create_should_create_account_if_invitation_is_valid()
        {
            /*const string FIRST_NAME = "Bobino";
            const string LAST_NAME = "Tremblay";
            const string EMAIL = "testemail@admin.com";
            const string PASSWORD = "Bobino1234";
            const string CONFIRMED_PASSWORD = "Bobino1234";

            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Create?token=123456");
            _driver.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            _driver.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("ConfirmEmail")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("ConfirmedPassword")).SendKeys(CONFIRMED_PASSWORD);
            _driver.FindElement(By.Id("btn-create")).Click();
            try
            {
                _driver.FindElement(By.Id("coordinator-home"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant coordinator-home non trouvé sur la page");
            }*/
        }

       
    }
}
