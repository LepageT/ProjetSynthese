using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerEditTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_studentViewModel_when_studentId_is_valid()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            studentRepository.GetById(student.Id).Returns(student);
            var viewModelExpected = Mapper.Map<ViewModels.Student.Edit>(student);
            
            var viewResult = studentController.Edit(student.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Student.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_not_valid()
        {
            httpContextService.GetUserId().Returns(99999999);

            var result = studentController.Edit(999999999);
            
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_student_when_studentId_is_valid()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            studentRepository.GetById(student.Id).Returns(student);
            var studentViewModel = Mapper.Map<ViewModels.Student.Edit>(student);
            studentViewModel.OldPassword = student.Password;
            student.Password = PasswordHash.CreateHash(student.Password);

            var actionResult = studentController.Edit(studentViewModel);

            studentRepository.Received().Update(Arg.Is<Student>(x => x.Id == student.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            studentRepository.GetById(student.Id).Returns(student);
            var studentEditPageViewModel = Mapper.Map<Student, ViewModels.Student.Edit>(student);
            studentEditPageViewModel.OldPassword = student.Password;
            student.Password = PasswordHash.CreateHash(student.Password);
            studentEditPageViewModel.Password = "Qwerty67";
            studentEditPageViewModel.PasswordConfirmation = studentEditPageViewModel.Password;

            var routeResult = studentController.Edit(studentEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            var studentEditPageViewModel = _fixture.Build<ViewModels.Student.Edit>()
                                                      .With(x => x.Id, student.Id)
                                                      .Create();
            studentRepository.GetById(student.Id).Returns(student);
            studentController.ModelState.AddModelError("Error", "Error");
            student.Password = PasswordHash.CreateHash(student.Password);

            var result = studentController.Edit(studentEditPageViewModel) as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void edit_post_should_return_http_not_found_when_studentID_is_not_valid()
        {
            var student = _fixture.Create<ViewModels.Student.Edit>();
            httpContextService.GetUserId().Returns(student.Id);
            studentRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = studentController.Edit(student);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
