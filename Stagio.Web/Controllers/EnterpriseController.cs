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
        public virtual ActionResult Create()
        {
            return View();
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
