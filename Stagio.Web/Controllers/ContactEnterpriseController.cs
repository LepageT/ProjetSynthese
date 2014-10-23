using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class ContactEnterpriseController : Controller
    {
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IAccountService _accountService;

        public ContactEnterpriseController(IEntityRepository<ContactEnterprise> enterpriseRepository, IEntityRepository<Stage> stageRepository, IAccountService accountService)
        {
            _contactEnterpriseRepository = enterpriseRepository;
            _accountService = accountService;
            _stageRepository = stageRepository;
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
        public virtual ActionResult Reactivate(string email, string firstName, string lastName, string enterpriseName, string telephone, int? poste)
        {
            var contactEnterprise = new ContactEnterprise();
            contactEnterprise.Email = email;
            contactEnterprise.FirstName = firstName;
            contactEnterprise.LastName = lastName;
            contactEnterprise.EnterpriseName = enterpriseName;
            contactEnterprise.Telephone = telephone;
            contactEnterprise.Poste = poste;
            var contactEnterpriseCreatePageViewModel = Mapper.Map<ViewModels.ContactEnterprise.Create>(contactEnterprise);
            return View(contactEnterpriseCreatePageViewModel);
        }

        // POST: Enterprise/Create
        [HttpPost]
        public virtual ActionResult Reactivate(ViewModels.ContactEnterprise.Create createViewModel)
        {

            if (ModelState.IsValid)
            {

                var contactEnterprise = _contactEnterpriseRepository.GetAll().FirstOrDefault(x => x.Email == createViewModel.Email);
                if (contactEnterprise != null)
                {
                    contactEnterprise.Active = true;
                    contactEnterprise.Password = createViewModel.Password;
                    contactEnterprise.Telephone = createViewModel.Telephone;
                    contactEnterprise.Poste = createViewModel.Poste;
                    _contactEnterpriseRepository.Update(contactEnterprise);
                    //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
                    return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation());
                }
                else
                {
                    var newContactEnterprise = Mapper.Map<ContactEnterprise>(createViewModel);
                    _contactEnterpriseRepository.Add(newContactEnterprise);
                    //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
                    return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation());
                }

            }
            return View(createViewModel);
           
        }


        public virtual ActionResult CreateConfirmation()
        {
            return View();
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
