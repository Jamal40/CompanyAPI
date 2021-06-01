using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Data
{
    public class CompanyContext:DbContext
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Works_on> Works_on { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Works_on>()
                .HasKey(wo=>new { wo.EmpNo, wo.ProjectNo});
        }
    }
}
