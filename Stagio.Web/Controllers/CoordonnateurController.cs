using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using System.Text;

namespace Stagio.Web.Controllers
{
    public partial class CoordonnateurController : Controller
    {

        private readonly IEntityRepository<Coordonnateur> _coordonnateurRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;

        //For the token generation.
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public CoordonnateurController(IEntityRepository<Coordonnateur> coordonnateurRepository, IEntityRepository<Invitation> invitationRepository)
        {
            _coordonnateurRepository = coordonnateurRepository;
            _invitationRepository = invitationRepository;
        }
        // GET: Coordonnateur
        public virtual ActionResult Index()
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

                var create = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);
                return View(create);
            }

            return HttpNotFound();
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

            var invitation = _invitationRepository.GetById(createdCoordonnateur.InvitationId);
            //TODO Return a view with an error description instead of httpnotfound().
            if (invitation != null)
            {
                if (invitation.Email == createdCoordonnateur.Email)
                {
                    invitation.Used = true;

                    _invitationRepository.Update(invitation);

                    var coordonnateur = Mapper.Map<Coordonnateur>(createdCoordonnateur);

                    _coordonnateurRepository.Add(coordonnateur);
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
        public virtual ActionResult Invite(ViewModels.Coordonnateur.Invite createdInvite)
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
             String invitationUrl = "<a href=stagio.local/Coordonnateur/Create/" + token + ">Créer un compte</a>";

                messageText += invitationUrl;

                if (createdInvite.Message != null)
                {
                    messageText += "</br></br> <h3>Message:</h3></br>";
                    messageText += createdInvite.Message;
                }

            if (!Mailler.Instance.SendEmail(createdInvite.Email, "Création d'un compte coordonnateur",messageText))
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

            return RedirectToAction(MVC.Coordonnateur.Index());

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

  