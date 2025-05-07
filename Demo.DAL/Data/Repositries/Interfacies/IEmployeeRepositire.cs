using Demo.DAL.Models;
using Demo.DAL.Models.Emp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IEmployeeRepositire : IGenericRepositry<Employee>
    {

        //hna pktet 2y hagaa leha 3laka b Employee fkt ya3ni m4 haga m4trka

        IQueryable<Employee> GetEmployeeByAddress(string address);
        //why IQueryable<Employee>?
        // beause it has filteration

        //IEnumerable<Employee> GetAllEmployee (bool withtracking = false); // implemented against the interface not concrete class
        //Employee GetEmployeeById(int id);
        //int AddEmployee(Employee Entity);     // retrun type int because it is return how many rows affected
        //int UpdateEmployee(Employee Entity);
        //int DeleteEmployee(Employee Entity);

    }
}
