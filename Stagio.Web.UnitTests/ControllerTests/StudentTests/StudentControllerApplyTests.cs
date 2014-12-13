using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.Web.ViewModels.Student;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using Apply = Stagio.Domain.Entities.Apply;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void apply_should_return_http_not_found_when_IdStage_is_not_valid()
        {
            var result = studentController.ApplyStage(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }


        [TestMethod]
        public void apply_post_should_not_create_application_when_IdStage_is_not_valid()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.GetById(apply.Id).Returns(apply);
            var applyViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);
            var listFiles = new List<HttpPostedFileBase>();

            var postedfile1 = Substitute.For<HttpPostedFileBase>();
            var postedfile2 = Substitute.For<HttpPostedFileBase>();
            listFiles.Add(postedfile1);
            listFiles.Add(postedfile2);
            studentController.ApplyStage(listFiles, applyViewModel);

            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Cv == apply.Cv));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Letter == apply.Letter));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.IdStage == apply.IdStage));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.IdStudent == apply.IdStudent));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Id == apply.Id));
        }


        [TestMethod]
        public void apply_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stage = _fixture.Create<Stage>();
            stage.Id = 3;
            stageRepository.GetById(stage.Id).Returns(stage);
            stageRepository.Add(stage);
            var apply = _fixture.CreateMany<Apply>(1).ToList();
            apply[0].IdStage = 3;
            applyRepository.GetById(apply[0].Id).Returns(apply[0]);
            var studentApplyPageViewModel = Mapper.Map<ViewModels.Student.Apply>(apply[0]);
            applyRepository.GetAll().Returns(apply.AsQueryable());
            studentController.ModelState.AddModelError("Error", "Error");
            var listFiles = new List<HttpPostedFileBase>();
            var postedfile1 = Substitute.For<HttpPostedFileBase>();
            var postedfile2 = Substitute.For<HttpPostedFileBase>();
            var user = _fixture.Create<Domain.Entities.Student>();
            httpContextService.GetUserId().Returns(user.Id);
            listFiles.Add(postedfile1);
            listFiles.Add(postedfile2);

            var result = studentController.ApplyStage(listFiles, studentApplyPageViewModel) as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void apply_post_should_return_http_not_found_when_IdStage_is_not_valid()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.GetById(Arg.Any<int>()).Returns(a => null);
            var listFiles = new List<HttpPostedFileBase>();
            var studentApplyPageViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);
            var postedfile1 = Substitute.For<HttpPostedFileBase>();
            var postedfile2 = Substitute.For<HttpPostedFileBase>();
            listFiles.Add(postedfile1);
            listFiles.Add(postedfile2);
            var result = studentController.ApplyStage(listFiles, studentApplyPageViewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void ApplyRemove_should_redirect_to_applylist_with_wrong_id()
        {
            var apply = _fixture.Create<Apply>();
            var user = _fixture.Create<Student>();
            apply.IdStudent = INVALID_ID;
            applyRepository.GetById(apply.Id).Returns(apply);
            studentRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);

            var routeResult = studentController.ApplyRemoveConfirmation(apply.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("ApplyList");
        }

    }
}
