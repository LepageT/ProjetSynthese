﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void apply_action_should_render_default_view()
        {
            var result = studentController.CreateList() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void apply_should_return_http_not_found_when_IdStage_is_not_valid()
        {
            var result = studentController.Apply(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void apply_post_should_create_application_when_IdStage_is_valid()
        {
            var stage = _fixture.Create<Stage>();
            stage.Id = 3;
            stageRepository.GetById(stage.Id).Returns(stage);
            stageRepository.Add(stage);
            var apply = _fixture.Create<Apply>();
            apply.IdStage = 3;
            applyRepository.GetById(apply.Id).Returns(apply);
            var applyViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);

            studentController.Apply(applyViewModel);
            
            applyRepository.Received().Add(Arg.Is<Apply>(x => x.Cv == apply.Cv));
            applyRepository.Received().Add(Arg.Is<Apply>(x => x.Letter == apply.Letter));
            applyRepository.Received().Add(Arg.Is<Apply>(x => x.IdStage == apply.IdStage));
            applyRepository.Received().Add(Arg.Is<Apply>(x => x.IdStudent == apply.IdStudent));
            applyRepository.Received().Add(Arg.Is<Apply>(x => x.Id == apply.Id));
        }

        [TestMethod]
        public void apply_post_should_not_create_application_when_IdStage_is_not_valid()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.GetById(apply.Id).Returns(apply);
            var applyViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);

            studentController.Apply(applyViewModel);

            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Cv == apply.Cv));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Letter == apply.Letter));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.IdStage == apply.IdStage));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.IdStudent == apply.IdStudent));
            applyRepository.DidNotReceive().Add(Arg.Is<Apply>(x => x.Id == apply.Id));
        }


        [TestMethod]
        public void apply_post_should_redirect_to_confirmation_on_success()
        {
            var stage = _fixture.Create<Stage>();
            stage.Id = 3;
            stageRepository.GetById(stage.Id).Returns(stage);
            stageRepository.Add(stage);
            var apply = _fixture.Create<Apply>();
            apply.IdStage = 3; 
            applyRepository.GetById(apply.Id).Returns(apply);
            var applyViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);

            var routeResult = studentController.Apply(applyViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Student.Views.ViewNames.ApplyConfirmation);
        }

        [TestMethod]
        public void apply_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stage = _fixture.Create<Stage>();
            stage.Id = 3;
            stageRepository.GetById(stage.Id).Returns(stage);
            stageRepository.Add(stage);
            var apply = _fixture.Create<Apply>();
            apply.IdStage = 3;
            applyRepository.GetById(apply.Id).Returns(apply);
            var studentApplyPageViewModel = Mapper.Map<ViewModels.Student.Apply>(apply);
            applyRepository.GetById(apply.Id).Returns(apply);
            studentController.ModelState.AddModelError("Error", "Error");
            

            var result = studentController.Apply(studentApplyPageViewModel) as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void apply_post_should_return_http_not_found_when_IdStage_is_not_valid()
        {
            var apply = _fixture.Create<ViewModels.Student.Apply>();
            applyRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = studentController.Apply(apply);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}