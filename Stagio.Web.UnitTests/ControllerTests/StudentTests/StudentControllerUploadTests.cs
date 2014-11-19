using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerUploadTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void student_upload_should_render_view()
        {
            var result = studentController.Upload() as ViewResult;

            result.ViewName.Should().Be("");
        }

    }
}
