using AutoMapper;
using Stagio.DataLayer;
using Stagio.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Stagio.Web.Controllers
{
    public partial class NotificationController : Controller
    {
        private readonly IHttpContextService _httpContextService;
        private readonly INotificationService _notificationService;

        public NotificationController(IHttpContextService httpContextService, INotificationService notificationService)
        {
            _httpContextService = httpContextService;
            _notificationService = notificationService;
        }

        [Authorize]
        public virtual ActionResult Detail(int id)
        {
            var notification = _notificationService.GetNotification(id);

            if (notification != null)
            {
                var notificationViewModel = Mapper.Map<ViewModels.Notification.Detail>(notification);

                if (notification.For != _httpContextService.GetUserId())
                {
                    return RedirectToAction(MVC.Notification.Error());
                }

                notification.Seen = true;

                _notificationService.MarkNotificationAsSeen(notification);

                return View(notificationViewModel);
            }
            return HttpNotFound();
        }

        public virtual ActionResult Error()
        {    
            return View();
        }

        [Authorize]
        public virtual ActionResult NotificationList()
        {
            var notifications = _notificationService.GetNotificationForUser(_httpContextService.GetUserId());
            var notificationsList = notifications.OrderByDescending(x => x.Date).Where(x => x.For == _httpContextService.GetUserId());
            var notificationsListViewModel = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(notificationsList).ToList();

            return View(notificationsListViewModel);
        }
        }


    }
