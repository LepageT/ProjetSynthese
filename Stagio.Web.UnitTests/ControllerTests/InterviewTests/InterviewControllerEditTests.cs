using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerEditTests : InterviewControllerBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_EditViewModel_when_interviewId_is_valid()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            var user = _fixture.Create<Student>();
            var interview = _fixture.Create<Interview>();
            interview.StudentId = user.Id;
            studentRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stageRepository.GetAll().Returns(stages.AsQueryable());
            interview.StageId = stages[0].Id;
            interviewRepository.GetById(interview.Id).Returns(interview);
            var viewModelExpected = Mapper.Map<ViewModels.Interviews.Edit>(interview);
            viewModelExpected.StageTitleAndCompagny = stages[0].StageTitle + " - " + stages[0].CompanyName;
            viewModelExpected.hadStage = true;
            viewModelExpected.IdStageAcceptedByStudent = stages[0].Id;

            var viewResult = interviewController.Edit(interview.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Interviews.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_not_valid()
        {
            var user = _fixture.Create<Student>();
            studentRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            var interview = _fixture.Create<Interview>();
            interview.StudentId = INVALID_ID;
            interviewRepository.GetById(interview.Id).Returns(interview);
            
            var routeResult = interviewController.Edit(interview.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("List");
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_interviewId_is_not_valid()
        {

            var routeResult = interviewController.Edit(INVALID_ID) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("List");
        }

        [TestMethod]
        public void edit_post_should_update_interview_when_interviewId_is_valid()
        {
            var interview = _fixture.Create<Interview>();
            var student = _fixture.Create<Student>();
            var stage = _fixture.Create<Stage>();
            studentRepository.GetById(student.Id).Returns(student);
            stageRepository.GetById(stage.Id).Returns(stage);
            interview.StageId = stage.Id;
            interview.StudentId = student.Id;
            httpContextService.GetUserId().Returns(interview.Id);
            interviewRepository.GetById(interview.Id).Returns(interview);
            var interviewViewModel = Mapper.Map<ViewModels.Interviews.Edit>(interview);
            
            var actionResult = interviewController.Edit(interviewViewModel);

            interviewRepository.Received().Update(Arg.Is<Interview>(x => x.Id == interview.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_list_on_success()
        {
            var interview = _fixture.Create<Interview>();
            var student = _fixture.Create<Student>();
            var stage = _fixture.Create<Stage>();
            studentRepository.GetById(student.Id).Returns(student);
            stageRepository.GetById(stage.Id).Returns(stage);
            interview.StageId = stage.Id;
            interview.StudentId = student.Id;
            httpContextService.GetUserId().Returns(interview.Id);
            interviewRepository.GetById(interview.Id).Returns(interview);
            var interviewEditPageViewModel = Mapper.Map<ViewModels.Interviews.Edit>(interview);

            var routeResult = interviewController.Edit(interviewEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("List");
        }

        [TestMethod]
        public void interview_edit_post_should_return_httpnotfound_if_interview_doesnt_exist()
        {
            var interview = _fixture.Create<ViewModels.Interviews.Edit>();
            var student = _fixture.Create<Student>();
            var stage = _fixture.Create<Stage>();
            studentRepository.GetById(student.Id).Returns(student);
            stageRepository.GetById(stage.Id).Returns(stage);
            interview.StageId = stage.Id;
            interview.StudentId = student.Id;
            interviewRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = interviewController.Edit(interview);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void interview_edit__get_should_return_httpNotFound_when_modelState_is_not_valid()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            var user = _fixture.Create<Student>();
            var interview = _fixture.Create<Interview>();
            interview.StudentId = user.Id;
            studentRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stageRepository.GetAll().Returns(stages.AsQueryable());
            interview.StageId = stages[0].Id;
            interviewRepository.GetById(interview.Id).Returns(interview);
            interviewController.ModelState.AddModelError("Error", "Error");

            var result = interviewController.Edit(interview.Id);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
