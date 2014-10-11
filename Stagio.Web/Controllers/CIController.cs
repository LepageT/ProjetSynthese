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
using Stagio.TestUtilities.Database;

namespace Stagio.Web.Controllers
{
    public partial class CIController : Controller
    {
        private IDatabaseHelper _dbHelper;

        public CIController(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public virtual ActionResult Index()
        {
            try
            {
                DeleteDB();
                SeedDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("BD remplie avec données de tests </Br> <a href=\"\\\" id='go_home'>Go home</a> ");
        }

        private void DeleteDB()
        {
            SqlConnection.ClearAllPools();
            _dbHelper.DeleteAll();
        }

        private void SeedDb()
        {
            var testData = new DataBaseTestHelper();
            testData.SeedTables();
            
            //var studentItems = new List<Student>()
            //{
            //    new Student()
            //    {
            //        Roles = new List<UserRole>()
            //                 {
            //                     new UserRole() {RoleName = RoleName.Student}
            //                 },
            //        FirstName = "Quentin",
            //        LastName = "Tarantino",
            //        Telephone = "123-456-7890",
            //        Matricule = 1234567,
            //        Password = PasswordHash.CreateHash("qwerty12")
            //    },
            //    new Student()
            //    {
            //         Roles = new List<UserRole>()
            //                 {
            //                     new UserRole() {RoleName = RoleName.Student}
            //                 },
            //        FirstName = "Christopher",
            //        LastName = "Nolan",
            //        Telephone = "123-456-7890",
            //        Matricule = 1234560,
            //        Password = PasswordHash.CreateHash("qwerty98")
            //    }
            //};
            //foreach (var studentItem in studentItems)
            //{
            //    studentItem.UserName = studentItem.Matricule.ToString();
            //    studentItem.Name = studentItem.FirstName + " " + studentItem.LastName;
            //    _studentDbContext.Students.Add(studentItem);
            //    //_accountDbContext.Users.Add(studentItem);
            //}

            //var user = new ApplicationUser()//temporary

            //{
            //    Roles = new List<UserRole>()
            //                 {
            //                     new UserRole() {RoleName = RoleName.Coordonnateur}
            //                 },
            //    Password = PasswordHash.CreateHash("test4test"),
            //    UserName = "coordonnateur@stagio.com",
            //    Name = "Super admin coordonnateur Tux"
            //};
            //_accountDbContext.Users.Add(user);//temporary
            //_studentDbContext.SaveChanges();
            //_accountDbContext.SaveChanges();

        }
    }
}