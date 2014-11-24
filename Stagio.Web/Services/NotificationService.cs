using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class NotificationService : INotificationService
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Notification> _notificationRepository;

        public NotificationService(IEntityRepository<ApplicationUser> userRepository,
            IEntityRepository<Notification> notificationRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
        }

        public bool SendNotificationTo(int destinationId, string title, string message)
        {
            if (_userRepository.GetById(destinationId) != null)
            {
                SendNotification(destinationId, title, message);
                return true;
            }

            return false;
        }


        public bool SendNotificationToAllCoordinator(String title, String message)
        {
            var userList = _userRepository.GetAll().ToList();
            var coordinatorRole = new UserRole() {RoleName = RoleName.Coordinator};
            var coordinatorList = new List<ApplicationUser>();
            foreach (var user in userList)
            {
                coordinatorList.AddRange(from role in user.Roles
                    where role.RoleName == coordinatorRole.RoleName
                    select user);
            }
            if (coordinatorList.Any())
            {
                foreach (var coordinator in coordinatorList)
                {
                    SendNotification(coordinator.Id, title, message);
                }
                return true;
            }
            return false;

        }

        public bool SendNotificationToAllContactEnterpriseOf(String enterpriseName, String title, String message)
        {
            var userList = _userRepository.GetAll().ToList();
            var contactEnterpriseRole = new UserRole() { RoleName = RoleName.ContactEnterprise };
            var contactEnterpriseList = new List<ApplicationUser>();
            foreach (var user in userList)
            {
                contactEnterpriseList.AddRange(from role in user.Roles where role.RoleName == contactEnterpriseRole.RoleName select user);
            }

            var enterpriseEmployees = contactEnterpriseList.Where(contactEnterprise => ((ContactEnterprise) contactEnterprise).EnterpriseName.Equals(enterpriseName)).ToList();

            if (enterpriseEmployees.Any())
            {
                foreach (var coordinator in enterpriseEmployees)
                {
                    SendNotification(coordinator.Id, title, message);
                }
                return true;
            }
            return false;

        }

        public ICollection<Notification> GetNotificationForUser(int userId, int count)
        {
            var notifications = _notificationRepository.GetAll().ToList();
            var userNotifications = notifications.Where(x => x.For == userId).ToList();

            return userNotifications.OrderByDescending(x => x.Date).ToList().GetRange(0, userNotifications.Count>count?count:userNotifications.Count);

        }

        public ICollection<Notification> GetDashboardNotificationForUser(int userId)
        {
            var notifications = _notificationRepository.GetAll().ToList();
            var userNotifications = notifications.Where(x => x.For == userId).ToList();
            var notSeenNotifications = userNotifications.Where(x => x.Seen == false).ToList();

            return notSeenNotifications.OrderByDescending(x => x.Date).ToList().GetRange(0, notSeenNotifications.Count>10?10:notSeenNotifications.Count);
        }

        private void SendNotification(int id, String title, String message)
        {
            var notification = new Notification()
            {
                Date = DateTime.Now,
                Title = title,
                Message = message,
                For = id,
                Seen = false
            };
            _notificationRepository.Add(notification);
        }

        
    }
}
