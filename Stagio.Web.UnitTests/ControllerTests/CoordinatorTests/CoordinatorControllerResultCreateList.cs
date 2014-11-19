
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;


namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerResultCreateList : CoordinatorControllerBaseClassTests
    {

        [TestMethod]
        public void resultCreatelist_action_should_render_default_view()
        {
            var result = coordinatorController.ResultCreateList() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void resultCreatelist_post_should_render_home_index_view()
        {
            var routeResult = coordinatorController.PostResultCreateList() as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

    }
}
