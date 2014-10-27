using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerStudentViewInformationsTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_description_of_a_stage()
        {

            _driver.Navigate().GoToUrl("http://thomarelau.local/Stage/ViewStageInfo/1");

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
