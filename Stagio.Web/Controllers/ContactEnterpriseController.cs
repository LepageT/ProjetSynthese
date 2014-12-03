using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Module.Strings.Shared;
using Stagio.Web.Services;
using Stagio.Web.Module.Strings.Email;

namespace Stagio.Web.Controllers
{
    [Authorize(Roles = RoleName.ContactEnterprise)]
    public partial class ContactEnterpriseController : Controller
    {
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IMailler _mailler;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IHttpContextService _httpContext;
        private readonly IEntityRepository<InvitationContactEnterprise> _invitationRepository;
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository;
        private readonly INotificationService _notificationService;


        public ContactEnterpriseController(IEntityRepository<ContactEnterprise> enterpriseRepository, IEntityRepository<Stage> stageRepository, IAccountService accountService, IMailler mailler, IEntityRepository<Apply> applyRepository, IEntityRepository<Student> studentRepository, IHttpContextService httpContext, IEntityRepository<InvitationContactEnterprise> invitationRepository, IEntityRepository<Notification> notificationRepository, IEntityRepository<ApplicationUser> applicationUserRepository)
        {
            _contactEnterpriseRepository = enterpriseRepository;
            _accountService = accountService;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _applyRepository = applyRepository;
            _studentRepository = studentRepository;
            _mailler = mailler;
            _httpContext = httpContext;
            _invitationRepository = invitationRepository;
            _notificationRepository = notificationRepository;
            _applicationUserRepository = applicationUserRepository;
            _notificationService = new NotificationService(_applicationUserRepository, notificationRepository);
        }

        // GET: Enterprise
        public virtual ActionResult Index()
        {
            var notifications = _notificationService.GetDashboardNotificationForUser(_httpContext.GetUserId());

            var notificationsViewModels = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(notifications).ToList();

            return View(notificationsViewModels);
        }

        [AllowAnonymousAttribute]
        public virtual ActionResult Create()
        {
            return View();
        }
        [AllowAnonymousAttribute]
        [HttpPost]
        public virtual ActionResult Create(ViewModels.ContactEnterprise.Create createViewModel)
        {
            var list = _contactEnterpriseRepository.GetAll();
            if (list != null)
            {
                var email = list.FirstOrDefault(x => x.Email == createViewModel.Email);
                if (email != null)
                {
                    this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                    ModelState.AddModelError("Email", ContactEnterpriseResources.EmailContactEnterpriseAlreadyUsed);
                }

            }

            if (ModelState.IsValid)
            {

                var newContactEnterprise = Mapper.Map<ContactEnterprise>(createViewModel);
                newContactEnterprise.Active = true;
                newContactEnterprise.Password = _accountService.HashPassword(newContactEnterprise.Password);
                newContactEnterprise.UserName = newContactEnterprise.Email;
                newContactEnterprise.Roles = new List<UserRole>()
                    {
                        new UserRole() {RoleName = RoleName.ContactEnterprise}
                    };
                _contactEnterpriseRepository.Add(newContactEnterprise);
                string message = String.Format(ContactEntrepriseToCoordinator.CreateContactEnterprise, newContactEnterprise.FirstName, newContactEnterprise.LastName);

                _notificationService.SendNotificationToAllCoordinator(
                    ContactEntrepriseToCoordinator.CreateContactEnterpriseTitle, message);
                _mailler.SendEmail(newContactEnterprise.Email, EmailAccountCreation.Subject, EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

                //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
                this.Flash(FlashMessageResources.CreateAccountSuccess, FlashEnum.Success);
                return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation(newContactEnterprise.Id));

            }
            return View(createViewModel);
        }

        // GET: Enterprise/Reactivate
        public virtual ActionResult Reactivate(string token)
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

                var contactEnterpriseCreatePageViewModel = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(invitation);
                return View(contactEnterpriseCreatePageViewModel);
            }

            return HttpNotFound();
        }

        // POST: Enterprise/Reactivate
        [HttpPost]
        public virtual ActionResult Reactivate(ViewModels.ContactEnterprise.Reactive createViewModel)
        {
            var list = _contactEnterpriseRepository.GetAll();
            if (list != null)
            {
                var email = list.FirstOrDefault(x => x.Email == createViewModel.Email);
                if (email != null)
                {
                    ModelState.AddModelError("Email", ContactEnterpriseResources.EmailContactEnterpriseAlreadyUsed);
                }

            }

            if (!ModelState.IsValid)
            {
                this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                return View(createViewModel);
            }

                var invitation = _invitationRepository.GetById(createViewModel.InvitationId);
                if (invitation != null)
                {
                    if (invitation.Email == createViewModel.Email)
                    {
                        invitation.Used = true;

                        _invitationRepository.Update(invitation);

                        var contactEnterprise = Mapper.Map<ContactEnterprise>(createViewModel);
                        contactEnterprise.UserName = contactEnterprise.Email;
                        contactEnterprise.Password = _accountService.HashPassword(contactEnterprise.Password);
                        _contactEnterpriseRepository.Add(contactEnterprise);
                        string message = String.Format(ContactEntrepriseToCoordinator.CreateContactEnterprise, contactEnterprise.FirstName, contactEnterprise.LastName);

                        _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.CreateContactEnterpriseTitle, message);
                        _mailler.SendEmail(createViewModel.Email, EmailAccountCreation.Subject,
                            EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

                        this.Flash(FlashMessageResources.ReactivateSuccess, FlashEnum.Success);
                        return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation(contactEnterprise.Id));
                    }
                }

            return HttpNotFound();

        }


        public virtual ActionResult CreateConfirmation(int idContactEnterprise)
        {
            var newContactEnterprise = _contactEnterpriseRepository.GetById(idContactEnterprise);
            var newContactEntepriseViewModels = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(newContactEnterprise);
            return View(newContactEntepriseViewModels);
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        public virtual ActionResult CreateStage()
        {
            return View();
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        [HttpPost]
        public virtual ActionResult CreateStage(ViewModels.Stage.Create createdStage, string ButtonClick = "")
        {

            if (ButtonClick.Equals(ContactEnterpriseResources.SaveHasDraft))
            {
                var stage = Mapper.Map<Stage>(createdStage);
                stage.PublicationDate = DateTime.Now.ToString();
                stage.Status = StageStatus.Draft;
                _stageRepository.Add(stage);

                return View(MVC.ContactEnterprise.Views.ViewNames.DraftConfirmation);
            }
            else
        {

            if (!ModelState.IsValid)
            {
                    this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                return View(createdStage);
            }

            var stage = Mapper.Map<Stage>(createdStage);
            stage.PublicationDate = DateTime.Now.ToString();

            _stageRepository.Add(stage);
            this.Flash("Stage en attente d'approbation", FlashEnum.Info);
            string message = String.Format(ContactEntrepriseToCoordinator.NewStageMessage, stage.CompanyName, stage.Id, stage.StageTitle);    
            _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.NewStageTitle, message);
            
            return RedirectToAction(MVC.ContactEnterprise.CreateStageSucceed());
        }
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        public virtual ActionResult CreateStageSucceed()
        {
            return View();
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        public virtual ActionResult InviteContactEnterprise()
        {
            return View();
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        [HttpPost]
        public virtual ActionResult InviteContactEnterprise(ViewModels.ContactEnterprise.Invite createdInviteContactEnterpriseViewModel)
        {


            if (!ModelState.IsValid)
            {
                this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                return View(createdInviteContactEnterpriseViewModel);
            }

            TokenGenerator tokenGenerator = new TokenGenerator();

            string token = tokenGenerator.GenerateToken();

            //Sending invitation with the Mailler class
            String messageText = EmailEnterpriseResources.InviteCoworker;
            String invitationUrl = String.Format(EmailEnterpriseResources.InviteLinkCoworker, token);

            messageText += invitationUrl;

            if (createdInviteContactEnterpriseViewModel.Message != null)
            {
                messageText += EmailEnterpriseResources.MessageHeader;
                messageText += createdInviteContactEnterpriseViewModel.Message;
            }

            if (!_mailler.SendEmail(createdInviteContactEnterpriseViewModel.Email, EmailEnterpriseResources.InviteSubject, messageText))
            {
                ModelState.AddModelError("Email", EmailResources.CantSendEmail);
                this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                return View();
            }

            _invitationRepository.Add(new InvitationContactEnterprise()
            {
                Token = token,
                Email = createdInviteContactEnterpriseViewModel.Email,
                FirstName = createdInviteContactEnterpriseViewModel.FirstName,
                LastName = createdInviteContactEnterpriseViewModel.LastName,
                EnterpriseName = createdInviteContactEnterpriseViewModel.EnterpriseName,
                Telephone = createdInviteContactEnterpriseViewModel.Telephone,
                Poste = createdInviteContactEnterpriseViewModel.Poste,
                Used = false
            });
            this.Flash(FlashMessageResources.InvitationSend, FlashEnum.Info);
            return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
        }

        public virtual ActionResult ListStudentApply(int id)
        {

            var applies = new List<Apply>();
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            var stage = _stageRepository.GetById(id);
            if (stage.CompanyName != user.EnterpriseName)
            {
                this.Flash(FlashMessageResources.NotAccessStage, FlashEnum.Warning);
                return RedirectToAction(MVC.ContactEnterprise.ListStage());
            }
            try
            {
                applies = _applyRepository.GetAll().Where(x => x.IdStage == id).ToList();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            var students = _studentRepository.GetAll().ToList();
//TODO A vérifier!!!!!
            var listStudents = (from apply in applies from student in students where student.Id == apply.IdStudent select student).ToList();

            var listStudentsApply = Mapper.Map<IEnumerable<ViewModels.Apply.StudentApply>>(applies).ToList();

            foreach (var studentApply in listStudentsApply)
            {
                foreach (var listStudent in listStudents.Where(listStudent => listStudent.Id == studentApply.IdStudent))
                {
                        studentApply.FirstName = listStudent.FirstName;
                        studentApply.LastName = listStudent.LastName;
                    }
                }

            return View(listStudentsApply);
        }


        public virtual ActionResult ListStage()
        {
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            var stages = _stageRepository.GetAll();

            if (stages.Any())
            {
                stages = stages.Where(x => x.CompanyName == user.EnterpriseName);
            }

            var listStages = Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.ListStage>>(stages).ToList();
            return View(listStages);
        }


        public virtual ActionResult DetailsStudentApply(int id, bool canNotDownload)
        {
            if (canNotDownload)
            {
                ViewBag.Message = ContactEnterpriseResources.FilesCantBeDownload;
            }
            //TODO À arranger
            var apply = new Apply();
            try
            {
                apply = _applyRepository.GetAll().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            if (apply == null)
            {
                this.Flash(FlashMessageResources.ApplyNotExist, FlashEnum.Info);
                return RedirectToAction(MVC.ContactEnterprise.ListStage());
            }
            var stage = _stageRepository.GetById(apply.IdStage);
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            var student = _studentRepository.GetAll().FirstOrDefault(x => x.Id == apply.IdStudent);
            if (stage.CompanyName != user.EnterpriseName)
            {
                this.Flash(FlashMessageResources.NotAccessApply, FlashEnum.Warning);
                return RedirectToAction(MVC.ContactEnterprise.ListStage());
            }
            var applyModel = Mapper.Map<ViewModels.Apply.StudentApply>(apply);

            applyModel.FirstName = student.FirstName;
            applyModel.LastName = student.LastName;
            applyModel.StageTitle = stage.StageTitle;
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
            var stage = _stageRepository.GetById(apply.IdStage);
            var student = _studentRepository.GetById(apply.IdStudent);
           
            //Change status
            if (command.Equals(ContactEnterpriseResources.Interested))
            {
                apply.Status = StatusApply.Accepted;
                _applyRepository.Update(apply);
                var acceptApply =
                    Mapper.Map<ViewModels.ContactEnterprise.AcceptApply>(_studentRepository.GetById(apply.IdStudent));   
                string message = String.Format(ContactEntrepriseToCoordinator.InterestedBy, stage.CompanyName, student.FirstName, student.LastName);

                _notificationService.SendNotificationToAllCoordinator(
                    ContactEntrepriseToCoordinator.InterestedByTitle, message);
                return View(MVC.ContactEnterprise.Views.ViewNames.AcceptApplyConfirmation, acceptApply);
            }
            else if (command.Equals(ContactEnterpriseResources.NotInterested))
            {
                apply.Status = StatusApply.Refused;
                _applyRepository.Update(apply);
                string message = String.Format(ContactEntrepriseToCoordinator.NotInterestedBy, stage.CompanyName, student.FirstName, student.LastName);
                _notificationService.SendNotificationToAllCoordinator(
                    ContactEntrepriseToCoordinator.NotInterestedByTitle, message);
                return RedirectToAction(MVC.ContactEnterprise.RefuseApplyConfirmation());
            }
            else
            {
                return View("");
            }
        }


        public virtual ActionResult RefuseApplyConfirmation()
        {

            return View();
        }

        public virtual ActionResult Download(string file, int id)
        {
            var readFile = new ReadFile();
            try
            {
               return File(readFile.Download(file), System.Net.Mime.MediaTypeNames.Application.Octet, file);
            }
            catch (Exception)
            {
                return RedirectToAction(MVC.ContactEnterprise.DetailsStudentApply(id, true));
            }
        }

        public virtual ActionResult RemoveStageConfirmation(int idStage)
        {
            //TODO
            var stage = _stageRepository.GetById(idStage);
            var applies = _applyRepository.GetAll().ToList().Where(x => x.IdStage == idStage);
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            if (stage == null)
            {
                return HttpNotFound();
            }
            if (stage.CompanyName != user.EnterpriseName)
            {
                this.Flash(FlashMessageResources.NotAccessStageRemove, FlashEnum.Warning);
                return RedirectToAction(MVC.ContactEnterprise.ListStage());
            }
            string path = _httpContext.GetPathDetailStage(idStage);
            string message = String.Format(ContactEntrepriseToCoordinator.RemoveStage, stage.CompanyName, idStage, stage.StageTitle);
            
            _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.RemoveStageTitle, message);

            message = String.Format(ContactEnterpriseToStudent.RemoveStage, stage.CompanyName, stage.StageTitle);
            _notificationService.SendNotificationToAllStudent(ContactEnterpriseToStudent.RemoveStageTitle, message);

            
            
            stage.Status = StageStatus.Removed;
            _stageRepository.Update(stage);
            this.Flash(FlashMessageResources.StageDesactivated, FlashEnum.Warning);
            return View();
        }

        public virtual ActionResult ReactivateStageConfirmation(int idStage)
        {
            var stage = _stageRepository.GetById(idStage);
            if (stage == null)
            {
                return HttpNotFound();
            }
            stage.Status = StageStatus.New;
            stage.PublicationDate = DateTime.Now.ToString();
            _stageRepository.Update(stage);
            this.Flash(FlashMessageResources.StageReactivated, FlashEnum.Info);
            return View();
        }

        public virtual ActionResult DraftList()
        {
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            var draftList = _stageRepository.GetAll();

            if (draftList.Any())
            {
                draftList = draftList.Where(x => x.CompanyName == user.EnterpriseName).Where(x => x.Status == StageStatus.Draft);
            }

            var listDrafts = Mapper.Map<IEnumerable<ViewModels.ContactEnterprise.Draft>>(draftList).ToList();
            return View(listDrafts);
        }

        public virtual ActionResult Edit()
        {
            var contactEnterprise = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            if (contactEnterprise == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<ViewModels.ContactEnterprise.Edit>(contactEnterprise);

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(ViewModels.ContactEnterprise.Edit editContactInformation)
        {
            var contact = _contactEnterpriseRepository.GetById(editContactInformation.Id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            if (!editContactInformation.OldPassword.IsNullOrWhiteSpace())
            {
                if (!PasswordHash.ValidatePassword(editContactInformation.OldPassword, contact.Password))
                {
                    ModelState.AddModelError("OldPassword", StudentResources.OldPasswordInvalid);
                }
            }

            if (!ModelState.IsValid)
            {
                this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);
                return View(editContactInformation);
            }

            if (!editContactInformation.PasswordConfirmation.IsNullOrWhiteSpace())
            {
                editContactInformation.Password = PasswordHash.CreateHash(editContactInformation.PasswordConfirmation);
            }
            if (editContactInformation.Password == null)
            {
                editContactInformation.Password = contact.Password;
            }

            Mapper.Map(editContactInformation, contact);

            _contactEnterpriseRepository.Update(contact);
            this.Flash(FlashMessageResources.EditSuccess, FlashEnum.Success);

            return RedirectToAction(MVC.ContactEnterprise.Index());
        }

    }
}

