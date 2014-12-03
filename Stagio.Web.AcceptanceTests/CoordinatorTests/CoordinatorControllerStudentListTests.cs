using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerStudentListTests : BaseTests
    {

        [TestMethod]
        public void coordinator_should_not_be_able_to_access_StudentList_page_if_not_logged_in()
        {
            StudentListCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_should_be_able_to_access_student_apply_detail()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            StudentListCoordinatorPage.GoTo();

            StudentListCoordinatorPage.AccessStudent1ApplyList().Should().BeTrue();
        }

    }
}
