using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Controllers
{
    public partial class EnterpriseController : Controller
    {
        private readonly IEntityRepository<Enterprise> _enterpriseRepository;
        private readonly IEntityRepository<Stage> _stageRepository;

        public EnterpriseController(IEntityRepository<Enterprise> enterpriseRepository, IEntityRepository<Stage> stageRepository )
        {
            _enterpriseRepository = enterpriseRepository;
            _stageRepository = stageRepository;
        }

        // GET: Enterprise/Create
        public virtual ActionResult Create(string email, string firstName, string lastName, string enterpriseName, string telephone, int? poste)
        {
            var enterprise = new Enterprise();
            enterprise.Email = email;
            enterprise.FirstName = firstName;
            enterprise.LastName = lastName;
            enterprise.EnterpriseName = enterpriseName;
            enterprise.Telephone = telephone;
            enterprise.Poste = poste;
            var enterpriseCreatePageViewModel = Mapper.Map<ViewModels.Enterprise.Create>(enterprise);

            return View(enterpriseCreatePageViewModel);
        }

        // POST: Enterprise/Create
        [HttpPost]
        public virtual ActionResult Create(ViewModels.Enterprise.Create createViewModel)
        {

            if (ModelState.IsValid)
            {
                var enterprise = Mapper.Map<Enterprise>(createViewModel);
                _enterpriseRepository.Add(enterprise);
                //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
                return RedirectToAction(MVC.Home.Index());
            }
            return View(createViewModel);
           
        }

        public virtual ActionResult CreateStage()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult CreateStage(ViewModels.Stage.Create createdStage)
        {

            if (!ModelState.IsValid)
            {
                return View(createdStage);
            }

            var stage = Mapper.Map<Stage>(createdStage);
            stage.PublicationDate = DateTime.Now;

            _stageRepository.Add(stage);
            return RedirectToAction(MVC.Enterprise.CreateStageSucceed());
        }

        public virtual ActionResult CreateStageSucceed()
        {
            return View();
        }
    }
}
