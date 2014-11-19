using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using FluentAssertions;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;


namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void student_create_get_should_return_create_view()
        {
            var result = studentController.Create() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void student_create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var students = _fixture.CreateMany<Student>(3);
            var student = students.First();
            student.Active = false;
            studentRepository.GetAll().Returns(students.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Student.Create>();
            viewModel.Matricule = student.Matricule;
            viewModel.FirstName = student.FirstName;
            viewModel.LastName = student.LastName;
            viewModel.PasswordConfirmation = viewModel.Password;
            studentController.ModelState.AddModelError("Error", "Error");

            var result = studentController.Create(viewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void student_create_post_should_return_default_view_when_matricule_is_not_in_the_list()
        {
            var students = _fixture.CreateMany<Student>(3);
            var student = students.First();
            student.Active = false;
            studentRepository.GetAll().Returns(students.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Student.Create>();

            var result = studentController.Create(viewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void student_create_post_should_return_index_on_success()
        {
            var students = _fixture.CreateMany<Student>(3);
            var student = students.First();
            student.Active= false;
            studentRepository.GetAll().Returns(students.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Student.Create>();
            viewModel.Matricule = student.Matricule;
            viewModel.FirstName = student.FirstName;
            viewModel.LastName = student.LastName;
            viewModel.PasswordConfirmation = viewModel.Password;

            var routeResult = studentController.Create(viewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Student.Views.ViewNames.CreateConfirmation);
        }

        [TestMethod]
        public void student_create_post_should_return_to_default_view_if_student_account_already_activated()
        {
            var students = _fixture.CreateMany<Student>(3);
            var student = students.First();
            student.Active = true;
            studentRepository.GetAll().Returns(students.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Student.Create>();
            viewModel.Matricule = student.Matricule;
            viewModel.FirstName = student.FirstName;
            viewModel.LastName = student.LastName;
            viewModel.PasswordConfirmation = viewModel.Password;

            var result = studentController.Create(viewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
