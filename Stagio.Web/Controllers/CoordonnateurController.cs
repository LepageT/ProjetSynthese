using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using  AutoMapper;

namespace Stagio.Web.Controllers
{
    public partial class CoordonnateurController : Controller
    {

        private readonly IEntityRepository<Coordonnateur> _coordonnateurRepository;

        public CoordonnateurController(IEntityRepository<Coordonnateur> coordonnateurRepository)
        {
            _coordonnateurRepository = coordonnateurRepository;
        }
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

            var list = _coordonnateurRepository.GetAll();
            if (list != null)
            {
                var email = list.FirstOrDefault(x => x.Email == createdCoordonnateur.Email);
                if (email != null)
                {
                    ModelState.AddModelError("Email", "Un autre coordonnateur utilise la même courriel. Veuillez en utiliser un autre.");
                }

            }
           
            if (!ModelState.IsValid)
            {
                return View(createdCoordonnateur);
            }

            var coordonnateur = Mapper.Map<Coordonnateur>(createdCoordonnateur);

            _coordonnateurRepository.Add(coordonnateur);
            return RedirectToAction(Views.ViewNames.Index);
        }
    }
}