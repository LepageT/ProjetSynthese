using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<Enterprise> _enterpriseRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;
        private readonly IMailler _mailler;

        //For the token generation.
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public CoordinatorController(IEntityRepository<Enterprise> enterpriseRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Invitation> invitationRepository, 
            IMailler mailler,
            IAccountService accountService)
        {
            _enterpriseRepository = enterpriseRepository;
            _coordinatorRepository = coordinatorRepository;
            _invitationRepository = invitationRepository;
            _mailler = mailler;
            _accountService = accountService;
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
                        !_mailler.SendEmail(enterpriseToSendMessage.Email, "Invitation du Cégep de Sainte-Foy",
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
                    coordinator.UserName = coordinator.Email;
                    coordinator.Password = _accountService.HashPassword(coordinator.Password);
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
