using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Application;

namespace Stagio.Web.UnitTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class NotificationControllerErrorTest: NotificationControllerBaseTests
    {
        [TestMethod]
        public void notification_error_should_display_error_view()
        {
            var result = notificationController.Error() as ViewResult;

            result.ViewName.Should().Be("");
        }

    }
}
