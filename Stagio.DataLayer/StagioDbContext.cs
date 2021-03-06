﻿using System.Data.Entity;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer
{
    public class StagioDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Coordinator> Coordonators { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<ContactEnterprise> Enterprises { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Apply> Applies { get; set; }
        
        public DbSet<Stage> Stages { get; set; }

        public DbSet<InvitationContactEnterprise> InvitationsContactEnterprise { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<StageAgreement> StageAgreements { get; set; }

        public DbSet<Misc> Misc { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            base.OnModelCreating(modelBuilder);
        }




    }
}