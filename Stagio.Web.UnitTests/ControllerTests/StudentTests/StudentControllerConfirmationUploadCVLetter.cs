﻿using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerConfirmationUploadCVLetter : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void confirmationUploadCVLetter_Should_render_view()
        {
            var result = studentController.ConfirmationUploadCVLetter() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
