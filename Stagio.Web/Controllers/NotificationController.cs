using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Ninject.Activation;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class NotificationController : Controller
    {
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Stagio.Domain.Entities.Notification> _notificationRepository;

        public NotificationController(IHttpContextService httpContextService, IEntityRepository<Stagio.Domain.Entities.Notification> notificationRepository)
        {
            _httpContextService = httpContextService;
            _notificationRepository = notificationRepository;
        }

        [Authorize]
        public virtual ActionResult Detail(int id)
        {
            var notification = _notificationRepository.GetById(id);

            if (notification != null)
            {
                var notificationViewModel = Mapper.Map<ViewModels.Notification.Detail>(notification);

                if (notification.For != _httpContextService.GetUserId())
                {
                    return RedirectToAction(MVC.Notification.Error());
                }

                notification.Seen = true;

                _notificationRepository.Update(notification);

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
            var notifications = _notificationRepository.GetAll().ToList();
            var notificationsList = notifications.Where(x => x.For == _httpContextService.GetUserId());
            var notificationsListViewModel = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(notificationsList).ToList();

            return View(notificationsListViewModel);
        }
        }


    }
