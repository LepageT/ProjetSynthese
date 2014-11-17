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
                if (User.IsInRole(RoleName.Student))
                {
                    notificationViewModel.PreviousUrl = MVC.Student.Index();
                }
                else if (User.IsInRole(RoleName.Coordinator))
                {
                    notificationViewModel.PreviousUrl = MVC.Coordinator.Index();
                }
                else if (User.IsInRole(RoleName.ContactEnterprise))
                {
                    notificationViewModel.PreviousUrl = MVC.ContactEnterprise.Index();
                }

                if (notification.For != _httpContextService.GetUserId())
                {
                    //TODO Must return error page.
                    return RedirectToAction(MVC.Notification.Error());
                }

               
                return View(notificationViewModel);
            }
            return HttpNotFound();

        }

        public virtual ActionResult Error()
        {
            var viewModel = new Stagio.Web.ViewModels.Notification.Error();

            if (User.IsInRole(RoleName.Student))
            {
                viewModel.Url = MVC.Student.Index();
            }
            else if (User.IsInRole(RoleName.Coordinator))
            {
                viewModel.Url = MVC.Coordinator.Index();
            }
            else if (User.IsInRole(RoleName.ContactEnterprise))
            {
                viewModel.Url = MVC.ContactEnterprise.Index();
            } return View(viewModel);
        }


    }
}