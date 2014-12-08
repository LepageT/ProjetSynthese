using System.Web.Mvc;
using Stagio.Domain.Application;

namespace Stagio.Web.Controllers
{
    public partial class HomeController : Controller
    {

        public virtual ActionResult Index()
        {
            if (User != null)
            {
                if (User.IsInRole(RoleName.Student))
                {
                    return RedirectToAction(MVC.Student.Index());
                }
                if (User.IsInRole(RoleName.Coordinator))
                {
                    return RedirectToAction(MVC.Coordinator.Index());
                }
                if (User.IsInRole(RoleName.ContactEnterprise))
                {
                    return RedirectToAction(MVC.ContactEnterprise.Index());
                }
            }
            return View();

        }

    }
}