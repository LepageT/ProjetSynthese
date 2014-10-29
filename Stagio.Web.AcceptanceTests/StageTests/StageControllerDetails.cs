using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : BaseTests
    {
        [TestMethod]
        public void coordinator_can_see_details_stage_page()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.FindElement(By.Id("list")).Click();
            _driver.FindElement(By.Id("details-stages1")).Click();
            try
            {
                _driver.FindElement(By.Id("details-stage-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant details-stage-page non trouvé sur la page.");
            }
        }
    }
}
