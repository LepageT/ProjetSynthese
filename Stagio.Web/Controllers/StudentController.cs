using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
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
