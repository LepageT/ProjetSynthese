using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Controllers
{
    public partial class ApplyController : Controller
    {

        private readonly IEntityRepository<Apply> _applyRepository;

		public ApplyController(IEntityRepository<Apply> applyRepository)
		{
			_applyRepository = applyRepository;
		}
        //
        // GET: /Apply/
        public virtual ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Apply/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Apply/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Apply/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Apply/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Apply/Edit/5
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

        //
        // GET: /Apply/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Apply/Delete/5
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
