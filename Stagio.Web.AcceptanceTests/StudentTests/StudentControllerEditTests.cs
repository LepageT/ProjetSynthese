using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerEditTests : BaseTests
    {

        [TestMethod]
        public void student_not_should_be_able_to_edit_his_profil_if_not_logged_in()
        {
            EditStudentPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
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

            IndexStudentPage.IsDisplayed.Should().BeTrue();
            

        }

        //TODO: Validation du mot de passe à faire lorsque le login sera disponible.
    }
}
