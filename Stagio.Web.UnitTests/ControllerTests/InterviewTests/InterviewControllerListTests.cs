using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerListTests : InterviewControllerBaseClassTests
    {
        [TestMethod]
        public void interview_list_should_render_view()
        {
            var interviews = _fixture.CreateMany<Interview>(5).ToList();
            interviewRepository.GetAll().Returns(interviews.AsQueryable());

            var result = interviewController.List() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void interview_list_should_render_view_with_interviews()
        {

            var student = _fixture.Create<Student>();
            var stages = _fixture.CreateMany<Stage>(3).ToList();
            httpContextService.GetUserId().Returns(student.Id);

           
            var interviews = _fixture.CreateMany<Interview>(3).ToList();
            interviews[0].StudentId = student.Id;
            interviews[1].StudentId = student.Id;
            interviews[2].StudentId = student.Id;
            interviews[0].StageId = stages[0].Id;
            interviews[1].StageId = stages[1].Id;
            interviews[2].StageId = stages[2].Id;

            stageRepository.GetAll().Returns(stages.AsQueryable());
            interviewRepository.GetAll().Returns(interviews.AsQueryable());

            var result = interviewController.List() as ViewResult;
            var model = result.Model as List<ViewModels.Interviews.List>;

            model.Count.Should().NotBe(0);
        }
    }
}
