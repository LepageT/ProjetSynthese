using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface INotificationService
    {
        bool SendNotificationTo(int destinationId, String title, String message);

        bool SendNotificationToAllCoordinator(String title, String message);

        bool SendNotificationToAllContactEnterpriseOf(String enterpriseName, String title, String message);

        ICollection<Notification> GetNotificationForUser(int userId, int count);

        ICollection<Notification> GetDashboardNotificationForUser(int userId);

    }
}
