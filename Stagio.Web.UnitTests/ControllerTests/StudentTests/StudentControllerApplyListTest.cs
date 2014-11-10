using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Student;
using Apply = Stagio.Domain.Entities.Apply;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyListTest : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void ApplyList_should_return_list_with_stages()
        {
            var stages = _fixture.CreateMany<Stage>(3);
            var student = _fixture.Create<Student>();
            var apply = _fixture.CreateMany<Apply>(1);
            apply.FirstOrDefault().IdStudent = student.Id;
            apply.FirstOrDefault().IdStage = stages.FirstOrDefault().Id;
            apply.FirstOrDefault().Status = 1;
            stageRepository.GetAll().Returns(stages.AsQueryable());
            applyRepository.GetAll().Returns(apply.AsQueryable());
            httpContextService.GetUserId().Returns(student.Id);

            var result = studentController.ApplyList() as ViewResult;
            var model = result.Model as List<AppliedStages>;

            model.Count.Should().NotBe(0);
        }

        [TestMethod]
        public void ApplyList_should_return_empty_list_when_no_applied_stages()
        {
            var stages = _fixture.CreateMany<Stage>(3);
            var student = _fixture.Create<Student>();
            var apply = _fixture.CreateMany<Apply>(1);
            apply.FirstOrDefault().IdStudent = student.Id + 1;
            stageRepository.GetAll().Returns(stages.AsQueryable());
            applyRepository.GetAll().Returns(apply.AsQueryable());
            httpContextService.GetUserId().Returns(student.Id);

            var result = studentController.ApplyList() as ViewResult;
            var model = result.Model as List<AppliedStages>;

            model.Count.Should().Be(0);
        }

        [TestMethod]
        public void ApplyList_remove_apply_should_render_confirmation_view()
        {
            var applyStage = _fixture.Create<Apply>();
            applyRepository.GetById(applyStage.Id).Returns(applyStage);

            var result = studentController.ApplyRemoveConfirmation(applyStage.Id) as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void ApplyList_remove_apply_should_update_DB()
        {
            var applyStage = _fixture.Create<Apply>();
            applyRepository.GetById(applyStage.Id).Returns(applyStage);

            studentController.ApplyRemoveConfirmation(applyStage.Id);

            applyRepository.Received().Update(Arg.Is<Apply>(x => x.Id == applyStage.Id));

        }
    }
}
