using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;
using Stagio.Web.Automation.PageObjects.Notification;

namespace Stagio.Web.AcceptanceTests.NotificationTest
{
    [TestClass]
    public class NotificationControllerNotificationListTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_notification_list_with_menu()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            NotificationListPage.GoTo();

            Assert.IsTrue(NotificationListPage.IsDisplayed);
        }

        [TestMethod]
        public void contactEnterprise_should_be_able_to_see_notification_list_with_menu()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            NotificationListPage.GoTo();

            Assert.IsTrue(NotificationListPage.IsDisplayed);
        }

        [TestMethod]
        public void student_should_be_able_to_see_notification_list_with_menu()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            NotificationListPage.GoTo();

            Assert.IsTrue(NotificationListPage.IsDisplayed);
        }

        [TestMethod]
        public void coordinator_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(5);

            Assert.IsTrue(NotificationListPage.IsDetailDisplayed);
        }

        [TestMethod]
        public void contactEnterprise_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(4);

            Assert.IsTrue(NotificationListPage.IsDetailDisplayed);
        }

        [TestMethod]
        public void student_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(1);

            Assert.IsTrue(NotificationListPage.IsDetailDisplayed);
        }

    }
}
