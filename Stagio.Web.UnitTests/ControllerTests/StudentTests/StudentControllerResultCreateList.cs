using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerResultCreateList : AllControllersBaseClassTests
    {

        [TestMethod]
        public void resultCreatelist_action_should_render_default_view()
        {
            var result = studentController.ResultCreateList() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void resultCreatelist_post_should_render_home_index_view()
        {
            var routeResult = studentController.PostResultCreateList() as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

    }
}
