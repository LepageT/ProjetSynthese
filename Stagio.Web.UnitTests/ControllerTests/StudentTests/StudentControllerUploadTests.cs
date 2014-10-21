using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using NSubstitute;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerUploadTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void upload_action_should_render_default_view()
        {
            
            var result = studentController.Upload() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var postedfile = Substitute.For<HttpPostedFileBase>();

            studentController.ModelState.AddModelError("Error", "Error");
            
            var result = studentController.UploadPost(postedfile) as ViewResult;
            
            result.ViewName.ShouldBeEquivalentTo("");
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_file_is_null()
        {
            var postedfile = Substitute.For<HttpPostedFileBase>();

            postedfile = null;

            var result = studentController.UploadPost(postedfile) as ViewResult;

            result.ViewName.ShouldBeEquivalentTo("");
        }

        //Il faudrait mettre le nom avec une extension .csv
        //Il n'est pas possible de mettre un nom spécifique en c# à un HttpPostedFileBase

        //[TestMethod]
        //public void upload_post_should_return_view_createList_if_modelState_is_valid()
        //{
        //    var postedfile = Substitute.For<HttpPostedFileBase>();

        //    var result = studentController.UploadPost(postedfile) as RedirectToRouteResult;
        //    var action = result.RouteValues["Action"];

        //    action.ShouldBeEquivalentTo("CreateList");
        //}

    }
}
