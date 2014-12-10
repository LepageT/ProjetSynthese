using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreateConfirmationTest : InterviewControllerBaseClassTests
    {
        [TestMethod]
        public void interview_createConfirmation_should_render_view()
        {
            var result = interviewController.InterviewCreateConfirmation() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
