using System.Web.Mvc;

namespace Stagio.Web.Controllers
{
    public partial class HomeController : Controller
    {

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}