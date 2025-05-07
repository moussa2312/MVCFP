using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Demo.DAL.Models.Emp_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class EmployeeRepository(AppDbContext dbContext) : GenericRepositry<Employee>(dbContext), IEmployeeRepositire
    {
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
