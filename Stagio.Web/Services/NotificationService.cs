using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class NotificationService : INotificationService
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Notification> _notificationRepository;


        public NotificationService(IEntityRepository<ApplicationUser> userRepository, IEntityRepository<Notification> notificationRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
        }

        public bool SendNotificationTo(int destinationId, string title, string message)
        {
            if (_userRepository.GetById(destinationId) != null)
            {
                Notification notification = new Notification()
                {
                    Date = DateTime.Now,
                    Title = title,
                    Message = message,
                    For = destinationId,
                    Seen = false
                };

                _notificationRepository.Add(notification);
                return true;
            }
            else
            {
                return false;
            }
 
        }
    }
}