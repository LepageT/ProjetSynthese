
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;


namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerUploadTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void upload_action_should_render_default_view()
        {
            var result = studentController.Upload() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var postedfile = Substitute.For<HttpPostedFileBase>();
            studentController.ModelState.AddModelError("Error", "Error");

            var result = studentController.UploadPost(postedfile) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void upload_post_should_return_default_view_when_file_is_null()
        {
            var postedfile = Substitute.For<HttpPostedFileBase>();
            postedfile = null;

            var result = studentController.UploadPost(postedfile) as ViewResult;

            result.ViewName.Should().Be("");
        }


    }
}
