using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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
using Stagio.Web.ViewModels.Student;
using Apply = Stagio.Domain.Entities.Apply;

namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<ContactEnterprise> _enterpriseContactRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Invitation> _invitationRepository;
        private readonly IEntityRepository<InvitationContactEnterprise> _invitationContactRepository;

        private readonly IMailler _mailler;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Interview> _interviewRepository;
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly INotificationService _notificationService;
        private readonly IEntityRepository<ApplicationUser> _applicationRepository; 

        public CoordinatorController(IEntityRepository<ContactEnterprise> enterpriseContactRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Invitation> invitationRepository,
            IMailler mailler,
            IAccountService accountService,
            IEntityRepository<InvitationContactEnterprise> invitationContactRepository,
            IEntityRepository<Apply> applyRepository,
            IEntityRepository<Stage> stageRepository,
            IEntityRepository<Student> studentRepository,
            IEntityRepository<Interview> interviewRepository,
            IEntityRepository<Notification> notificationRepository,
            IHttpContextService httpContextService,
            IEntityRepository<ApplicationUser> applicationRepository )
        {
            _enterpriseContactRepository = enterpriseContactRepository;
            _coordinatorRepository = coordinatorRepository;
            _invitationRepository = invitationRepository;
            _mailler = mailler;
            _accountService = accountService;
            _invitationContactRepository = invitationContactRepository;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _studentRepository = studentRepository;
            _interviewRepository = interviewRepository;
            _notificationRepository = notificationRepository;
            _httpContextService = httpContextService;
            _applicationRepository = applicationRepository;
            _notificationService = new NotificationService(_applicationRepository, notificationRepository);

        }
        // GET: Coordinator
        public virtual ActionResult Index()
        {
            var notifications = _notificationService.GetDashboardNotificationForUser(_httpContextService.GetUserId());

            var notificationsViewModels = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(notifications).ToList();

            return View(notificationsViewModels);
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
                TokenGenerator tokenGenerator = new TokenGenerator();

                foreach (int id in selectedIdContactEnterprise)
                {

                    string token = tokenGenerator.GenerateToken();

                    ContactEnterprise contactEnterpriseToSendMessage = _enterpriseContactRepository.GetById(id);

                    if (!ModelState.IsValid)
                    {
                        return View(InviteContactEnterprise());
                    }

                    String messageText = EmailEnterpriseResources.InviteMessageBody;
                    String invitationUrl = EmailEnterpriseResources.InviteLink + token + EmailEnterpriseResources.EndLink + token + "</a>";

                    messageText += invitationUrl;


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

                    _invitationContactRepository.Add(new InvitationContactEnterprise()
                    {
                        Token = token,
                        Email = contactEnterpriseToSendMessage.Email,
                        FirstName = contactEnterpriseToSendMessage.FirstName,
                        LastName = contactEnterpriseToSendMessage.LastName,
                        EnterpriseName = contactEnterpriseToSendMessage.EnterpriseName,
                        Telephone = contactEnterpriseToSendMessage.Telephone,
                        Poste = contactEnterpriseToSendMessage.Poste,
                        Used = false
                    });



            }
                return RedirectToAction(MVC.Coordinator.InviteContactEnterpriseConfirmation());
            }

            return RedirectToAction(MVC.Coordinator.InviteContactEnterprise());

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

            TokenGenerator tokenGenerator = new TokenGenerator();

            string token = tokenGenerator.GenerateToken();

            //Sending invitation with the Mailler class
            String messageText = EmailCoordinatorResources.CoordinatorInviteMessageBody;
            String invitationUrl = EmailCoordinatorResources.CoordinatorInviteLink + token + "\">jenkins.cegep-ste-foy.qc.ca/thomarelau/Coordinator/Create?token=" + token + "</a>";

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


            int nbAppliesStudent = 0;

            var appliedStages = _applyRepository.GetAll().ToList();

            foreach (var student in studentListViewModels)
            {
                var studentSpecificApplies = appliedStages.Where(x => x.IdStudent == student.Id).ToList();
                foreach (var apply in studentSpecificApplies)
                {
                    nbAppliesStudent = nbAppliesStudent + 1;
                }
                student.NbApply = nbAppliesStudent;
                nbAppliesStudent = 0;
            }


            int nbDateInterview = 0;

            var interviewsStudent = _interviewRepository.GetAll().ToList();

            foreach (var student in studentListViewModels)
            {
                var interviewsSpecificStudent = interviewsStudent.Where(x => x.StudentId == student.Id).ToList();
                foreach (var interview in interviewsSpecificStudent)
                {
                    nbDateInterview = nbDateInterview + 1;
                }
                student.NbDateInterview = nbDateInterview;
                nbDateInterview = 0;
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
                    if (appliedStage.IdStudent == student.Id)
                    {
                        appliedStage.FirstName = student.FirstName;
                        appliedStage.LastName = student.LastName;
                        appliedStage.Matricule = student.Matricule;
                    }
                }
                foreach (var interview in interviews)
                {
                    if (appliedStage.IdStudent == interview.StudentId)
                    {
                        appliedStage.DateInterview = interview.Date;

                    }
                }
            }

            

            return View(studentListApplyViewModels);
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult Upload()
        {
            return View();
        }


        [Authorize(Roles = RoleName.Coordinator)]
        [HttpPost, ActionName("Upload")]
        public virtual ActionResult UploadPost(HttpPostedFileBase file)
        {
            var listStudents = new List<ListStudent>();

            if (file == null)
            {
                ModelState.AddModelError("Fichier", StudentResources.NoFileToUpload);
                ViewBag.Message = StudentResources.NoFileToUpload;
            }
            else
            {
                {
                    if (!file.FileName.Contains(".csv"))
                    {
                        ModelState.AddModelError("Fichier", StudentResources.NoFileToUpload);
                        ViewBag.Message = StudentResources.WrongFileType;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var readFile = new ReadFile<ListStudent>();

                listStudents = readFile.ReadFileCsv(file);
                TempData["listStudent"] = listStudents;

                return RedirectToAction(MVC.Coordinator.CreateList());
            }
            return View("");
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult ResultCreateList()
        {
            var resultCreateList = new ResultCreateList();
            resultCreateList.ListStudentAdded = TempData["listStudentAdded"] as List<ListStudent>;
            resultCreateList.ListStudentNotAdded = TempData["listStudentNotAdded"] as List<ListStudent>;

            return View(resultCreateList);
        }

        [Authorize(Roles = RoleName.Coordinator)]
        [HttpPost]
        [ActionName("ResultCreateList")]
        public virtual ActionResult PostResultCreateList()
        {
            return RedirectToAction(MVC.Home.Index());
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult CreateList()
        {
            var listStudents = TempData["listStudent"] as List<ListStudent>;
            TempData["listStudent"] = listStudents;
            return View(listStudents);
        }

        [Authorize(Roles = RoleName.Coordinator)]
        [HttpPost]
        [ActionName("CreateList")]

        public virtual ActionResult CreateListPost()
        {
            var listStudentNotAdded = new List<ListStudent>();
            var listStudentAdded = new List<ListStudent>();
            var listStudentInDb = _studentRepository.GetAll().ToList();
            var listStudents = TempData["listStudent"] as List<ListStudent>;
            var alreadyInDb = false;

            if (listStudents == null)
            {
                ModelState.AddModelError("Error", "Error");
            }

            if (ModelState.IsValid)
            {
                foreach (var listStudentCreate in listStudents)
                {
                    for (int i = 0; i < listStudentInDb.Count(); i++)
                    {
                        if (!alreadyInDb)
                        {
                            if (listStudentInDb[i].Matricule == listStudentCreate.Matricule)
                            {

                                listStudentNotAdded.Add(listStudentCreate);
                                alreadyInDb = true;
                            }

                        }
                    }
                    if (Convert.ToInt32(listStudentCreate.Matricule) < 1000000 || Convert.ToInt32(listStudentCreate.Matricule) > 9999999)
                    {
                        listStudentNotAdded.Add(listStudentCreate);
                        alreadyInDb = true;
                    }
                    if (!alreadyInDb)
                    {

                        var student = Mapper.Map<Student>(listStudentCreate);
                        listStudentAdded = listStudents;
                        _studentRepository.Add(student);
                    }
                    alreadyInDb = false;
                }

                TempData["listStudentNotAdded"] = listStudentNotAdded;
                TempData["listStudentAdded"] = listStudentAdded;
                return RedirectToAction(MVC.Coordinator.ResultCreateList());
            }

            return RedirectToAction(MVC.Coordinator.Upload());
        }

    }
}
