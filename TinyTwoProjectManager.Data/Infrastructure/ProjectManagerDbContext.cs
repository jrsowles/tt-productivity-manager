﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TinyTwoProjectManager.Data.Configuration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Infrastructure
{
    public class ProjectManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectManagerDbContext() : base("name=TinyTwoProjectManager")
        {
        }

        public DbSet<ProductivityStatus> ProductivityStatuses { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskGroupDisplayOrder> TaskGroupDisplayOrders { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }

        public static ProjectManagerDbContext Create()
        {
            return new ProjectManagerDbContext();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<ApplicationUser>().ToTable("AppUser");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new SettingConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new TaskGroupConfiguration());
            modelBuilder.Configurations.Add(new TaskGroupDisplayOrderConfiguration());
            modelBuilder.Configurations.Add(new UserSettingConfiguration());
        }
    }
}