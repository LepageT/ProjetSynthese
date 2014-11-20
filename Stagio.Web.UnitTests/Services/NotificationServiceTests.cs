using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class NotificationServiceTests : AllControllersBaseClassTests
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Notification> _notificationRepository;

        private NotificationService _notificationService;

        [TestInitialize]
        public void test_initialize()
        {
            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _notificationRepository = Substitute.For<IEntityRepository<Notification>>();

            _notificationService = new NotificationService(_userRepository, _notificationRepository);
        }

        [TestMethod]
        public void sendNotification_should_return_true_if_destination_exist()
        {
            var user = _fixture.Create<ApplicationUser>();
            _userRepository.GetById(user.Id).Returns(user);

            var result = _notificationService.SendNotificationTo(user.Id, "Test", "test");

            result.Should().BeTrue();
        }

        [TestMethod]
        public void sendNotification_should_return_false_if_destination_doesnt_exist()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Id = 1;
            _userRepository.GetById(user.Id).Returns(user);

            var result = _notificationService.SendNotificationTo(9999999, "Test", "test");

            result.Should().BeFalse();
        }

        [TestMethod]
        public void sendNotificationToCoordinator_should_return_true_if_there_is_coordinator()
        {
            var coordinators = _fixture.CreateMany<Coordinator>(3).AsQueryable();

            foreach (var coordinator in coordinators)
            {
                coordinator.Roles = new List<UserRole>()
                {
                    new UserRole() {RoleName = RoleName.Coordinator}
                };
                
            }
            _userRepository.GetAll().Returns(coordinators);

            var result = _notificationService.SendNotificationToAllCoordinator("test", "test");

            result.Should().BeTrue();

        }
    }
}
