using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using System;

namespace Stagio.Web.UnitTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateListTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void createlist_action_should_render_default_view()
        {
            var studentViewModel = _fixture.CreateMany<Student>().ToList();
            var result = studentController.CreateList() as ViewResult;

             Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void createlist_post_should_add_student_to_repository()
        {
            var student = _fixture.CreateMany<Student>(3).ToList();

            

            studentController.TempData["listStudent"] = student;
            studentController.CreateListPost();
            studentRepository.GetAll().Returns(student.AsQueryable());
            foreach (var studentCreated in student)
            {
                StudentRepositoryAddMethodShouldHaveReceived(studentCreated);
            }
        }

        [TestMethod]
        public void createlist_post_should_return_default_view_when_modelState_is_not_valid()
        {

            studentController.ModelState.AddModelError("Error", "Error");
            var studentViewModel = _fixture.CreateMany<Student>().ToList();
            studentController.TempData["listStudent"] = studentViewModel;
            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("");
        }

        [TestMethod]
        public void createlist_post_should_redirect_to_student_resultList_on_success()
        {
            var studentViewModel = _fixture.CreateMany<Student>(3).ToList();
            studentController.TempData["listStudent"] = studentViewModel;
            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("ResultCreateList");

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
