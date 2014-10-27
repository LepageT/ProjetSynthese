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

        [TestMethod]
        public void coordinator_can_refuse_a_stage()
        {
            _driver.FindElement(By.Id("list")).Click();
            _driver.FindElement(By.Id("details-stages1")).Click();
            _driver.FindElement(By.Id("refuse-stage")).Click();

            try
            {
                _driver.FindElement(By.Id("listNewStages-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant listNewStages-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_can_accept_a_stage()
        {
            _driver.FindElement(By.Id("list")).Click();
            _driver.FindElement(By.Id("details-stages1")).Click();
            _driver.FindElement(By.Id("accept-stage")).Click();

            try
            {
                _driver.FindElement(By.Id("listNewStages-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant listNewStages-page non trouvé sur la page.");
            }
        }
    }
}
