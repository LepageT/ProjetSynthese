using System;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = studentController.Create() as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_add_student_to_repository()
        {
            // Arrange   
            var student = _fixture.Create<Stagio.Domain.Entities.Student>();
            var studentViewModel = Mapper.Map<ViewModels.Student.Create>(student);

            // Action
            studentController.Create(studentViewModel);

            // Assert
            StudentRepositoryAddMethodShouldHaveReceived(student);

        }

        [TestMethod]
        public void create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var studentViewModel = _fixture.Create<ViewModels.Student.Create>();
            studentController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = studentController.Create(studentViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_redirect_to_home_index_on_success()
        {
            //Arrange
            var studentViewModel = _fixture.Create<ViewModels.Student.Create>();

            //Act
            var result = studentController.Create(studentViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];


            //Assert
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
