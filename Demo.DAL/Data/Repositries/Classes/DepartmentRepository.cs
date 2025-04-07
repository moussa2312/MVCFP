using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepositire
    {
        private readonly AppDbContext _dbcontext = dbContext; // Create an instance of the DbContext to connect to the database

        public int Add(Department Entity)
        {
            _dbcontext.Departments.Add(Entity); // Add the entity to the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }

        public int Delete(Department Entity)
        {
            _dbcontext.Departments.Remove(Entity); // Remove the entity from the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }

        public IEnumerable<Department> GetAllDepartments(bool withtracking = false)
        {
            if (withtracking)
                return _dbcontext.Departments.ToList();
            else 
                return _dbcontext.Departments.AsNoTracking().ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _dbcontext.Departments.Find(id); // Find the department by ID
           //find<Department>(id)
        }

        public int Update(Department Entity)
        {
            _dbcontext.Departments.Update(Entity); // Update the entity in the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }

        public void test()
        {
            GetAllDepartments();
        }
    }
}
