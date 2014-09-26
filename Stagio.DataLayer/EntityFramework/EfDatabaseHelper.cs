using System.Data.Entity;
using System.Data.SqlClient;

namespace Stagio.DataLayer.EntityFramework
{
    public class EfDatabaseHelper : IDatabaseHelper
    {

        
        public void DropCreateDatabaseIfModelChanges()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseIfModelChanges<StagioDbContext>();
            Database.SetInitializer(initializer); 
            
        }


        public void DeleteAll()
        {
            var context = new StagioDbContext();
            context.Database.Initialize(false);
            context.Database.Delete();
            context.Database.CreateIfNotExists();
            context.SaveChanges();
        }
    }
}

