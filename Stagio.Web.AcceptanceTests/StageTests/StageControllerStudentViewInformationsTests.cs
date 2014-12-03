using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerStudentViewInformationsTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_description_of_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ViewInfoStageStudentPage.GoToByUrl();

            ViewInfoStageStudentPage.IsDisplayed.Should().BeTrue();

        }
    }
}
