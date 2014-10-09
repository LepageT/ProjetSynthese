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

        public EnterpriseController(IEntityRepository<Enterprise> enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        // GET: Enterprise
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: Enterprise/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Enterprise/Create
        public virtual ActionResult Create(string email, string enterpriseName)
        {
            var enterprise = new Enterprise();
            enterprise.Email = email;
            enterprise.EnterpriseName = enterpriseName;
            var enterpriseCreatePageViewModel = Mapper.Map<ViewModels.Enterprise.Create>(enterprise);
            return View(enterpriseCreatePageViewModel);
        }

        // POST: Enterprise/Create
        [HttpPost]
        public virtual ActionResult Create(ViewModels.Enterprise.Create createViewModel)
        {
            try
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
            catch
            {
                return View();
            }
        }

        // GET: Enterprise/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Enterprise/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enterprise/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Enterprise/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
