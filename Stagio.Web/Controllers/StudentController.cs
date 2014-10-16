using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Student;


namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;


        public StudentController(IEntityRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public virtual ActionResult Upload()
        {
            return View();
        }

        [HttpPost, ActionName("Upload")]
        public virtual ActionResult UploadPost(HttpPostedFileBase file)
        {
            var listStudentToCreate = new List<Student>();

            if (file == null)
            {
                ModelState.AddModelError("Fichier", "Il n'y a pas de fichier à importer");
                ViewBag.Message = "Il n'y a pas de fichier à importer";
            }
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/UploadedFiles"), fileName);
                    file.SaveAs(path);

                    using (var rd = new StreamReader(path))
                    {
                        rd.ReadLine().Split(',');
                        while (!rd.EndOfStream)
                        {
                            var splits = rd.ReadLine().Split(',');
                            var createStudent = new Student();

                            createStudent.Matricule = Convert.ToInt32(splits[0]);
                            createStudent.LastName = splits[1];
                            createStudent.FirstName = splits[2];

                            createStudent.LastName = createStudent.LastName.Replace('"', ' ');
                            createStudent.FirstName = createStudent.FirstName.Replace('"', ' ');
                            listStudentToCreate.Add(createStudent);
                            ViewBag.Message = "Le fichier a été importé avec succès";
                        }
                    }
                }

                TempData["list"] = listStudentToCreate;
                return RedirectToAction(MVC.Student.CreateList());
            }
            return View("");
        }

        public virtual ActionResult ResultCreateList()
        {
            var listStudentNotAdded = TempData["listStudentNotAdded"] as List<Student>;
           
            return View(listStudentNotAdded);
        }

        [HttpPost]
        [ActionName("ResultCreateList")]
        public virtual ActionResult PostResultCreateList()
        {
            return RedirectToAction(MVC.Home.Index());
        }
       
        // GET: Student/Create
        
        public virtual ActionResult CreateList()
        {
            var listStudentToCreate = TempData["listStudent"] as List<Student>;
            TempData["listStudent"] = listStudentToCreate;
            return View(listStudentToCreate);
        }


        // POST: Student/Create
     
        [HttpPost]
        [ActionName("CreateList")]
       
        public virtual ActionResult CreateListPost()
        {
            var listStudentNotAdded = new List<Student>();
            var listOfStudentToCreate = new List<Student>();
            listOfStudentToCreate = TempData["listStudent"] as List<Student>;
            var alreadyInDb = false;

            if (listOfStudentToCreate == null)
            {
                ModelState.AddModelError("Error", "Error");
            }
            if (ModelState.IsValid)
            {
                var student = _studentRepository.GetAll().ToList();
                foreach (var studentCreate in listOfStudentToCreate)
                {
                    for (int i = 0; i < student.Count(); i++)
                    {
                        if (student[i].Matricule == studentCreate.Matricule)
                        {
                            listStudentNotAdded.Add(studentCreate);
                            alreadyInDb = true;
                        }
                    }
                    if (!alreadyInDb)
                    {
                        _studentRepository.Add(studentCreate);
                    }
                    alreadyInDb = false;
                }
                TempData["listStudentNotAdded"] = listStudentNotAdded;
                return RedirectToAction(MVC.Student.ResultCreateList());
            }

            return RedirectToAction("");
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
            
            if (editStudentViewModel.OldPassword != student.Password)
            {
                ModelState.AddModelError("OldPassword", "L'ancien mot de passe n'est pas valide.");
            }
            
            if (!ModelState.IsValid)
            {
                return View(editStudentViewModel);
            }

            Mapper.Map(editStudentViewModel, student);

            _studentRepository.Update(student);

            return RedirectToAction(MVC.Home.Index());

        }

       
    }
}
