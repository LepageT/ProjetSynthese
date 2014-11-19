using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class NotificationControllerListTest : NotificationControllerBaseTests
    {
        [TestMethod]
        public void notification_should_display_user_notification_list()
        {
            var notificationList = _fixture.CreateMany<Notification>(5);

            foreach (var notification in notificationList)
            {
                notification.For = 1;
            }

            notificationList.FirstOrDefault().For = 4;

            notificationRepository.GetAll().Returns(notificationList.AsQueryable());
            httpContextService.GetUserId().Returns(1);

            var result = notificationController.NotificationList() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Notification.Notification>;

            model.Count().Should().Be(4);
        }
    }
}
