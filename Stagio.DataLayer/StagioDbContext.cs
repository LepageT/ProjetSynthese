using System.Data.Entity;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer
{
    public class StagioDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Coordonnateur> Coordonators { get; set; }
        public DbSet<Invitation> Invitations { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            base.OnModelCreating(modelBuilder);
        }


    }
}