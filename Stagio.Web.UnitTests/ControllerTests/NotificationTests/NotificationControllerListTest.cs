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
            const int USER_ID = 1;
            var notificationList = _fixture.CreateMany<Notification>(5).AsQueryable();
            foreach (var notification in notificationList)
            {
                notification.For = USER_ID;
            }
            notificationList.FirstOrDefault().For = 4;
            httpContextService.GetUserId().Returns(USER_ID);
            notificationRepository.GetAll().Returns(notificationList);

            var result = notificationController.NotificationList() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Notification.Notification>;

            model.Count().Should().Be(4);
        }
    }
}
