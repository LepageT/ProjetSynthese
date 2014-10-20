using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using System.Net.Mail;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IEntityRepository<Enterprise> _enterpriseRepository;

        public CoordinatorController(IEntityRepository<Enterprise> enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }
        // GET: Coordinator
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: Coordinator/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Coordinator/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Coordinator/Create
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

        // GET: Coordinator/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Coordinator/Edit/5
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

        // GET: Coordinator/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Coordinator/Delete/5
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

        // GET: Coordinator/InviteEnterprise
        public virtual ActionResult InviteEnterprise()
        {
            
            var allEnterprise = _enterpriseRepository.GetAll().ToList();
            
            var enterpriseInviteViewModels = Mapper.Map<IEnumerable<ViewModels.Enterprise.Create>>(allEnterprise);

            return View(enterpriseInviteViewModels);
           
        }

        // POST: Coordinator/InviteEnterprise
        [HttpPost]
        [ActionName("InviteEnterprise")]
        public virtual ActionResult InviteEnterprise(IEnumerable<int> selectedObjects, string message)
        {
            if (selectedObjects != null)
            {
                foreach (int id in selectedObjects)
                {

                    Enterprise enterpriseToSendMessage = _enterpriseRepository.GetById(id);

                    if (!ModelState.IsValid)
                    {
                        return View(InviteEnterprise());
                    }


                    string messageText = "Un coordonateur de stage vous invite à vous inscrire au site Stagio: ";
                    string invitationUrl = "http://thomarelau.local/Enterprise/Create?Email=" +
                                           enterpriseToSendMessage.Email + "&EnterpriseName=" +
                                           enterpriseToSendMessage.EnterpriseName + "&FirstName=" +
                                           enterpriseToSendMessage.FirstName + "&LastName=" +
                                           enterpriseToSendMessage.LastName + "&Telephone=" +
                                           enterpriseToSendMessage.Telephone + "&Poste=" + enterpriseToSendMessage.Poste;

                    messageText += invitationUrl;

                    if (message != null)
                    {
                        messageText += "</br></br> <h3>Message:</h3></br>";
                        messageText += message;
                    }

                    if (
                        !Mailler.Instance.SendEmail(enterpriseToSendMessage.Email, "Invitation du Cégep de Sainte-Foy",
                            messageText))
                    {
                        ModelState.AddModelError("Email", "Error");
                        return View(InviteEnterprise());
                    }

                }
            }

            return RedirectToAction(MVC.Home.Index());
           
          
        }
    }
}
