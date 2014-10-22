using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using System.Net.Mail;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IEntityRepository<ContactEnterprise> _enterpriseContactRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;
        private readonly IMailler _mailler;

        //For the token generation.
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public CoordinatorController(IEntityRepository<ContactEnterprise> enterpriseContactRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Invitation> invitationRepository, 
            IMailler mailler)
        {
            _enterpriseContactRepository = enterpriseContactRepository;
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
        public virtual ActionResult InviteContactEnterprise()
        {
            
            var allContactEnterprise = _enterpriseContactRepository.GetAll().ToList();
            
            var contactEnterpriseInviteViewModels = Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.Create>>(allContactEnterprise);

            return View(contactEnterpriseInviteViewModels);
           
        }

        // POST: Coordinator/InviteEnterprise
        [HttpPost]
        [ActionName("InviteContactEnterprise")]
        public virtual ActionResult InviteContactEnterprise(IEnumerable<int> selectedIdContactEnterprise, string messageInvitation)
        {
            if (selectedIdContactEnterprise != null)
            {
                foreach (int id in selectedIdContactEnterprise)
                {

                    ContactEnterprise contactEnterpriseToSendMessage = _enterpriseContactRepository.GetById(id);

                    if (!ModelState.IsValid)
                    {
                        return View(InviteContactEnterprise());
                    }

                    string messageText = generateURLInvitationContactEnterprise(contactEnterpriseToSendMessage);

                    if (messageInvitation != null)
                    {
                        messageText += "</br></br> <h3>Message:</h3></br>";
                        messageText += messageInvitation;
                    }

                    if (
                        !_mailler.SendEmail(contactEnterpriseToSendMessage.Email, "Invitation du Cégep de Sainte-Foy",
                            messageText))
                    {
                        ModelState.AddModelError("Email", "Error");
                        return View(InviteContactEnterprise());
                    }

                }
                return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
            }

            return View(InviteContactEnterprise());

        }

        private string generateURLInvitationContactEnterprise(ContactEnterprise contactEnterpriseToSendMessage)
        {
            string messageText = "Un coordonnateur de stage vous invite à vous inscrire au site Stagio: ";
            string invitationUrl = "http://thomarelau.local/ContactEnterprise/Create?Email=" +
                                   contactEnterpriseToSendMessage.Email + "&EnterpriseName=" +
                                   contactEnterpriseToSendMessage.EnterpriseName + "&FirstName=" +
                                   contactEnterpriseToSendMessage.FirstName + "&LastName=" +
                                   contactEnterpriseToSendMessage.LastName + "&Telephone=" +
                                   contactEnterpriseToSendMessage.Telephone + "&Poste=" + contactEnterpriseToSendMessage.Poste;

            messageText += invitationUrl;
            return messageText;
        }

        // GET: Coordinator/InviteContactEnterpriseConfirmation
        public virtual ActionResult InviteContactEnterpriseConfirmation()
        {
       
            return View();

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
                    ModelState.AddModelError("Email", "Un autre coordonnateur utilise la même courriel. Veuillez en utiliser un autre.");
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
            
            string token = generateToken();

            //Sending invitation with the Mailler class
            string messageText = "<h3>Stagio</h3>" +
                    "<p> Bonjour, </p>" +
                    "<p>Vous avez &eacute;t&eacute; inviter à vous cr&eacute;er un compte en tant que coordonnateur.</p>" +
                    "<p>Pour cr&eacute;er votre compte, veuillez cliquer sur le lien ci-dessous: </p>";
             String invitationUrl = "<a href=thomarelau/Coordinator/Create/" + token + ">Créer un compte</a>";

                messageText += invitationUrl;

                if (createdInvite.Message != null)
                {
                    messageText += "</br></br> <h3>Message:</h3></br>";
                    messageText += createdInvite.Message;
                }

            if (!_mailler.SendEmail(createdInvite.Email, "Création d'un compte coordonnateur",messageText))
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

        //TODO -- Maybe it need to be moved in services...
        private string generateToken()
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 15; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    
    }
}
