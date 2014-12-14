using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerChangeSmtpOptionsTests : CoordinatorControllerBaseClassTests
    {
        private const string TEST_SERVER = "smtp.live.com";
        private const int TEST_PORT = 587;
        
        [TestMethod]
        public void ChangeSmtpOptions_should_return_empty_view_with_empty_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());
            miscRepository.GetAll().Returns(miscs);

            var result = coordinatorController.ChangeSmtpOptions() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void ChangeSmtpOptions_should_return__view_with_view_model_with_nonempty_miscs()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.SmtpOption>(miscs.First());
            viewModelExpected.SmtpServer = miscs.First().SmtpServer;
            viewModelExpected.SmtpPort= miscs.First().SmtpPort;

            var result = coordinatorController.ChangeSmtpOptions() as ViewResult;

            var viewModelObtained = result.ViewData.Model as ViewModels.Coordinator.SmtpOption;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void ChangeSmtpOptions_post_should_return_default_view_with_invalid_model()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.SmtpOption>(misc);
            coordinatorController.ModelState.AddModelError("Error", "Error");
            viewModelExpected.SmtpServer = miscs.First().SmtpServer;
            viewModelExpected.SmtpPort = miscs.First().SmtpPort;

            var result = coordinatorController.ChangeSmtpOptions("Sauvegarder les nouvelles options",viewModelExpected) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void ChangeSmtpOptions_post_should_add_with_empty_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = new ViewModels.Coordinator.SmtpOption();
            viewModelExpected.SmtpServer = TEST_SERVER;
            viewModelExpected.SmtpPort = TEST_PORT;

            var result = coordinatorController.ChangeSmtpOptions("Sauvegarder les nouvelles options", viewModelExpected);

            miscRepository.Received().Add(Arg.Any<Misc>());
        }

        [TestMethod]
        public void ChangeSmtpOptions_post_should_update_with_nonmempty_misc()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.SmtpOption>(misc);
            viewModelExpected.SmtpServer = miscs.First().SmtpServer;
            viewModelExpected.SmtpPort = miscs.First().SmtpPort;

            var result = coordinatorController.ChangeSmtpOptions("Sauvegarder les nouvelles options", viewModelExpected) as ViewResult;

            miscRepository.Received().Update(Arg.Any<Misc>());
        }

        [TestMethod]
        public void ChangeSmtpOptions_post_should_return_to_coordinator_index_after_valid_action()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.SmtpOption>(misc);
            viewModelExpected.SmtpServer = miscs.First().SmtpServer;
            viewModelExpected.SmtpPort = miscs.First().SmtpPort;

            var result = coordinatorController.ChangeSmtpOptions("Sauvegarder les nouvelles options", viewModelExpected) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void ChangeSmtpOptions_post_should_return_to_coordinator_index_after_valid_action_with_default_action()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.SmtpOption>(misc);
            viewModelExpected.SmtpServer = miscs.First().SmtpServer;
            viewModelExpected.SmtpPort = miscs.First().SmtpPort;

            var result = coordinatorController.ChangeSmtpOptions("Retour vers les options par défaults", viewModelExpected) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }
    }
}
