using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;


namespace Stagio.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;


        public StudentController(IEntityRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }


        // GET: Student
        public virtual ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        public virtual ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file)
        {
            var listStudentToCreate = new List<Student>();
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


                            listStudentToCreate.Add(createStudent);
                        }
                    }
                }
                return RedirectToAction(MVC.Student.CreateListGet(listStudentToCreate));
            }
            return View("");
        }

        // GET: Student/Create
        [HttpGet, ActionName("CreateList")]
        public virtual ActionResult CreateListGet(List<Student> listOfStudentToCreate)
        {
            return View(listOfStudentToCreate);
        }


        // POST: Student/Create
        [HttpPost, ActionName("CreateList")]
        public virtual ActionResult CreateListPost(List<Student> listOfStudentToCreate)
        {
            if (ModelState.IsValid)
            {
                foreach (var studentCreate in listOfStudentToCreate)
                {
                    //var student = Mapper.Map<Student>(studentCreate);
                    _studentRepository.Add(studentCreate);
                }
                return RedirectToAction(MVC.Home.Index());
            }
            return View("");
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

        // GET: Student/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
