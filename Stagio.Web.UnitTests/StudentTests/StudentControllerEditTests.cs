using System;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using FluentAssertions;
using Stagio.Utilities.Encryption;
using Stagio.Web.UnitTests.StudentTests;

namespace Stagio.Web.UnitTests
{
    [TestClass]
    public class StudentControllerEditTests : StudentBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_studentViewModel_when_studentId_is_valid()
        {
            //Arrange 
            var student = _fixture.Create<Stagio.Domain.Entities.Student>();
            studentRepository.GetById(student.Id).Returns(student);
            var viewModelExpected = Mapper.Map<ViewModels.Student.Edit>(student);
            

            //Action
            var viewResult = studentController.Edit(student.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Student.Edit;

            //Assert 
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_not_valid()
        {
            //Action
            var result = studentController.Edit(999999999);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_student_when_studentId_is_valid()
        {
            //Arrange
            var student = _fixture.Create<Student>();
            studentRepository.GetById(student.Id).Returns(student);
            var studentViewModel = Mapper.Map<ViewModels.Student.Edit>(student);
            studentViewModel.OldPassword = student.Password;
            student.Password = PasswordHash.CreateHash(student.Password);

            //Action
            var actionResult = studentController.Edit(studentViewModel);

            // Assert
            studentRepository.Received().Update(Arg.Is<Student>(x => x.Id == student.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var student = _fixture.Create<Student>();

            studentRepository.GetById(student.Id).Returns(student);
            var studentEditPageViewModel = Mapper.Map<Student, ViewModels.Student.Edit>(student);
            studentEditPageViewModel.OldPassword = student.Password;
            student.Password = PasswordHash.CreateHash(student.Password);
            //Act
            var routeResult = studentController.Edit(studentEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var student = _fixture.Create<Student>();
            var studentEditPageViewModel = _fixture.Build<ViewModels.Student.Edit>()
                                                      .With(x => x.Id, student.Id)
                                                      .Create();
            studentRepository.GetById(student.Id).Returns(student);
            studentController.ModelState.AddModelError("Error", "Error");
            student.Password = PasswordHash.CreateHash(student.Password);
            //Act
            var result = studentController.Edit(studentEditPageViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void edit_post_should_return_http_not_found_when_studentID_is_not_valid()
        {
            //Arrange 
            var student = _fixture.Create<ViewModels.Student.Edit>();
            studentRepository.GetById(Arg.Any<int>()).Returns(a => null);

            //Act
            var result = studentController.Edit(student);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
