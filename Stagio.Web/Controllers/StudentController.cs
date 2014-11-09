using System;
using System.Collections;
using System.Collections.Generic;
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
using Stagio.Web.Services;
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
        private readonly IMailler _mailler;
        private readonly IAccountService _accountService;

        public StudentController(IEntityRepository<Student> studentRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IHttpContextService httpContextService, IMailler mailler, IAccountService accountService)
        {
            _studentRepository = studentRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _applyRepository = applyRepository;
            _mailler = mailler;
            _accountService = accountService;
        }

        public virtual ActionResult Index()
        {
            return View(MVC.Student.Views.ViewNames.Index);
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
                ModelState.AddModelError("Fichier", "Il n'y a pas de fichier à importer");
                ViewBag.Message = "Il n'y a pas de fichier à importer";
            }
            else
            {
                {
                    if (!file.FileName.Contains(".csv"))
                    {
                        ModelState.AddModelError("Fichier", "Il n'y a pas de fichier à importer");
                        ViewBag.Message = "Ce n'est pas un fichier csv";
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
                ModelState.AddModelError("Matricule", "Votre matricule ne figure pas dans la liste des matricules autorisés.");
            }
            else
            {
                if (student.Active)
                {
                    ModelState.AddModelError("Matricule", "Votre matricule est déja utilisé.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(createStudentViewModel);
            }
           
         

            Mapper.Map(createStudentViewModel, student);

 
            student.Active = true;
            student.Password = _accountService.HashPassword(createStudentViewModel.Password);


            _studentRepository.Update(student);

            _mailler.SendEmail(student.Email, EmailAccountCreation.Subject, EmailAccountCreation.Message + EmailAccountCreation.EmailLink);

            return RedirectToAction(MVC.Home.Index());
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
                ModelState.AddModelError("OldPassword", "L'ancien mot de passe n'est pas valide.");
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
            var stagesAccepted = stages.Where(x => x.Status == 1);
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
        public virtual ActionResult Apply(ViewModels.Student.Apply applyStudentViewModel)
        {
            var stage = _stageRepository.GetById(applyStudentViewModel.IdStage);

            if (stage == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(applyStudentViewModel);
            }
            var newApplicationStudent = Mapper.Map<Stagio.Domain.Entities.Apply>(applyStudentViewModel);
            newApplicationStudent.Status = 0;   //0 = En attente
            _applyRepository.Add(newApplicationStudent);
            int nbApplyCurrently = stage.NbApply;
            stage.NbApply = nbApplyCurrently + 1;
            _stageRepository.Update(stage);

            return RedirectToAction(MVC.Student.ApplyConfirmation());
        }

        public virtual ActionResult ApplyConfirmation()
        {
            return View();
        }

        public virtual ActionResult ApplyRemoveConfirmation(int id)
        {
            var stageApply = _applyRepository.GetById(id);
            stageApply.Status = 3;
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
                    apply.StudentReply = 1;
                }
                else
                {
                    apply.StudentReply = 2;
                }
                _applyRepository.Update(apply);

                return RedirectToAction(MVC.Student.ApplyList());
            }

            return HttpNotFound();
        }
    }
}

