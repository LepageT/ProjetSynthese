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
            var interview = _fixture.Create<Interview>();
            stageRepository.GetAll().Returns(stages.AsQueryable());
            interview.StageId = stages[0].Id;
            interviewRepository.GetById(interview.Id).Returns(interview);
            var viewModelExpected = Mapper.Map<ViewModels.Interviews.Edit>(interview);
            viewModelExpected.StageTitleAndCompagny = stages[0].StageTitle + " - " + stages[0].CompanyName;

            var viewResult = interviewController.Edit(interview.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Interviews.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_not_valid()
        {
            var result = interviewController.Edit(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_interview_when_interviewId_is_valid()
        {
            var interview = _fixture.Create<Interview>();
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
            interviewRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = interviewController.Edit(interview);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
