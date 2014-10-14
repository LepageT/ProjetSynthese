using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Activation> _activationRepository;


        public StudentController(IEntityRepository<Student> studentRepository, IEntityRepository<Activation> activationRepository)
        {
            _studentRepository = studentRepository;
            _activationRepository = activationRepository;
        }


        // GET: Student
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public virtual ActionResult Create(ViewModels.Student.Create createStudentViewModel)
        {
            var student = _studentRepository.GetAll().FirstOrDefault(x => x.Matricule == createStudentViewModel.Matricule);

            if(student == null)
            {
                ModelState.AddModelError("Matricule", "Votre matricule ne figure pas dans la liste des matricules autorisés.");
            }
            else
            {
                if (student.FirstName != createStudentViewModel.FirstName)
                {
                    ModelState.AddModelError("FirstName", "Votre nom ne correspond pas à celui associé à votre matricule.");
                }

                if (student.LastName != createStudentViewModel.LastName)
                {
                    ModelState.AddModelError("LastName", "Votre prénom ne correspond pas à celui associé à votre matricule.");
                }

                if (student.Activated)
                {
                    ModelState.AddModelError("Matricule", "Votre matricule est déja utilisé.");
                }
            }



            if(!ModelState.IsValid)
            {
                return View(createStudentViewModel);
            }

            Mapper.Map(createStudentViewModel, student);

            _studentRepository.Update(student);

            //TODO Send an activation email.

           /* System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            try
            {
                message.To.Add(createStudentViewModel.Email);
                message.Subject = "Activation";
                message.From = new System.Net.Mail.MailAddress("thomarellau@hotmail.com");
                message.IsBodyHtml = true;
                message.Body = "Merci d'avoir créer votre compte Stagio. Vous devez l'activer en cliquant sur le lien suivant.";
                var token = "123456";

                String invitationUrl = "<br/><a href=stagio.local/Activation/" + token + ">Créer un compte</a>";

                message.Body += invitationUrl;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.live.com");

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("thomarellau@hotmail.com", "LesPommesRouge2");
                smtp.EnableSsl = true;
                smtp.Send(message);

                _activationRepository.Add(new Activation()
                {
                    Token = token,
                    AccountId = createStudentViewModel.Id,
                    AccountType = 1
                });
            }
            catch (Exception e)
            {
               
            }*/

            return RedirectToAction(MVC.Home.Index());
        }

        // GET: Student/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student != null)
            {
                var studentEditPageViewModel = Mapper.Map<ViewModels.Student.Edit>(student);

                return View(studentEditPageViewModel);
            }
            return HttpNotFound();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Student.Edit editStudentViewModel)
        {
            var student = _studentRepository.GetById(editStudentViewModel.Id);
            if (student == null)
            {
                return HttpNotFound();
            }
                     
            
            if (editStudentViewModel.OldPassword != student.Password)
            {
                ModelState.AddModelError("OldPassword", "L'ancien mot de passe n'est pas valide.");
            }
            

            if (!ModelState.IsValid)
            {
                return View(editStudentViewModel);
            }

            Mapper.Map(editStudentViewModel, student);

            _studentRepository.Update(student);

            return RedirectToAction(MVC.Home.Index());

        }

        // GET: Student/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
