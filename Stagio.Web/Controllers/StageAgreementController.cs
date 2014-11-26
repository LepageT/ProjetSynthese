using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.Domain.Application;

namespace Stagio.Web.Controllers
{
    public partial class StageAgreementController : Controller
    {
        public StageAgreementController()
        {
            
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult CreateConfirmation()
        {
            return View();
        }
    }
}