using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Controllers
{
    public partial class CIController : Controller
    {
        private StagioDbContext _studentDbContext;

        public CIController()
        {
            _studentDbContext = new StagioDbContext();
        }

        public virtual ActionResult Index()
        {
            try
            {
                _studentDbContext.Database.Delete();
                _studentDbContext.Database.CreateIfNotExists();
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
                    Id = 1,
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = "123-456-7890",
                    Matricule = 1234567,
                    Password = "qwerty12"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7890",
                    Matricule = 1234560,
                    Password = "qwerty98"
                }
            };
            foreach (var studentItem in studentItems)
            {
                _studentDbContext.Students.Add(studentItem);
            }


            var enterpriseItems = new List<Enterprise>()
            {
                new Enterprise()
                {
                    Id = 1,
                    EnterpriseName = "test",
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = "123-456-7890",
                    Email = "blabla@hotmail.com",
                    Password = "qwerty12"
                },
                new Enterprise()
                {
                    Id = 2,
                    EnterpriseName = "Stagio",
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = "123-456-7890",
                    Email = "toto@hotmail.com",
                    Password = "qwerty98"
                }
            };
            foreach (var enterpriseItem in enterpriseItems)
            {
                _studentDbContext.Enterprises.Add(enterpriseItem);
            }

            _studentDbContext.SaveChanges();

        }
    }
}