using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using NSubstitute.Core;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Services;
using Stagio.Utilities.Encryption;
using Stagio.Web.Module.Strings.Email;

namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Stagio.Domain.Entities.Apply> _applyRepository;
        private readonly IMailler _mailler;
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository;
        private readonly INotificationService _notificationService;

        public StudentController(IEntityRepository<Student> studentRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IHttpContextService httpContextService, IMailler mailler, IAccountService accountService, IEntityRepository<Stagio.Domain.Entities.Notification> notificationRepository, IEntityRepository<ApplicationUser> applicationUserRepository)
        {
            _studentRepository = studentRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _applyRepository = applyRepository;
            _mailler = mailler;
            _accountService = accountService;
            _applicationUserRepository = applicationUserRepository;
            _notificationService = new NotificationService(applicationUserRepository, notificationRepository);
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult Index()
        {
            var notifications = _notificationService.GetDashboardNotificationForUser(_httpContextService.GetUserId());

            var notificationsViewModels = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(notifications).ToList();

            return View(notificationsViewModels);
        }





        

        // GET: Student/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.Student.Create createStudentViewModel)
        {

            var student = _studentRepository.GetAll().FirstOrDefault(x => x.Matricule == createStudentViewModel.Matricule);

            if (student == null)
            {
                ModelState.AddModelError("Matricule", StudentResources.MatriculeNotFound);
            }
            else
            {
                if (student.Active)
                {
                    ModelState.AddModelError("Matricule", StudentResources.MatriculeAlreadyUsed);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(createStudentViewModel);
            }



            Mapper.Map(createStudentViewModel, student);


            student.Active = true;
            student.Password = _accountService.HashPassword(createStudentViewModel.Password);
            student.UserName = createStudentViewModel.Matricule.ToString();

            _studentRepository.Update(student);
            string message = student.FirstName + " " + student.LastName + " " +
                                     StudentToCoordinator.CreateStudent;
            _notificationService.SendNotificationToAllCoordinator(
                StudentToCoordinator.CreateStudentTitle, message);
            _mailler.SendEmail(student.Email, EmailAccountCreation.Subject, EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

            return RedirectToAction(MVC.Student.CreateConfirmation());
        }

        [Authorize(Roles = RoleName.Student)]
        // GET: Student/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var userID = _httpContextService.GetUserId();

            if (id != userID)
            {
                id = userID;
            }

            var student = _studentRepository.GetById(id);

            if (student != null)
            {
                var studentEditPageViewModel = Mapper.Map<ViewModels.Student.Edit>(student);

                return View(studentEditPageViewModel);
            }
            return HttpNotFound();
        }


        [Authorize(Roles = RoleName.Student)]
        // POST: Student/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Student.Edit editStudentViewModel)
        {
            var student = _studentRepository.GetById(editStudentViewModel.Id);
            if (student == null)
            {
                return HttpNotFound();
            }

            if (!editStudentViewModel.OldPassword.IsNullOrWhiteSpace())
            {
                if (!PasswordHash.ValidatePassword(editStudentViewModel.OldPassword, student.Password))
                {
                    ModelState.AddModelError("OldPassword", StudentResources.OldPasswordInvalid);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(editStudentViewModel);
            }
            if (!editStudentViewModel.PasswordConfirmation.IsNullOrWhiteSpace())
            {
                editStudentViewModel.Password = PasswordHash.CreateHash(editStudentViewModel.PasswordConfirmation);
            }
            if (editStudentViewModel.Password == null)
            {
                editStudentViewModel.Password = student.Password;
            }
            Mapper.Map(editStudentViewModel, student);

            _studentRepository.Update(student);

            return RedirectToAction(MVC.Student.Index());
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult DisplayStageList()
        {
            var stages = _stageRepository.GetAll().ToList();
            var stagesAccepted = stages.Where(x => x.Status == StageStatus.Accepted);
            var studentStageListViewModels = Mapper.Map<IEnumerable<ViewModels.Student.StageList>>(stagesAccepted);



            return View(studentStageListViewModels);

        }


        public virtual ActionResult ApplyStage(int id)
        {
            var stage = _stageRepository.GetById(id);

            if (stage != null)
            {

                var applyViewModel = new ViewModels.Student.Apply();
                applyViewModel.IdStage = id;

                var identity = (ClaimsIdentity)User.Identity;
                var nameIdentifier = identity.FindFirst(ClaimTypes.NameIdentifier).Value;

                applyViewModel.IdStudent = Int32.Parse(nameIdentifier);
                return View(applyViewModel);
            }
            return HttpNotFound();

        }

        [HttpPost]
        public virtual ActionResult ApplyStage(IEnumerable<HttpPostedFileBase> files, ViewModels.Student.Apply applyStudentViewModel)
        {
            var stage = _stageRepository.GetById(applyStudentViewModel.IdStage);

            if (stage == null)
            {
                ViewBag.Message = StudentResources.NoFileToUpload;
                return HttpNotFound();
            }
            if (files.Any(file => file == null || (!file.FileName.Contains(".pdf") && !file.FileName.Contains(".do"))))
            {
                ViewBag.Message = "Fichier invalide, le fichier doit être un fichier Word ou PDF";
                return View(applyStudentViewModel);
            }
            var readFile = new ReadFile<String>();

            if (readFile.ReadFileCVLetter(files, Server, applyStudentViewModel.Id))
            {
                var files1 = files.ToList();
                applyStudentViewModel.Cv =   files1[0].FileName;
                applyStudentViewModel.Letter = files1[1].FileName ;
                var newApplicationStudent = Mapper.Map<Stagio.Domain.Entities.Apply>(applyStudentViewModel);
                newApplicationStudent.Status = 0;   //0 = En attente
                newApplicationStudent.DateApply = DateTime.Now;
                _applyRepository.Add(newApplicationStudent);
                int nbApplyCurrently = stage.NbApply;
                stage.NbApply = nbApplyCurrently + 1;
                _stageRepository.Update(stage);
                TempData["files"] = files;
                var student = _studentRepository.GetById(applyStudentViewModel.IdStudent);
                string messageToCoordinator = student.FirstName + " " + student.LastName + StudentToCoordinator.ApplyMessage + stage.StageTitle;
                _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.ApplyTilte, messageToCoordinator);
                string messageToContactEnterprise = student.FirstName + " " + student.LastName +
                                                    StudentToContactEnterprise.ApplyMessage + 
                                                    "<a href=" + Url.Action(MVC.ContactEnterprise.ListStudentApply(stage.Id)) + "> " +
                                                    stage.StageTitle + " </a>"; 
                _notificationService.SendNotificationToAllContactEnterpriseOf(stage.CompanyName, StudentToContactEnterprise.ApplyTitle, messageToContactEnterprise);
                return RedirectToAction(MVC.Student.ApplyConfirmation());
            }
            else
            {
               
                return View(applyStudentViewModel);
            }
        }

        public virtual ActionResult ApplyConfirmation()
        {
            try
            {
                var files = TempData["files"] as IEnumerable<HttpPostedFileBase>;
                return View(files.ToList());
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            
            
        }

        public virtual ActionResult ApplyRemoveConfirmation(int id)
        {
            var stageApply = _applyRepository.GetById(id);
            stageApply.Status = StatusApply.Removed;
            _applyRepository.Update(stageApply);
            var student = _studentRepository.GetById(stageApply.IdStudent);
            var stage = _stageRepository.GetById(stageApply.IdStage);
            _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.RemoveApplyTitle,
                String.Format(StudentToCoordinator.RemoveApplyMessage, student.FirstName + " " + student.LastName, stage.StageTitle));
            var messageTocontactEnterprise = student.FirstName + " " + student.LastName + StudentToContactEnterprise.RemoveApplyMessage + stage.StageTitle;
            _notificationService.SendNotificationToAllContactEnterpriseOf(stage.CompanyName, StudentToContactEnterprise.RemoveApplyTitle, messageTocontactEnterprise);
            return View();
        }

        public virtual ActionResult ApplyReApplyConfirmation(int id)
        {
            var stageApply = _applyRepository.GetById(id);
            stageApply.Status = StatusApply.Waitting;
            _applyRepository.Update(stageApply);
            return View();
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult ApplyList()
        {
            var appliedStages = _applyRepository.GetAll().ToList();
            var studentSpecificApplies = appliedStages.Where(x => x.IdStudent == _httpContextService.GetUserId());
            var stages = _stageRepository.GetAll().ToList();

            var studentStageListViewModels = Mapper.Map<IEnumerable<ViewModels.Student.AppliedStages>>(studentSpecificApplies).ToList();

            foreach (var appliedStage in studentStageListViewModels)
            {
                foreach (var stage in stages)
                {
                    if (appliedStage.IdStage == stage.Id)
                    {
                        appliedStage.stageTitle = stage.StageTitle;
                    }
                }

            }

            return View(studentStageListViewModels);
        }



        public virtual ActionResult CreateConfirmation()
        {
            return View();
        }


        public virtual ActionResult Download(string file)
        {
            try
            {
                string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                path = path + "\\UploadedFiles\\" + file;
                byte[] fileBytes = System.IO.File.ReadAllBytes((path));
                string fileName = file;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception)
            {
                return RedirectToAction(MVC.Student.Index());
            }
        }

        
    }
}

