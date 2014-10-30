using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ConntactEnterpriseListStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_list_of_student_for_stage()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStage");
            _driver.FindElement(By.Id("list-stages1")).Click();
            try
            {
                _driver.FindElement(By.Id("list-student-stage"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant list-student-stage non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void contactEnterprise_can_click_on_a_student()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStage");
            _driver.FindElement(By.Id("list-stages1")).Click();
            try
            {
                _driver.FindElement(By.Id("list-student1"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant list-stage non trouvé sur la page.");
            }
        }
    }
}
