using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseDownloadTest : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void download_file_not_valid_should_return_detailapply_view()

        {
            var file = "ApplyCV";
            var file2 = "ApplyLetter";
            var id = 0;

            var routeResult = enterpriseController.Download(file, id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeResult2 = enterpriseController.Download(file2, id) as RedirectToRouteResult;
            var routeAction2 = routeResult.RouteValues["Action"];
            routeAction.Should().Be("DetailsStudentApply");
            routeAction2.Should().Be("DetailsStudentApply");
        }
    }
}
