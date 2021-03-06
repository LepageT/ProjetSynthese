﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerNotification: ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contactEnterprise_index_should_show_notification()
        {
            var notificationList = _fixture.CreateMany<Notification>(3);
            foreach (var notification in notificationList)
            {
                notification.For = 1;
                notification.Seen = false;
            }
            notificationRepository.GetAll().Returns(notificationList.AsQueryable());
            httpContext.GetUserId().Returns(1);

            var result = enterpriseController.Index() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Notification.Notification>;

            model.ShouldBeEquivalentTo(notificationList, options => options.ExcludingMissingProperties());

        }
    }
}
