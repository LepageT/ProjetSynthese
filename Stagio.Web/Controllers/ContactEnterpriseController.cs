using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.Module.Strings.Email;

namespace Stagio.Web.Controllers
{
    public partial class ContactEnterpriseController : Controller
    {
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IAccountService _accountService;
        private readonly IMailler _mailler;
        private readonly  IEntityRepository<Apply> _applyRepository;
        private readonly IEntityRepository<Student> _studentRepository;

        public ContactEnterpriseController(IEntityRepository<ContactEnterprise> enterpriseRepository, IEntityRepository<Stage> stageRepository, IAccountService accountService, IMailler mailler, IEntityRepository<Apply> applyRepository, IEntityRepository<Student> studentRepository )
        {
            _contactEnterpriseRepository = enterpriseRepository;
            _accountService = accountService;
            _stageRepository = stageRepository;
            _applyRepository = applyRepository;
            _studentRepository = studentRepository;
            _mailler = mailler;
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
            contactEnterprise.UserName = email;
            var contactEnterpriseCreatePageViewModel = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(contactEnterprise);
            return View(contactEnterpriseCreatePageViewModel);
        }

        // POST: Enterprise/Create
        [HttpPost]
        public virtual ActionResult Reactivate(ViewModels.ContactEnterprise.Reactive createViewModel)
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
                    newContactEnterprise.UserName = newContactEnterprise.Email;
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
        public virtual ActionResult CreateStage()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult CreateStage(ViewModels.Stage.Create createdStage)
        {

            if (!ModelState.IsValid)
            {
                return View(createdStage);
            }

            var stage = Mapper.Map<Stage>(createdStage);
            stage.PublicationDate = DateTime.Now;

            _stageRepository.Add(stage);
            return RedirectToAction(MVC.ContactEnterprise.CreateStageSucceed());
        }

        public virtual ActionResult CreateStageSucceed()
        {
            return View();
        }

        public virtual ActionResult InviteContactEnterprise()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult InviteContactEnterprise(ViewModels.ContactEnterprise.Reactive createContactEnterpriseViewModel)
        {
           

            if (createContactEnterpriseViewModel.Email != null)
            {
                var contactEnterpriseToSendMessage = Mapper.Map<ContactEnterprise>(createContactEnterpriseViewModel);
                string messageInvitation = null;
                if (Request != null)
                {
                    messageInvitation = Request.Form["Message"];
                }

                string messageText = generateURLInvitationContactEnterprise(contactEnterpriseToSendMessage);

                if (messageInvitation != null)
                {
                    messageText += EmailEnterpriseResources.MessageHeader;
                    messageText += messageInvitation;
                }

                if (
                    !_mailler.SendEmail(contactEnterpriseToSendMessage.Email, EmailEnterpriseResources.InviteSubject,
                        messageText))
                {
                    ModelState.AddModelError("Email", "Error");
                    return View(InviteContactEnterprise());
                }
                return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
            }
            return View(createContactEnterpriseViewModel);
        }

        public virtual ActionResult ListStudentApply(int id)
        {
            var students = _applyRepository.GetAll().Where(x => x.IdStage == id).Select(x=> x.IdStudent);
            var listStudents = new List<Student>();

            foreach (var student in students)
            {
                listStudents.Add(_studentRepository.GetById(student));
            }

            TempData["idStage"] = id;
            var listStudentsApply = Mapper.Map<IEnumerable<ViewModels.Student.ListStudent>>(listStudents).ToList();
            return View(listStudentsApply);
        }

        [HttpPost, ActionName("ListStudentApply")]
        public virtual ActionResult ListStudentApplyPost(int id)
        {
            return View();
        }

        public virtual ActionResult ListStage()
        {
            
            var stages = _stageRepository.GetAll();
            var listStages =  Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.ListStage>>(stages).ToList();
            return View(listStages);
        }

        public virtual ActionResult DetailsStudentApply(int id)
        {
            var apply = _applyRepository.GetAll()
                           .Where(x => x.IdStudent == id)
                           .Where(x => x.IdStudent == Convert.ToInt32(TempData["idStage"]));

            var applyModel = Mapper.Map<ViewModels.Apply.StudentApply>(apply);

            return View(applyModel);
        }

        [HttpPost]
        public virtual ActionResult DetailsStudentApplyPost(int id)
        {
            return View();
        }

        private string generateURLInvitationContactEnterprise(ContactEnterprise contactEnterpriseToSendMessage)
        {
            string enterpriseName = contactEnterpriseToSendMessage.EnterpriseName;
            if (enterpriseName.Contains(" "))
            {
                enterpriseName.Replace(" ", "%20");
            }
            string messageText = "Un employé de votre entreprise vous invite à vous inscrire au site Stagio: ";
            string invitationUrl = "http://thomarelau.local/ContactEnterprise/Reactivate?Email=" +
                                   contactEnterpriseToSendMessage.Email + "&EnterpriseName=" +
                                   enterpriseName + "&FirstName=" +
                                   contactEnterpriseToSendMessage.FirstName + "&LastName=" +
                                   contactEnterpriseToSendMessage.LastName + "&Telephone=" +
                                   contactEnterpriseToSendMessage.Telephone + "&Poste=" + contactEnterpriseToSendMessage.Poste;

            messageText += invitationUrl;
            return messageText;
        }
    
    }
}

