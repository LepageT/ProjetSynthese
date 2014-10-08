using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateListTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void createlist_action_should_render_default_view()
        {
            var studentViewModel = _fixture.CreateMany<Student>().ToList();
            var result = studentController.CreateListGet(studentViewModel) as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void createlist_post_should_add_student_to_repository()
        {
            var student = _fixture.CreateMany<Student>(2).ToList();

            studentRepository.GetAll().Returns(student.AsQueryable());
            studentController.CreateListPost(student.ToList());

            foreach (var studentCreated in student)
            {
                StudentRepositoryAddMethodShouldHaveReceived(studentCreated);
            }
        }

        [TestMethod]
        public void createlist_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var studentViewModel = _fixture.CreateMany<Student>().ToList();
            studentController.ModelState.AddModelError("Error", "Error");

            var result = studentController.CreateListPost(studentViewModel) as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void createlist_post_should_redirect_to_home_index_on_success()
        {
            var studentViewModel = _fixture.CreateMany<Student>().ToList();

            var result = studentController.CreateListPost(studentViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }

        private void StudentRepositoryAddMethodShouldHaveReceived(Student student)
        {
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Id == student.Id));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.FirstName == student.FirstName));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.LastName == student.LastName));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Matricule == student.Matricule));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Password == student.Password));
        }
    }
}
