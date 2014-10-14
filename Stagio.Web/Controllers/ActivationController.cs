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
    public class ActivationController : Controller
    {

        private readonly IEntityRepository<Activation> _activationRepository;
        private readonly IEntityRepository<Student> _studentRepository;


        public ActivationController(IEntityRepository<Activation> activationRepository, IEntityRepository<Student> studentRepository)
        {
            _activationRepository = activationRepository;
            _studentRepository = studentRepository;
        }
        // GET: Activation
        public ActionResult Index(string token)
        {
            if (!String.IsNullOrEmpty(token))
            {

                var activation = _activationRepository.GetAll().FirstOrDefault(x => x.Token == token);
                if (activation == null)
                {
                    return HttpNotFound();
                }

                switch(activation.AccountType)
                {
                    case 1:
                        var account = _studentRepository.GetById(activation.AccountId);
                        if(account != null)
                        {
                            account.Activated = true;
                            _studentRepository.Update(account);
                        }
                        break;
                    default:
                        break;
                };

                _activationRepository.Delete(activation);

                return View();
            }

            return HttpNotFound();
        }
    }
}