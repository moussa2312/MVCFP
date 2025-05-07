using Demo.DAL.Models;
using Demo.DAL.Models.Emp_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=MVCFP;Trusted_Connection=true;"); //connection string

        //}

        //any fluent API configuration run in this method (On ModelCreating)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new Configerations.DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Apply all configurations in the assembly
        }
        public DbSet<Department> Departments { get; set; } // Table name is Departments in the database
        public DbSet<Employee> Employees { get; set; } // Table name is Employees in the database
    }
}
