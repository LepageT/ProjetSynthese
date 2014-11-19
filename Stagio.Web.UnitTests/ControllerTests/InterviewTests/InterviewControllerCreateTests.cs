using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreateTests : InterviewControllerBaseClassTests
    {
        [TestMethod]
        public void interview_create_get_should_return_create_view()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);

            var appliedList = _fixture.CreateMany<Apply>(3);
            applyRepository.GetAll().Returns(appliedList.AsQueryable());
            var result = interviewController.Create() as ViewResult;

            result.ViewName.Should().Be(""); 
        }

        [TestMethod]
        public void interview_create_post_should_return_default_view_when_modelState_is_not_valid()
        {

            var interview = _fixture.Create<ViewModels.Interviews.Create>();
            interviewController.ModelState.AddModelError("Error", "Error");

            var result = interviewController.Create(interview) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void interview_create_post_should_return_confirmation_on_success()
        {
            var interview = _fixture.Create<ViewModels.Interviews.Create>();
            interview.Date = DateTime.Now.ToLongDateString();
            interview.StageId = 1;

            var result = interviewController.Create(interview) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.Interview.Views.ViewNames.InterviewConfirmation);
        }
    }
}
