using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;

namespace Stagio.Web.UnitTests.CoordonnateurTests
{
    [TestClass]
    public class CoordonnateurControllerInviteTest : CoordonnateurControllerBaseClassTests
    {
        [TestMethod]
        public void coordonnateur_invite_get_should_returnview_default_view()
        {
            var result = coordonnateurController.Invite() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_invite__post_should_return_default_view_when_modelState_is_invalid()
        {
            var invitation = _fixture.Create<ViewModels.Coordonnateur.Invite>();

            coordonnateurController.ModelState.AddModelError("Error", "Error");
            var viewResult = coordonnateurController.Invite(invitation) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_invite__post_should_return_default_view_when_email_is_invalid()
        {
            var invitation = _fixture.Create<ViewModels.Coordonnateur.Invite>();

            var viewResult = coordonnateurController.Invite(invitation) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_invite_post_should_return_index_on_success()
        {
            var invitation = _fixture.Create<ViewModels.Coordonnateur.Invite>();
            invitation.Email = "admin@admin.com";

            mailler.SendEmail(invitation.Email, "Test", invitation.Message).ReturnsForAnyArgs(true);

            var routeResult = coordonnateurController.Invite(invitation) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Coordonnateur.Views.ViewNames.Index);

        }
    }
}
