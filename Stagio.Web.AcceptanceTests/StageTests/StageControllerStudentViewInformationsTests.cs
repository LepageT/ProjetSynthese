using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerStudentViewInformationsTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_description_of_a_stage()
        {
            ViewInfoStageStudentPage.GoToByUrl();

            Assert.IsTrue(ViewInfoStageStudentPage.IsDisplayed);

        }
    }
}
