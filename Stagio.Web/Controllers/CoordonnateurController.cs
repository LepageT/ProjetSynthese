using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using  AutoMapper;

namespace Stagio.Web.Controllers
{
    public partial class CoordonnateurController : Controller
    {

        private readonly IEntityRepository<Coordonnateur> _coordonnateurRepository;

        public CoordonnateurController(IEntityRepository<Coordonnateur> coordonnateurRepository)
        {
            _coordonnateurRepository = coordonnateurRepository;
        }
        // GET: Coordonnateur
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Create()
        {
            return View(Views.ViewNames.Create);
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

            var coordonnateur = Mapper.Map<Coordonnateur>(createdCoordonnateur);

            _coordonnateurRepository.Add(coordonnateur);
            return RedirectToAction(Views.ViewNames.Index);
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
            String invitationUrl = "<br/><a href=stagio.local/Coordonnateur/Create?token=123456>Créer un compte</a>";

            message.Body += invitationUrl;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.live.com");

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("thomarellau@hotmail.com", "LesPommesRouge");
            smtp.EnableSsl = true;
            smtp.Send(message);

            return RedirectToAction(Views.ViewNames.Index);

        }
    }
}