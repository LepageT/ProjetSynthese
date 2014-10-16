using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using NSubstitute;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.StudentTests
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

            studentController.ModelState.AddModelError("Error", "Error");
           
            var result = studentController.UploadPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("");
        }
    }
}
