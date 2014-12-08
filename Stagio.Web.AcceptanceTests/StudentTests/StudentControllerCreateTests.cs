using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void student_create_should_redirect_to_index_if_created()
        {
            var student = _fixture.Create<Student>();
            CreateStudentPage.GoTo();

            CreateStudentPage.CreateStudent(student);

            CreateStudentPage.ConfirmationPageIsDisplayed.Should().BeTrue();
            
        }
    }
}
