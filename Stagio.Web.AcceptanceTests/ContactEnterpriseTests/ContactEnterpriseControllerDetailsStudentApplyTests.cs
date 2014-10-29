using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_page_of_detail_apply()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStage");
            _driver.FindElement(By.Id("list-stages1")).Click();
            _driver.FindElement(By.Id("list-student1")).Click();
            try
            {
                _driver.FindElement(By.Id("details-apply-student"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant details-apply-student non trouvé sur la page.");
            }
        
        }

    }
}
