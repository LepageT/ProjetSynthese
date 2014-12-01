using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerDownloadTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void download_file_not_valid_should_return_detailapply_view()
        {
            var file = "ApplyCV";
            var file2 = "ApplyLetter";
            var id = 0;

            var routeResult = coordinatorController.Download(file, id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeResult2 = coordinatorController.Download(file2, id) as RedirectToRouteResult;
            var routeAction2 = routeResult2.RouteValues["Action"];

            routeAction.Should().Be("DetailsApplyStudent");
            routeAction2.Should().Be("DetailsApplyStudent");
        }
    }
}
