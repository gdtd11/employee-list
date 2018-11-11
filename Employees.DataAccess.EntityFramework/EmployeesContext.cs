using Employees.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DataAccess.EntityFramework
{

    public class EmployeesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.CreationDate).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.EmploymentDate).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Rate).IsRequired();

            modelBuilder.Entity<Job>().Property(t => t.Title).IsRequired();

            modelBuilder.Entity<EmployeeJob>().HasKey(x =>
                new { x.EmployeeId, x.JobId });

            modelBuilder.Entity<Job>().HasData(
                new Job { Id = 1, Title = "Founder"},
                new Job { Id = 2, Title = "CEO" },
                new Job { Id = 3, Title = "Develper" });
        }
    }
}
