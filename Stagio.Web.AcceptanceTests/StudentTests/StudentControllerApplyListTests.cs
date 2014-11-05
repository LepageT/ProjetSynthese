using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyListTests : BaseTests
    {
        [TestMethod]
        public void student_ApplyList_page_should_display_applied_stages_if_logged_in()
        {
            AuthentificateTestUser(StudentUsername, StudentPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/ApplyList");
            var countText = _driver.FindElement(By.Id("stages-count")).Text;
            var stageCount = int.Parse(countText.Split(' ')[0]);

            Assert.IsTrue(stageCount > 0);
        }

        [TestMethod]
        public void student_ApplyList_page_not_should_display_applied_stages_not_if_logged_in()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/ApplyList");
            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant resultCreateList-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            AuthentificateTestUser(StudentUsername, StudentPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/ApplyList");
            _driver.FindElement(By.Id("details-stages1")).Click();
            try
            {
                _driver.FindElement(By.Id("view-stage-info"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant view-stage-info non trouvé sur la page.");
            }
        }
    }
}
