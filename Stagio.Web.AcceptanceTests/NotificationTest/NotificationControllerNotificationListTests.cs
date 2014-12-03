using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
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

            NotificationListPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void contactEnterprise_should_be_able_to_see_notification_list_with_menu()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            NotificationListPage.GoTo();

            NotificationListPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void student_should_be_able_to_see_notification_list_with_menu()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            NotificationListPage.GoTo();

            NotificationListPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void coordinator_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(5);

            NotificationListPage.IsDetailDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void contactEnterprise_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(4);

            NotificationListPage.IsDetailDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void student_should_be_able_to_see_notification_detail_from_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            NotificationListPage.GoTo();

            NotificationListPage.GoToNotification(1);

            NotificationListPage.IsDetailDisplayed.Should().BeTrue();
        }

    }
}
