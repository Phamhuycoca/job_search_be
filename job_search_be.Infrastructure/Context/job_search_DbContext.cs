using job_search_be.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Infrastructure.Context
{
    public class job_search_DbContext:DbContext
    {
        public job_search_DbContext(DbContextOptions<job_search_DbContext> options) : base(options) { }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Refresh_Token> RefreshTokens { get; set; }
        public virtual DbSet<Formofwork> Formofworks { get; set; }
        public virtual DbSet<Workexperience> Workexperiences { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Employers> Employers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Permission>(e =>
            {
                e.ToTable("Permissions");
                e.HasKey(e => e.PermissionId);
            });
            modelBuilder.Entity<Role>(e =>{
                e.ToTable("Roles");
                e.HasKey(e => e.RoleId);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(e => e.UserId);
                e.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Refresh_Token>(e =>
            {
                e.ToTable("RefreshTokens");
                e.HasKey(e => e.UserId);
                e.HasOne(e => e.User).WithMany(e => e.Refresh_Tokens).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Formofwork>(e =>
            {
                e.ToTable("Formofworks");
                e.HasKey(e => e.FormofworkId);
            });
            modelBuilder.Entity<Workexperience>(e =>
            {
                e.ToTable("Workexperiences");
                e.HasKey(e => e.WorkexperienceId);
            });
            modelBuilder.Entity<Salary>(e =>
            {
                e.ToTable("Salaries");
                e.HasKey(e => e.SalaryId);
            });
            modelBuilder.Entity<Employers>(e =>
            {
                e.ToTable("Employers");
                e.HasKey(e => e.EmployersId);
                e.HasOne(e=>e.City).WithMany(e=>e.Employers).HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<City>(e =>
            {
                e.ToTable("Cities");
                e.HasKey(e => e.CityId);
            });
            modelBuilder.Entity<Job>(e =>
            {
                e.ToTable("Jobs");
                e.HasKey(e => e.JobId);
                e.HasOne(e => e.Workexperience).WithMany(e => e.Jobs).HasForeignKey(e => e.WorkexperienceId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e=>e.Salary).WithMany(e=> e.Jobs).HasForeignKey(e=>e.SalaryId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.City).WithMany(e => e.Jobs).HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Formofwork).WithMany(e => e.Jobs).HasForeignKey(e => e.FormofworkId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Employers).WithMany(e => e.Jobs).HasForeignKey(e => e.EmployersId).OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
