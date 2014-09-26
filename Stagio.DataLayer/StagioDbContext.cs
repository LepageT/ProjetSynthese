using System.Data.Entity;

namespace Stagio.DataLayer
{
    public class StagioDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            base.OnModelCreating(modelBuilder);
        }

    }
}