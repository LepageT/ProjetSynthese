using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerStageListTest : BaseTests
    {
        [TestMethod]
        public void student_home_page_should_display_stages()
        {
            AuthentificateTestUser();
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/StageList");
            var countText = _driver.FindElement(By.Id("stages-count")).Text;
            var stageCount =  int.Parse(countText.Split(' ')[0]);

            Assert.IsTrue(stageCount > 0);
        }

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            AuthentificateTestUser();
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/StageList");
            _driver.FindElement(By.Id("details-stages3")).Click();
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
