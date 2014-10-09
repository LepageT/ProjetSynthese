using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.Controllers
{
    public partial class CIController : Controller
    {
        private StagioDbContext _studentDbContext;
        private StagioDbContext _accountDbContext;

        public CIController()
        {
            _studentDbContext = new StagioDbContext();
            _accountDbContext = new StagioDbContext();
        }

        public virtual ActionResult Index()
        {
            try
            {
                _studentDbContext.Database.Delete();
                _studentDbContext.Database.CreateIfNotExists();
                _accountDbContext.Database.Delete();
                _accountDbContext.Database.CreateIfNotExists();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            SeedDb();
            return Content("BD remplie avec données de tests </Br> <a href=\"\\\" id='go_home'>Go home</a> ");
        }

        private void SeedDb()
        {
            var studentItems = new List<Student>()
            {
                new Student()
                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Student}
                             },
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = "123-456-7890",
                    Matricule = 1234567,
                    Password = PasswordHash.CreateHash("qwerty12")
                },
                new Student()
                {
                     Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Student}
                             },
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7890",
                    Matricule = 1234560,
                    Password = PasswordHash.CreateHash("qwerty98"),
                }
            };
            foreach (var studentItem in studentItems)
            {
                studentItem.UserName = studentItem.Matricule.ToString();
                studentItem.Name = studentItem.FirstName + " " + studentItem.LastName;
                _studentDbContext.Students.Add(studentItem);
                //_accountDbContext.Users.Add(studentItem);
            }

            var user = new ApplicationUser()

            {
                Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Coordonnateur}
                             },
                Password = PasswordHash.CreateHash("test4test"),
                UserName = "coordonnateur",
                Name = "Super admin coordonnateur Tux"
            };
            _accountDbContext.Users.Add(user);
            _studentDbContext.SaveChanges();
            _accountDbContext.SaveChanges();

        }
    }
}