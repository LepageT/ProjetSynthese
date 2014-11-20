using System;
using System.Web.Mvc;
using System.Data.SqlClient;
using Stagio.DataLayer;
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
        }
    }
}