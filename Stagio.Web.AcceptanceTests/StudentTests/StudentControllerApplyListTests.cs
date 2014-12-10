using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyListTests : BaseTests
    {

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();

            ApplyListStudentPage.AccessStageDescription().Should().BeTrue();
        }

        [TestMethod]
        public void student_should_see_RemoveApplyConfirmationPage_when_removing_an_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToRemove();

            ApplyListStudentPage.ConfirmationRemoveIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void student_should_see_ReApplyApplyConfirmationPage_when_reapplying()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToRemove();
            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToReApply();

            ApplyListStudentPage.ConfirmationReApplyIsDisplayed.Should().BeTrue();
        }
    }
}
