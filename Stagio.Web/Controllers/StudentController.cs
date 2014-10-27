using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.ViewModels.Student;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Stage> _stageRepository; 
        // private readonly IEntityRepository<Activation> _activationRepository;

        public StudentController(IEntityRepository<Student> studentRepository, IEntityRepository<Stage> stageRepository)
        {
            _studentRepository = studentRepository;
            _stageRepository = stageRepository;
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

            if (!ModelState.IsValid)
            {
                return View(createStudentViewModel);
            }
           
            student.Activated = true;

            Mapper.Map(createStudentViewModel, student);

            _studentRepository.Update(student);

            return RedirectToAction(MVC.Home.Index());
        }
       
        [Authorize(Roles = RoleName.Student)]
        
        // GET: Student/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var identity = (ClaimsIdentity)User.Identity; 
            var userID = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (id != int.Parse(userID))
            {
                id = int.Parse(userID);
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

            if (!PasswordHash.ValidatePassword(editStudentViewModel.OldPassword, student.Password))
            {
                ModelState.AddModelError("OldPassword", "L'ancien mot de passe n'est pas valide.");
            }

            if (!ModelState.IsValid)
            {
                return View(editStudentViewModel);
            }
            if (editStudentViewModel.PasswordConfirmation != null)
            {
                editStudentViewModel.PasswordConfirmation = PasswordHash.CreateHash(editStudentViewModel.PasswordConfirmation);
            }

            Mapper.Map(editStudentViewModel, student);

            _studentRepository.Update(student);

            return RedirectToAction(MVC.Home.Index());
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult StageList()
        {
            var stages = _stageRepository.GetAll().ToList();
            var stagesAccepted = stages.Where(x => x.AcceptedByCoordinator == 1);
            var studentStageListViewModels = Mapper.Map<IEnumerable<ViewModels.Student.StageList>>(stagesAccepted);
          
            var identity = (ClaimsIdentity) User.Identity;
            var email = identity.FindFirst(ClaimTypes.Email).Value;
            
            return View(studentStageListViewModels);
            
        }
    }
}
