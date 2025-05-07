using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IDepartmentRepositire : IGenericRepositry<Department>
    {

        //signature of the methods

        //Get all departments
        // why IEnumerable<Department>?
        // because it is a collection of Department objects
        // why withtracking = false?
        // because it is a default value for the parameter
        //IEnumerable<Department> GetAll(bool withtracking = false); // implemented against the interface not concrete class
        ////Get by id
        //Department GetDepartmentById(int id);
        ////Add
        //int Add(Department Entity);     // retrun type int because it is return how many rows affected
        ////Update
        //int Update(Department Entity);
        ////Delete
        //int Delete(Department Entity);
    }
}
