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
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IMailler _mailler;
        private readonly IEntityRepository<Student> _studentRepository;

        public ContactEnterpriseController(IEntityRepository<ContactEnterprise> enterpriseRepository, IEntityRepository<Stage> stageRepository, IAccountService accountService, IMailler mailler, IEntityRepository<Apply> applyRepository, IEntityRepository<Student> studentRepository)
        {
            _contactEnterpriseRepository = enterpriseRepository;
            _accountService = accountService;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
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
        public virtual ActionResult Reactivate(string email, string firstName, string lastName, string enterpriseName, string telephone, string poste)
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
            if (_accountService.UserEmailExist(createViewModel.Email))
            {
                ModelState.AddModelError("Email", "Ce email est déjà utilisé pour un compte entreprise.");
            }
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
                    return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation(contactEnterprise.Id));
                }
                else
                {
                    var newContactEnterprise = Mapper.Map<ContactEnterprise>(createViewModel);
                    newContactEnterprise.Active = true;
                    newContactEnterprise.UserName = newContactEnterprise.Email;
                    _contactEnterpriseRepository.Add(newContactEnterprise);
                    //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
                    return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation(newContactEnterprise.Id));
                }

            }
            return View(createViewModel);

        }


        public virtual ActionResult CreateConfirmation(int idContactEnterprise)
        {
            var newContactEnterprise = _contactEnterpriseRepository.GetById(idContactEnterprise);
            var newContactEntepriseViewModels = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(newContactEnterprise);
            return View(newContactEntepriseViewModels);
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
                                   contactEnterpriseToSendMessage.FirstName.Replace(" ", "%20") + "&LastName=" +
                                   contactEnterpriseToSendMessage.LastName.Replace(" ", "%20") + "&Telephone=" +
                                   contactEnterpriseToSendMessage.Telephone.Replace(" ", "%20") + "&Poste=" + contactEnterpriseToSendMessage.Poste.Replace(" ", "%20");
            messageText += invitationUrl;
            return messageText;
        }

        public virtual ActionResult ListStudentApply(int id)
        {
            //var students = _applyRepository.GetAll().Where(x => x.IdStage == id).Select(x=> x.IdStudent).ToList();
            var applies = _applyRepository.GetAll().Where(x => x.IdStage == id).ToList();
            var listStudents = new List<Student>();

            foreach (var apply in applies)
            {
                listStudents.Add(_studentRepository.GetById(apply.IdStudent));
            }

            var listStudentsApply = Mapper.Map<IEnumerable<ViewModels.Apply.StudentApply>>(applies).ToList();

            foreach (var studentApply in listStudentsApply)
            {
                foreach (var listStudent in listStudents)
                {
                    if (listStudent.Id == studentApply.IdStudent)
                    {
                        studentApply.FirstName = listStudent.FirstName;
                        studentApply.LastName = listStudent.LastName;
                    }
                }
            }

            return View(listStudentsApply);
        }

        public virtual ActionResult ListStage()
        {

            var stages = _stageRepository.GetAll();
            var listStages = Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.ListStage>>(stages).ToList();
            return View(listStages);
        }

        public virtual ActionResult DetailsStudentApply(int id)
        {

            var apply = _applyRepository.GetAll().FirstOrDefault(x => x.Id == id);

            var applyModel = Mapper.Map<ViewModels.Apply.StudentApply>(apply);

            return View(applyModel);
        }

        [HttpPost, ActionName("DetailsStudentApply")]
        public virtual ActionResult DetailsStudentApplyPost(string command, int id)
        {
            var apply = _applyRepository.GetById(id);

            if (apply == null)
            {
                return View("");
            }

            //Change status
            if (command.Equals("Accepter"))
            {
                apply.Status = 1; //1 = Accepter;
                _applyRepository.Update(apply);
                return RedirectToAction(MVC.ContactEnterprise.AcceptApplyConfirmation());
            }
            else if (command.Equals("Refuser"))
            {
                apply.Status = 2; //1 = Accepter;
                _applyRepository.Update(apply);
                return RedirectToAction(MVC.ContactEnterprise.RefuseApplyConfirmation());
            }
            else
            {
                return View("");
            }

        }

        public virtual ActionResult AcceptApplyConfirmation()
        {

            return View();
        }

        public virtual ActionResult RefuseApplyConfirmation()
        {

            return View();
        }

    }
}