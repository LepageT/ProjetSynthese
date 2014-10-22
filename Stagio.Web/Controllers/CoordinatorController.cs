using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Module.Strings;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Module.Strings.Email;
using Stagio.Web.Services;
using Stagio.Web.Module;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IEntityRepository<Enterprise> _enterpriseRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;
        private readonly IMailler _mailler;

        public CoordinatorController(IEntityRepository<Enterprise> enterpriseRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Invitation> invitationRepository,
            IMailler mailler)
        {
            _enterpriseRepository = enterpriseRepository;
            _coordinatorRepository = coordinatorRepository;
            _invitationRepository = invitationRepository;
            _mailler = mailler;
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


                    string messageText = EmailEnterpriseResources.InviteMessageBody;
                    string invitationUrl = EmailEnterpriseResources.InviteLink +
                                           enterpriseToSendMessage.Email + "&EnterpriseName=" +
                                           enterpriseToSendMessage.EnterpriseName + "&FirstName=" +
                                           enterpriseToSendMessage.FirstName + "&LastName=" +
                                           enterpriseToSendMessage.LastName + "&Telephone=" +
                                           enterpriseToSendMessage.Telephone + "&Poste=" + enterpriseToSendMessage.Poste;

                    messageText += invitationUrl;

                    if (message != null)
                    {
                        messageText += EmailEnterpriseResources.MessageHeader;
                        messageText += message;
                    }

                    if (
                        !_mailler.SendEmail(enterpriseToSendMessage.Email, EmailEnterpriseResources.InviteSubject,
                            messageText))
                    {
                        ModelState.AddModelError("Email", "Error");
                        return View(InviteEnterprise());
                    }

                }
            }

            return RedirectToAction(MVC.Home.Index());


        }

        public virtual ActionResult Create(string token)
        {
            if (!String.IsNullOrEmpty(token))
            {
                var invitation = _invitationRepository.GetAll().FirstOrDefault(x => x.Token == token);

                if (invitation == null)
                {
                    return HttpNotFound();
                }

                if (invitation.Used)
                {
                    return HttpNotFound();
                }

                var create = Mapper.Map<ViewModels.Coordinator.Create>(invitation);
                return View(create);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.Coordinator.Create createdCoordinator)
        {
            var list = _coordinatorRepository.GetAll();
            if (list != null)
            {
                var email = list.FirstOrDefault(x => x.Email == createdCoordinator.Email);
                if (email != null)
                {
                    ModelState.AddModelError("Email", CoordinatorResources.CoordinatorUseSameEmail);
                }

            }

            if (!ModelState.IsValid)
            {
                return View(createdCoordinator);
            }

            var invitation = _invitationRepository.GetById(createdCoordinator.InvitationId);
            //TODO Return a view with an error description instead of httpnotfound().
            if (invitation != null)
            {
                if (invitation.Email == createdCoordinator.Email)
                {
                    invitation.Used = true;

                    _invitationRepository.Update(invitation);

                    var coordinator = Mapper.Map<Coordinator>(createdCoordinator);

                    _coordinatorRepository.Add(coordinator);
                    return RedirectToAction(Views.ViewNames.Index);
                }
            }

            return HttpNotFound();
        }

        public virtual ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Invite(ViewModels.Coordinator.Invite createdInvite)
        {
            if (!ModelState.IsValid)
            {
                return View(createdInvite);
            }

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            TokenGenerator tokenGenerator = new TokenGenerator();

            string token = tokenGenerator.GenerateToken();

            //Sending invitation with the Mailler class
            String messageText = EmailCoordinatorResources.CoordinatorInviteMessageBody;
            String invitationUrl = EmailCoordinatorResources.CoordinatorInviteLink + token + ">Créer un compte</a>";

            messageText += invitationUrl;

            if (createdInvite.Message != null)
            {
                messageText += EmailCoordinatorResources.MessageHeader;
                messageText += createdInvite.Message;
            }

            if (!_mailler.SendEmail(createdInvite.Email, EmailCoordinatorResources.CoordinatorInviteSubject, messageText))
            {
                ModelState.AddModelError("Email", "Error");
                return View(createdInvite);
            }

            _invitationRepository.Add(new Invitation()
            {
                Token = token,
                Email = createdInvite.Email,
                Used = false
            });

            return RedirectToAction(MVC.Coordinator.Index());

        }

    }
}
