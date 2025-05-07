using Demo.BLL.Dto.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeServices
    {
        //Get all employees
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);
        //Get employee by id
        EmployeeDetailsDto?  GetEmployeeById(int id);

        //Add new employee
        int CreateEmployee(CreatedEmpDto CreatedempDto);

        //Update employee
        int UpdateEmployee(UpdatedEmployeeDto updatedEmpeDto);

        //Delete employee
        bool DeleteEmployee(int id);
    }
}
