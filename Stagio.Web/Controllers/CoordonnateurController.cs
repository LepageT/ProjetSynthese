using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using AutoMapper;

namespace Stagio.Web.Controllers
{
    public partial class CoordonnateurController : Controller
    {

        private readonly IEntityRepository<Coordonnateur> _coordonnateurRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository; 
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
            if (token != null)
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

            message.To.Add(createdInvite.Email);
            message.Subject = "Création d'un compte coordonnateur";
            message.From = new System.Net.Mail.MailAddress("thomarellau@hotmail.com");
            message.IsBodyHtml = true;
            message.Body = createdInvite.Message;
            String invitationUrl = "<br/><a href=stagio.local/Coordonnateur/Create/123456>Créer un compte</a>";

            message.Body += invitationUrl;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.live.com");

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("thomarellau@hotmail.com", "LesPommesRouge");
            smtp.EnableSsl = true;
            smtp.Send(message);

            _invitationRepository.Add(new Invitation()
            {
                Token = "123456",
                Email = createdInvite.Email,
                Used = false
            });

            return RedirectToAction(Views.ViewNames.Index);

        }
    }
}