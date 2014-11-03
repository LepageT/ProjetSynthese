using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_accepting_a_student_apply()
        {
            /*_driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/DetailsStudentApply/1");
            _driver.FindElement(By.Id("accept-stage")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationAcceptApply-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationAcceptApply-page non trouv� sur la page.");
            }*/
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_refusing_a_student_apply()
        {
            /*_driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/DetailsStudentApply/1");
            _driver.FindElement(By.Id("refuse-stage")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationRefuseApply-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationRefuseApply-page non trouv� sur la page.");
            }*/
        }
 [TestMethod]
        public void contactEnterprise_can_see_a_page_of_detail_apply()
        {
            /*_driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStage");
            _driver.FindElement(By.Id("list-stages1")).Click();
            _driver.FindElement(By.Id("list-student1")).Click();
            try
            {
                _driver.FindElement(By.Id("details-apply-student"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant details-apply-student non trouv� sur la page.");
            }*/
        
        }

    }
}

