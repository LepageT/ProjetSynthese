using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Module.Strings.Notification;
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


        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.ContactEnterprise.Create createViewModel)
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
                string message = newContactEnterprise.LastName + " " + newContactEnterprise.FirstName + " " +
                                 ContactEntrepriseToCoordinator.CreateContactEnterprise;
                _notificationService.SendNotificationToAllCoordinator(
                    ContactEntrepriseToCoordinator.CreateContactEnterpriseTitle, message);
                _mailler.SendEmail(newContactEnterprise.Email, EmailAccountCreation.Subject, EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

                //ADD NOTIFICATIONS: À la coordination et aux autres employés de l'entreprise.
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
                return View(createViewModel);
            }

            if (ModelState.IsValid)
            {
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
                        string message = contactEnterprise.LastName + " " + contactEnterprise.FirstName + " " +
                                    ContactEntrepriseToCoordinator.CreateContactEnterprise;
                        _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.CreateContactEnterpriseTitle, message);
                        _mailler.SendEmail(createViewModel.Email, EmailAccountCreation.Subject,
                            EmailAccountCreation.Message + EmailAccountCreation.EmailLink);


                        return RedirectToAction(MVC.ContactEnterprise.CreateConfirmation(contactEnterprise.Id));
                    }
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
        public virtual ActionResult CreateStage(ViewModels.Stage.Create createdStage)
        {

            if (!ModelState.IsValid)
            {
                return View(createdStage);
            }

            var stage = Mapper.Map<Stage>(createdStage);
            stage.PublicationDate = DateTime.Now.ToString();

            _stageRepository.Add(stage);
            string message = "L'entreprise " + stage.CompanyName + " a ajouté le stage " +  "<a href=" + Url.Action(MVC.Stage.Details(stage.Id)) + "> " + stage.StageTitle + " </a>" + ContactEntrepriseToCoordinator.NewStageMessage;
            _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.NewStageTitle, message);

            return RedirectToAction(MVC.ContactEnterprise.CreateStageSucceed());
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
                return View(createdInviteContactEnterpriseViewModel);
            }

            TokenGenerator tokenGenerator = new TokenGenerator();

            string token = tokenGenerator.GenerateToken();

            //Sending invitation with the Mailler class
            String messageText = EmailEnterpriseResources.InviteCoworker;
            String invitationUrl = EmailEnterpriseResources.InviteLinkCoworker + token + '"' + EmailEnterpriseResources.EndLink + token + "</a>";

            messageText += invitationUrl;

            if (createdInviteContactEnterpriseViewModel.Message != null)
            {
                messageText += EmailEnterpriseResources.MessageHeader;
                messageText += createdInviteContactEnterpriseViewModel.Message;
            }

            if (!_mailler.SendEmail(createdInviteContactEnterpriseViewModel.Email, EmailEnterpriseResources.InviteSubject, messageText))
            {
                ModelState.AddModelError("Email", EmailResources.CantSendEmail);
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

            return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
        }

        public virtual ActionResult ListStudentApply(int id)
        {

            var applies = new List<Apply>();

            try
            {
                applies = _applyRepository.GetAll().Where(x => x.IdStage == id).ToList();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            var students = _studentRepository.GetAll().ToList();

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
            var apply = new Apply();
            try
            {
                apply = _applyRepository.GetAll().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

            var applyModel = Mapper.Map<ViewModels.Apply.StudentApply>(apply);

            applyModel.FirstName = _studentRepository.GetAll().FirstOrDefault(x => x.Id == apply.IdStudent).FirstName;
            applyModel.LastName = _studentRepository.GetAll().FirstOrDefault(x => x.Id == apply.IdStudent).LastName;
            applyModel.StageTitle = _stageRepository.GetAll().FirstOrDefault(x => x.Id == apply.IdStage).StageTitle;
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
            if (command.Equals("Je suis intéressé"))
            {
                apply.Status = StatusApply.Accepted;
                _applyRepository.Update(apply);
                var acceptApply =
                    Mapper.Map<ViewModels.ContactEnterprise.AcceptApply>(_studentRepository.GetById(apply.IdStudent));
                string message = stage.CompanyName + " " + ContactEntrepriseToCoordinator.InterestedBy + " " + student.LastName + " " + student.FirstName;
                _notificationService.SendNotificationToAllCoordinator(
                    ContactEntrepriseToCoordinator.InterestedByTitle, message);
                return View(MVC.ContactEnterprise.Views.ViewNames.AcceptApplyConfirmation, acceptApply);
            }
            else if (command.Equals("Je ne suis pas intéressé"))
            {
                apply.Status = StatusApply.Refused;
                _applyRepository.Update(apply);
                string message = stage.CompanyName + " " + ContactEntrepriseToCoordinator.NotInterestedBy + " " + student.LastName + " " + student.FirstName;
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
            var stage = _stageRepository.GetById(idStage);
            var applies = _applyRepository.GetAll().ToList().Where(x => x.IdStage == idStage);
            if (stage == null)
            {
                return HttpNotFound();
            }

            string message = stage.CompanyName + " " + ContactEntrepriseToCoordinator.RemoveStage + " " + "<a href=" + Url.Action(MVC.Stage.Details(idStage)) + "> " + stage.StageTitle + " </a>";
            _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.RemoveStageTitle, message);

            message = stage.CompanyName + " " + ContactEntrepriseToCoordinator.RemoveStage + " " + stage.StageTitle ;
            _notificationService.SendNotificationToAllStudent(ContactEntrepriseToCoordinator.RemoveStageTitle, message);



            stage.Status = StageStatus.Removed;
            _stageRepository.Update(stage);

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
            return View();
        }

    }
}

