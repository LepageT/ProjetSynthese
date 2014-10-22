using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.ViewModels.Student;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;
       // private readonly IEntityRepository<Activation> _activationRepository;

        public StudentController(IEntityRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

                public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult Upload()
        {
            return View();
        }        // GET: Student

        [HttpPost, ActionName("Upload")]
        public virtual ActionResult UploadPost(HttpPostedFileBase file)
        {
            var listStudentToCreate = new List<ListStudent>();

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

                listStudentToCreate = readFile.ReadFileCsv(file); 
                TempData["listStudent"] = listStudentToCreate;

                return RedirectToAction(MVC.Student.CreateList());
        }
            return View("");
        }

        public virtual ActionResult ResultCreateList()
        {
            var listStudentNotAdded = TempData["listStudentNotAdded"] as List<ListStudent>;
           
            return View(listStudentNotAdded);
        }

        [HttpPost]
        [ActionName("ResultCreateList")]
        public virtual ActionResult PostResultCreateList()
        {
            return RedirectToAction(MVC.Home.Index());
        }

        public virtual ActionResult CreateList()
        {
            var listStudentToCreate = TempData["listStudent"] as List<ListStudent>;
            TempData["listStudent"] = listStudentToCreate;
            return View(listStudentToCreate);
        }

        [HttpPost]
        [ActionName("CreateList")]

        public virtual ActionResult CreateListPost()
        {
            var listStudentNotAdded = new List<ListStudent>();
            var listOfStudentToCreate = TempData["listStudent"] as List<ListStudent>;
            var alreadyInDb = false;

            if (listOfStudentToCreate == null)
            {
                ModelState.AddModelError("Error", "Error");
            }
            else
            {
                {
                    foreach (var listStudent in listOfStudentToCreate)
                    {
                        if (Convert.ToInt32(listStudent.Matricule) < 1000000 || Convert.ToInt32(listStudent.Matricule) > 9999999)
                        {
                            ModelState.AddModelError("Error", "Matricule incorrect");
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var listStudentInDb = _studentRepository.GetAll().ToList();
                foreach (var listStudentCreate in listOfStudentToCreate)
                {
                    for (int i = 0; i < listStudentInDb.Count(); i++)
                    {
                        if (listStudentInDb[i].Matricule == listStudentCreate.Matricule)
                        {

                            listStudentNotAdded.Add(listStudentCreate);
                            alreadyInDb = true;
                        }
                    }
                    if (!alreadyInDb)
                    {
                        var studentToAdd = Mapper.Map<Student>(listStudentCreate);
                        _studentRepository.Add(studentToAdd);
                    }
                    alreadyInDb = false;
                }
                TempData["listStudentNotAdded"] = listStudentNotAdded;
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
        // GET: Student/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student != null)
            {
                var studentEditPageViewModel = Mapper.Map<ViewModels.Student.Edit>(student);

                return View(studentEditPageViewModel);
            }
            return HttpNotFound();
        }

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
    }
}
