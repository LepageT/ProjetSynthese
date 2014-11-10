using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerUploadCVLetterTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void upload_action_should_render_default_view()
        {
            var result = studentController.UploadCVLetter() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var listFiles = new List<HttpPostedFileBase>();

            var postedfile1 = Substitute.For<HttpPostedFileBase>();
            var postedfile2 = Substitute.For<HttpPostedFileBase>();
            listFiles.Add(postedfile1);
            listFiles.Add(postedfile2);

            studentController.ModelState.AddModelError("Error", "Error");

            var result = studentController.UploadCVLetter(listFiles) as ViewResult;

            result.ViewName.ShouldBeEquivalentTo("");
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_one_file_is_null()
        {
            var listFiles = new List<HttpPostedFileBase>();

            var postedfile1 = Substitute.For<HttpPostedFileBase>();
            var postedfile2 = Substitute.For<HttpPostedFileBase>();
            postedfile2 = null;
            listFiles.Add(postedfile1);
            listFiles.Add(postedfile2);

            var result = studentController.UploadCVLetter(listFiles) as ViewResult;

            result.ViewName.ShouldBeEquivalentTo("");
        }
    }
}
