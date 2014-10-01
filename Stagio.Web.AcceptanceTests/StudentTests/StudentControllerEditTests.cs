using System;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerEditTests : BaseTests
    {
        [TestMethod]
        public void edit_should_render_view_if_id_is_valid()
        {
            _driver.Navigate().GoToUrl("http://stagio.local/Student/Edit?id=1");
            //_driver.FindElement(By.Id("edit-student1")).Click();
            
            try
            {
                _driver.FindElement(By.Id("edit-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant edit-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void edit_should_update_item_if_id_is_valid()
        {
            const string NEW_TELEPHONE = "444-444-4444";
            _driver.Navigate().GoToUrl("http://stagio.local/Student/Edit?id=1");
            _driver.FindElement(By.Id("Telephone")).Clear();
            _driver.FindElement(By.Id("Telephone")).SendKeys(NEW_TELEPHONE);
            _driver.FindElement(By.Id("edit-button")).Click();
            _driver.Navigate().GoToUrl("http://stagio.local/Student/Edit?id=1");
            var telephoneDisplayed = _driver.FindElement(By.Id("Telephone")).GetAttribute("value");
            _driver.FindElement(By.Id("edit-button")).Click();
            telephoneDisplayed.ShouldBeEquivalentTo(NEW_TELEPHONE);
        }

        [TestMethod]
        public void edit_should_redirect_to_index_if_updated()
        {
            this.edit_should_update_item_if_id_is_valid();
            try
            {
                _driver.FindElement(By.Id("home-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant home-page non trouvé sur la page.");
            }

        }
    }
}
