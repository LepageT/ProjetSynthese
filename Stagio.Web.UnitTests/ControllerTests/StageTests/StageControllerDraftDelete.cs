using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.ContactEnterprise;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerDraftDelete : StageControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_remove_draft_should_render_view()
        {
            var draft = _fixture.Build<Stage>().With(x => x.Status, StageStatus.Draft).Create();
            stageRepository.GetById(draft.Id).Returns(draft);

            var result = stageController.DraftDelete(draft.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.DraftList);


        }

        [TestMethod]
        public void contact_enterprise_remove_draft_should_update_DB()
        {
            var draft = _fixture.Build<Stage>().With(x => x.Status, StageStatus.Draft).Create();
            stageRepository.GetById(draft.Id).Returns(draft);

            stageController.DraftDelete(draft.Id);

            stageRepository.Received().Delete(Arg.Is<Stage>(x => x.Id == draft.Id));
        }

        [TestMethod]
        public void contact_enterprise_remove_draft_should_return_httpnotfound_if_id_invalid()
        {
            var result = stageController.DraftDelete(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
