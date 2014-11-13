using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Module.Strings.Email;
using Stagio.Web.Services;
using Stagio.Web.Module;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<ContactEnterprise> _enterpriseContactRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;
        private readonly IMailler _mailler;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Interview> _interviewRepository; 

        public CoordinatorController(IEntityRepository<ContactEnterprise> enterpriseContactRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Invitation> invitationRepository,
            IMailler mailler,
            IAccountService accountService,
            IEntityRepository<Apply> applyRepository,
            IEntityRepository<Stage> stageRepository,
            IEntityRepository<Student> studentRepository,
            IEntityRepository<Interview> interviewRepository)
        {
            _enterpriseContactRepository = enterpriseContactRepository;
            _coordinatorRepository = coordinatorRepository;
            _invitationRepository = invitationRepository;
            _mailler = mailler;
            _accountService = accountService;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _studentRepository = studentRepository;
            _interviewRepository = interviewRepository;
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

        [Authorize(Roles = RoleName.Coordinator)]
        // GET: Coordinator/InviteEnterprise
        public virtual ActionResult InviteContactEnterprise()
        {

            var allContactEnterprise = _enterpriseContactRepository.GetAll().ToList();

            var contactEnterpriseInviteViewModels = Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.Reactive>>(allContactEnterprise);

            return View(contactEnterpriseInviteViewModels);

        }

        [Authorize(Roles = RoleName.Coordinator)]
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
                        messageText += EmailEnterpriseResources.MessageHeader;
                        messageText += messageInvitation;
                    }

                    if (
                        !_mailler.SendEmail(contactEnterpriseToSendMessage.Email, EmailEnterpriseResources.InviteSubject,
                            messageText))
                    {
                        ModelState.AddModelError("Email", EmailResources.CantSendEmail);
                        return View(InviteContactEnterprise());
                    }

                }
                return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
            }

            return RedirectToAction(MVC.Coordinator.InviteContactEnterprise());

        }

        [Authorize(Roles = RoleName.Coordinator)]
        private string generateURLInvitationContactEnterprise(ContactEnterprise contactEnterpriseToSendMessage)
        {
            string enterpriseName = contactEnterpriseToSendMessage.EnterpriseName;
            if (enterpriseName.Contains(" "))
            {
                enterpriseName.Replace(" ", "%20");
            }
            if (contactEnterpriseToSendMessage.FirstName != null)
            {
                contactEnterpriseToSendMessage.FirstName = contactEnterpriseToSendMessage.FirstName.Replace(" ", "%20");
            }
            if (contactEnterpriseToSendMessage.LastName != null)
            {
                contactEnterpriseToSendMessage.LastName = contactEnterpriseToSendMessage.LastName.Replace(" ", "%20");
            }
            if (contactEnterpriseToSendMessage.Telephone != null)
            {
                contactEnterpriseToSendMessage.Telephone = contactEnterpriseToSendMessage.Telephone.Replace(" ", "%20");
            }
            if (contactEnterpriseToSendMessage.Poste != null)
            {
                contactEnterpriseToSendMessage.Poste = contactEnterpriseToSendMessage.Poste.Replace(" ", "%20");
            }

            string messageText = EmailCoordinatorResources.CoordinatorInviteEnterpriseMessage;
            string invitationUrl = "http://thomarelau.local/ContactEnterprise/Reactivate?Email=" +
                                   contactEnterpriseToSendMessage.Email + "&EnterpriseName=" +
                                   enterpriseName + "&FirstName=" +
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
                    coordinator.UserName = coordinator.Email;
                    coordinator.Password = _accountService.HashPassword(coordinator.Password);
                    _coordinatorRepository.Add(coordinator);

                    _mailler.SendEmail(createdCoordinator.Email, EmailAccountCreation.Subject, EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

                    return RedirectToAction(MVC.Coordinator.CreateConfirmation());
                }
            }

            return HttpNotFound();
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult Invite()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Coordinator)]
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
            String invitationUrl = EmailCoordinatorResources.CoordinatorInviteLink + token;

            messageText += invitationUrl;

            if (createdInvite.Message != null)
            {
                messageText += EmailCoordinatorResources.MessageHeader;
                messageText += createdInvite.Message;
            }

            if (!_mailler.SendEmail(createdInvite.Email, EmailCoordinatorResources.CoordinatorInviteSubject, messageText))
            {
                ModelState.AddModelError("Email", EmailResources.CantSendEmail);
                return View(createdInvite);
            }

            _invitationRepository.Add(new Invitation()
            {
                Token = token,
                Email = createdInvite.Email,
                Used = false
            });

            return RedirectToAction(MVC.Coordinator.InvitationSucceed());

        }

        public virtual ActionResult InvitationSucceed()
        {
            return View();
        }

        public virtual ActionResult CreateConfirmation()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult StudentList()
        {
            var allStudent = _studentRepository.GetAll().ToList();
            var studentListViewModels = Mapper.Map<IEnumerable<ViewModels.Coordinator.StudentList>>(allStudent).ToList();


            int nbApplyStudent = 0;

            var appliedStages = _applyRepository.GetAll().ToList();

            foreach (var student in studentListViewModels)
            {
                var studentSpecificApplies = appliedStages.Where(x => x.IdStudent == student.Id).ToList();
                foreach (var apply in studentSpecificApplies)
                {
                    nbApplyStudent = nbApplyStudent + 1;
                }
                student.NbApply = nbApplyStudent;
                nbApplyStudent = 0;
            }
           

            return View(studentListViewModels);
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult StudentApplyList(int studentId)
        {
            var studentValid = _studentRepository.GetById(studentId);
            if (studentValid == null)
            {
                return HttpNotFound();
            }

            var appliedStages = _applyRepository.GetAll().ToList();
            var studentSpecificApplies = appliedStages.Where(x => x.IdStudent == studentId).ToList();
            var stages = _stageRepository.GetAll().ToList();
            var students = _studentRepository.GetAll().ToList();
            var interviews = _interviewRepository.GetAll().ToList();

            var studentListApplyViewModels = Mapper.Map<IEnumerable<ViewModels.Coordinator.StudentApplyList>>(studentSpecificApplies).ToList();

            foreach (var appliedStage in studentListApplyViewModels)
            {
                foreach (var stage in stages)
                {
                    if (appliedStage.IdStage == stage.Id)
                    {
                        appliedStage.StageTitle = stage.StageTitle;
                        appliedStage.EnterpriseName = stage.CompanyName;
                    }
                }
                foreach (var student in students)
                {
                    if (appliedStage.Id == student.Id)
                    {
                        appliedStage.FirstName = student.FirstName;
                        appliedStage.LastName = student.LastName;
                        appliedStage.Matricule = student.Matricule;
                    }
                }
                foreach (var interview in interviews)
                {
                    if (appliedStage.Id == interview.StudentId)
                    {
                        appliedStage.DateInterview = interview.Date;

                    }
                }
            }

            

            return View(studentListApplyViewModels);
        }

    }
}
