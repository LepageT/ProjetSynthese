using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.Controllers
{
    public partial class CoordonnateurController : Controller
    {
        // GET: Coordonnateur
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Create()
        {
            return View(Views.ViewNames.Create);
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.Coordonnateur.Create createdCoordonnateur)
        {
            return RedirectToAction(Views.ViewNames.Index);
        }
    }
}