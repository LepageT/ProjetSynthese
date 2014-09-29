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


        private void SeedDb()
        {
            var studentItems = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Telephone = 1234567890,
                    Matricule = 1234567,
                    Password = "qwerty12"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Telephone = 1234567890,
                    Matricule = 1234560,
                    Password = "qwerty98"
                }
            };
            foreach (var studentItem in studentItems)
            {
                _studentDbContext.Students.Add(studentItem);
            }
            _studentDbContext.SaveChanges();

        }
    }
}