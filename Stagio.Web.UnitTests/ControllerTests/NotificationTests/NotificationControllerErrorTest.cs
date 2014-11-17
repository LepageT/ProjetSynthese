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
        public void notification_student_error_should_display_student_home_link()
        {
            httpContextService.GetUserRole().Returns(new string[] { RoleName.Student });

            var viewResult = notificationController.Error() as ViewResult;
            var model = viewResult.Model as ViewModels.Notification.Error;
            var action = model.Url as ActionResult;

            action.ToString().ShouldBeEquivalentTo(MVC.Student.Index().ToString());
        }

        [TestMethod]
        public void notification_coordinator_error_should_display_coordinator_home_link()
        {

            httpContextService.GetUserRole().Returns(new string[] { RoleName.Coordinator });

            var viewResult = notificationController.Error() as ViewResult;
            var model = viewResult.Model as ViewModels.Notification.Error;
            var action = model.Url as ActionResult;

            action.ToString().ShouldBeEquivalentTo(MVC.Coordinator.Index().ToString());

        }

        [TestMethod]
        public void notification_contactEnterprise_error_should_display_contactEnterprise_home_link()
        {
            httpContextService.GetUserRole().Returns(new string[] { RoleName.ContactEnterprise });


            var viewResult = notificationController.Error() as ViewResult;
            var model = viewResult.Model as ViewModels.Notification.Error;
            var action = model.Url as ActionResult;

            action.ToString().ShouldBeEquivalentTo(MVC.ContactEnterprise.Index().ToString());

        }
    }
}
