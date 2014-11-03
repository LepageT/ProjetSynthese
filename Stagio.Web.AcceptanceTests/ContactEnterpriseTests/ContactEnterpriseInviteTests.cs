﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Domain.Entities;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseInviteTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_invite_another_contact_page_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            InviteContactEnterprisePage.GoTo();

            Assert.IsTrue(InviteContactEnterprisePage.IsDisplayed);
        }

        [TestMethod]
        public void contact_enterprise_should_not_be_able_to_access_invite_another_contact_page_if_not_logged_in()
        {
            InviteContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
            
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_invite_another_contact_enterprise()
        {
            /*LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            InviteContactEnterprisePage.GoTo();
            InviteContactEnterprisePage.InviteContactEnterprise();*/

            /*AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            const string MESSAGE_INVITATION = "test";
            const string EMAIL = "test@test.com";
            const string FIRST_NAME = "Bob";
            const string LAST_NAME = "Bobby";
            const string TELEPHONE = "111-111-1111";
            const string ENTERPRISE_NAME = "test";
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/InviteContactEnterprise");
            _driver.FindElement(By.Id("Message")).SendKeys(MESSAGE_INVITATION);
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            _driver.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            _driver.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            _driver.FindElement(By.Id("EnterpriseName")).SendKeys(ENTERPRISE_NAME);
            _driver.FindElement(By.Id("send-button")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationInvitationContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationInvitationContact-page non trouvé sur la page.");
            }*/

        }

        [TestMethod]
        public void contact_enterprise_should_not_be_able_to_invite_another_contact_enterprise_if_there_is_no_email()
        {
            /*AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/InviteContactEnterprise");
            _driver.FindElement(By.Id("send-button")).Click();
            try
            {
                _driver.FindElement(By.Id("inviteContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant inviteContact-page non trouvé sur la page.");
            }*/

        }
    }
}
