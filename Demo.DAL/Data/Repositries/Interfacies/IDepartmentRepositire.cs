using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IDepartmentRepositire
    {
        //signature of the methods

        //Get all departments
        IEnumerable<Department> GetAllDepartments(bool withtracking);
        //Get by id
        Department GetDepartmentById(int id);
        //Add
        int Add(Department Entity);     // retrun type int because it is return how many rows affected
        //Update
        int Update(Department Entity);
        //Delete
        int Delete(Department Entity);
    }
}
