using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Apply;
using Stagio.Web.ViewModels.Student;
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
        private readonly IEntityRepository<Stagio.Domain.Entities.Notification> _notificationRepository;
        private readonly IMailler _mailler;
        private readonly IAccountService _accountService;

        public StudentController(IEntityRepository<Student> studentRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IHttpContextService httpContextService, IMailler mailler, IAccountService accountService, IEntityRepository<Stagio.Domain.Entities.Notification> notificationRepository)
        {
            _studentRepository = studentRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _applyRepository = applyRepository;
            _mailler = mailler;
            _accountService = accountService;
            _notificationRepository = notificationRepository;
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult Index()
        {
            var notifications = _notificationRepository.GetAll().ToList();
            var userNotifications = notifications.Where(x => x.For == _httpContextService.GetUserId());

            var notificationsViewModels = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(userNotifications).ToList();

            return View(notificationsViewModels);
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult ConfirmationUploadCVLetter()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult UploadCVLetter()
        {
            return View();
        }


        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult Upload()
        {
            return View();
        }


        [Authorize(Roles = RoleName.Student)]
        [HttpPost]
        public virtual ActionResult UploadCVLetter(IEnumerable<HttpPostedFileBase> files)
        {
            var readFile = new ReadFile<String>();
            
            if (ModelState.IsValid)
            {
                if (readFile.ReadFileCVLetter(files, Server, 1))
                {
                    return RedirectToAction(MVC.Student.ConfirmationUploadCVLetter());
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
      
     
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

                return RedirectToAction(MVC.Student.CreateList());
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
                return RedirectToAction(MVC.Student.ResultCreateList());
            }

            return RedirectToAction(MVC.Student.Upload());
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
        public virtual ActionResult StageList()
        {
            var stages = _stageRepository.GetAll().ToList();
            var stagesAccepted = stages.Where(x => x.Status == StageStatus.Accepted);
            var studentStageListViewModels = Mapper.Map<IEnumerable<ViewModels.Student.StageList>>(stagesAccepted);
          
            
            
            return View(studentStageListViewModels);
            
        }


        public virtual ActionResult Apply(int id)
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
        public virtual ActionResult Apply(IEnumerable<HttpPostedFileBase> files, ViewModels.Student.Apply applyStudentViewModel)
        {
            var stage = _stageRepository.GetById(applyStudentViewModel.IdStage);

            if (stage == null)
            {
                return HttpNotFound();
            }

            var readFile = new ReadFile<String>();


            if (readFile.ReadFileCVLetter(files, Server, applyStudentViewModel.Id))
            {
                var files1 = files.ToList();
                applyStudentViewModel.Cv = files1[0].FileName + "ApplyCV" + applyStudentViewModel.Id;
                applyStudentViewModel.Letter = files1[1].FileName + "ApplyLetter" + applyStudentViewModel.Id;
            var newApplicationStudent = Mapper.Map<Stagio.Domain.Entities.Apply>(applyStudentViewModel);
            newApplicationStudent.Status = 0;   //0 = En attente
            newApplicationStudent.DateApply = DateTime.Now;
            _applyRepository.Add(newApplicationStudent);
            int nbApplyCurrently = stage.NbApply;
            stage.NbApply = nbApplyCurrently + 1;
            _stageRepository.Update(stage);

            return RedirectToAction(MVC.Student.ApplyConfirmation());
        }
            else
            {
                return View(applyStudentViewModel);
            }
        }

        public virtual ActionResult ApplyConfirmation()
        {
            return View();
        }

        public virtual ActionResult ApplyRemoveConfirmation(int id)
        {
            var stageApply = _applyRepository.GetById(id);
            stageApply.Status = StatusApply.Removed;
            _applyRepository.Update(stageApply);
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

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult ReplyStage(int idApply)
        {
            var apply = _applyRepository.GetById(idApply);
            if (apply != null)
            {
                var stage = _stageRepository.GetById(apply.IdStage);
                var stageViewModel = Mapper.Map<ViewModels.Student.AppliedStages>(stage);
                return View(stageViewModel);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = RoleName.Student)]
        [HttpPost]
        public virtual ActionResult ReplyStage(int idApply, string command)
        {
            var apply = _applyRepository.GetById(idApply);

            if (apply != null)
            {
                if (command.Equals("Accepter"))
                {
                    apply.StudentReply = StatusApply.Accepted;
                }
                else
                {
                    apply.StudentReply = StatusApply.Refused;
                }
                _applyRepository.Update(apply);

                return RedirectToAction(MVC.Student.ApplyList());
            }

            return HttpNotFound();
        }

        public virtual ActionResult CreateConfirmation()
        {
            return View();
        }
    }
}

