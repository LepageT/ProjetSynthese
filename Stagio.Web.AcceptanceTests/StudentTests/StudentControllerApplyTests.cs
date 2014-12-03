using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : BaseTests
    {

        [TestMethod]
        public void student_upload_should_rest_on_to_upload_is_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("", "");

            ApplyStudentPage.IsDisplayed.Should().BeTrue();

        }
    }
}
