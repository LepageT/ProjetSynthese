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
        public void student_should_be_able_to_edit_his_profil_if_id_is_valid_and_student_is_connected()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            EditStudentPage.GoTo();
            
            Assert.IsTrue(EditStudentPage.IsDisplayed);
        }

        [TestMethod]
        public void student_not_should_be_able_to_edit_his_profil_if_not_logged_in()
        {
            EditStudentPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
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

            Assert.IsTrue(EditStudentPage.EditVerification(NEW_TELEPHONE));
        }

        [TestMethod]
        public void student_edit_should_redirect_to_index_if_updated()
        {
            const string NEW_TELEPHONE = "444-444-4444";
            const string OLD_PASSWORD = "qwerty12";
            const string NEW_PASSWORD = "asdfgh12";

            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            EditStudentPage.GoTo();
            EditStudentPage.EditAStudent(NEW_TELEPHONE, OLD_PASSWORD, NEW_PASSWORD);

            Assert.IsTrue(IndexStudentPage.IsDisplayed);
            

        }

        //TODO: Validation du mot de passe à faire lorsque le login sera disponible.
    }
}
