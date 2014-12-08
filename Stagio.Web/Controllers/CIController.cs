using Stagio.DataLayer;
using Stagio.TestUtilities.Database;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Stagio.Web.Controllers
{
    public partial class CIController : Controller
    {
        private IDatabaseHelper _dbHelper;

        public CIController(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public virtual ActionResult Index(bool isPresentation = false)
        {
            try
            {
                DeleteDB();
                if (isPresentation)
                {
                    SeedDbPresentation();
                }
                else
                {
                    SeedDb();
                }
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

        private void SeedDbPresentation()
        {
            var testData = new DataBaseTestHelper();
            testData.SeedPresentationTables();
        }
    }
}