using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class NotificationControllerDetailTest : NotificationControllerBaseTests
    {
        [TestMethod]
        public void notification_detail_should_return_httpNotFound_if_notification_doesnt_exist()
        {
            var result = notificationController.Detail(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void notification_detail_should_display_error_if_notification_isnt_for_user()
        {
            var notification = _fixture.Create<Notification>();
            notification.For = 1;
            notificationRepository.GetById(1).Returns(notification);
            httpContextService.GetUserId().Returns(2);

            var result = notificationController.Detail(1) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.Notification.Views.ViewNames.Error);

        }

        [TestMethod]
        public void notification_detail_should_display_notification_information()
        {
            var notification = _fixture.Create<Notification>();
            notification.For = 1;
            notificationRepository.GetById(1).Returns(notification);
            httpContextService.GetUserId().Returns(1);

            var viewResult = notificationController.Detail(notification.For) as ViewResult;
            var model = viewResult.Model as ViewModels.Notification.Detail;

            model.ShouldBeEquivalentTo(notification, options => options.ExcludingMissingProperties());

        }
    }
}
