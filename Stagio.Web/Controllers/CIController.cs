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
        private IDatabaseHelper _dbInit;

        public CIController(IDatabaseHelper dbInit)
        {
            _dbInit = dbInit;
        }

        public virtual ActionResult Index()
        {
            try
            {
                DeleteDb();
                SeedDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été remplie avec les données de tests </Br> <a href=\"\\\" id='go_home'>E.T téléphone maison</a> ");
        }

        public virtual ActionResult ClearDB()
        {
            try
            {
                DeleteDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été effacée.</Br> <a href=\"\\\" id='go_home'>E.T téléphone maison</a> ");
        }

        private void DeleteDb()
        {
            SqlConnection.ClearAllPools();
            _dbInit.DeleteAll();
        }

        private void SeedDb()
        {
            var studentItems = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Quentin",
                    LastName = "Tarantino"

                },
                new Student()
                {
                    
                }
            };
            /*foreach (var todoItem in studentoItems)
            {
                context.TodoItems.Add(todoItem);
            }
            context.SaveChanges();*/
            /*var testData = new DataBaseTestHelper();
            testData.SeedTables();*/
        }
    }
}