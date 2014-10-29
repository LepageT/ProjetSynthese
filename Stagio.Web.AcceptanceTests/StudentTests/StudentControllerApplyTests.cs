using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_apply_to_a_stage()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Apply/3");

            try
            {
                _driver.FindElement(By.Id("apply-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant apply-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void student_should_see_confirmation_page_after_apply()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Apply/3");
            _driver.FindElement(By.Id("Cv")).SendKeys("Test");
            _driver.FindElement(By.Id("Letter")).SendKeys("Test");
            _driver.FindElement(By.Id("apply-button")).Click();

            try
            {
                _driver.FindElement(By.Id("confirmationApplyStudent-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationApplyStudent-page non trouvé sur la page.");
            }
        }
    }
}
