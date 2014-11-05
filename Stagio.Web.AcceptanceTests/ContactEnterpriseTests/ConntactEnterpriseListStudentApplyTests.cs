using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ConntactEnterpriseListStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_list_of_student_for_stage()
        {
            StudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(StudentApplyContactEnterprisePage.IsDisplayed);
            
        }

        [TestMethod]
        public void contactEnterprise_can_click_on_a_student()
        {
            StudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(StudentApplyContactEnterprisePage.ButtonIsDisplayed());
            /*_driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStage");
            _driver.FindElement(By.Id("list-stages1")).Click();
            try
            {
                _driver.FindElement(By.Id("list-student1"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant list-stage non trouvé sur la page.");
            }*/
            //Assert.IsTrue(false);
        }
    }
}
