using System;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerEditTests : BaseTests
    {
        [TestMethod]
        public void student_should_not_be_able_to_edit_his_profil_if_not_logged_in()
        {
            EditStudentPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void student_edit_should_update_his_profil_if_id_is_valid()
        {
            const string NEW_TELEPHONE = "444-444-4444";
            const string OLD_PASSWORD = "qwerty12";
            const string NEW_PASSWORD = "asdfgh12";

            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            EditStudentPage.GoTo();
            EditStudentPage.EditAStudent(NEW_TELEPHONE, OLD_PASSWORD, NEW_PASSWORD);

            IndexStudentPage.IsDisplayed.Should().BeTrue();
            EditStudentPage.EditVerification(NEW_TELEPHONE).Should().BeTrue();

        }


    }
}
