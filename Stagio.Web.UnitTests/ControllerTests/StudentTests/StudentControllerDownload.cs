using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.ViewModels.Apply;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerDownload : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void student_download_should_return_view_when_file_not_valid()
        {
            var listFiles = getListFiles();
            var routeResult = studentController.Download(listFiles[0].FileName) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("Index");
        }

        public void student_download_should_return_httpNotFound_if_apply_dont_have_file()
        {
            var result = studentController.Download();

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        private List<HttpPostedFileBase> getListFiles()
        {
            var listFiles = new List<HttpPostedFileBase>();
            var file1 = Substitute.For<HttpPostedFileBase>();
            var file2 = Substitute.For<HttpPostedFileBase>();

            listFiles.Add(file1);
            listFiles.Add(file2);

            return listFiles;
        }
    }
}
