using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerListNewStages : BaseTests
    {

        [TestMethod]
        public void coordinator_can_see_listNewStages_page_if_logged_in()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.FindElement(By.Id("index-coordonnateur")).Click();
            _driver.FindElement(By.Id("list")).Click();
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
        public void coordinator_can_not_see_listNewStages_page_if_not_logged_in()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Stage/ListNewStages");
            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant listNewStages-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_can_see_listNewStages_with_stages()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.FindElement(By.Id("index-coordonnateur")).Click();
            _driver.FindElement(By.Id("list")).Click();
            var countText = _driver.FindElement(By.Id("stages-count")).Text;
            var stagesCount = int.Parse(countText.Split(' ')[0]);
            

            stagesCount.Should().NotBe(0);
        }
    }
}
