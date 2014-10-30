using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_create_profil_page()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate");

            try
            {
                _driver.FindElement(By.Id("create-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant create-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void contact_enterprise_create_should_create_account()
        {
            const string EMAIL = "blabla@blabla.com";
            const string FIRST_NAME = "Bill";
            const string LAST_NAME = "Gates";
            const string ENTERPRISE = "Microsost";
            const string TELEPHONE = "111-111-1111";
            const string PASSWORD = "asdfgh12";
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate");
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            _driver.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            _driver.FindElement(By.Id("EnterpriseName")).SendKeys(ENTERPRISE);
            _driver.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            _driver.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("PasswordConfirmation")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("create-button")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationCreateContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationCreateContact-page non trouvé sur la page.");
            }
            
           
        }


        [TestMethod]
        public void contact_enterprise_invitation_create_should_create_account()
        {
            const string FIRST_NAME = "Bill";
            const string LAST_NAME = "Gates";
            const string TELEPHONE = "111-111-1111";
            const string PASSWORD = "asdfgh12";
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate?Email=thomarelau@hotmail.com&EnterpriseName=test");
            _driver.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            _driver.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            _driver.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            _driver.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("PasswordConfirmation")).SendKeys(PASSWORD);
            _driver.FindElement(By.Id("create-button")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationCreateContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationCreateContact-page non trouvé sur la page.");
            }
           
        }
    }
}
