using AutoMapper;
using Demo.BLL.Dto.EmployeeDto;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models.Emp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Clases
{
    public class EmployeeService(IEmployeeRepositire _employeeRepositire , IMapper _mapper)   : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking)
        {
            var employees = _employeeRepositire.GetAll(withTracking);
            var ReturnedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees); // AutoMapper will map the properties of Employee to EmployeeDto
            //var ReturnedEmployees = employees.Select(emp => new EmployeeDto
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    Salary = emp.Salary,
            //    Email = emp.Email,
            //    IsActive = emp.IsActive,
            //    EmployeeType = emp.EmployeeType.ToString(),
            //    Gender = emp.Gender.ToString()
            //});
            return ReturnedEmployees;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _employeeRepositire.GetById(id);
            //if (employee == null)
            //{
            //    return null; // or throw an exception
            //}
            //else
            //{
                //var ReturnedEmployee = new EmployeeDetailsDto()
                //{
                //    Id = employee.Id,
                //    Name = employee.Name,
                //    Age = employee.Age,
                //    Salary = employee.Salary,
                //    Address = employee.Address,
                //    IsActive = employee.IsActive,
                //    Email = employee.Email,
                //    PhoneNumber = employee.PhoneNumber,
                //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                //    CreatedBy = 1,
                //    CreatedOn = DateTime.Now,
                //    LastModifiedBy = 1
                //};
                //return ReturnedEmployee;\
            //}

            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }
        public int CreateEmployee(CreatedEmpDto CreatedempDto)
        {

            var employee = _mapper.Map<CreatedEmpDto, Employee>(CreatedempDto);
            return _employeeRepositire.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepositire.GetById(id);
            if (employee == null)
            {
                return false;
            }
            else
            {
                employee.IsDeleted = true;
                return _employeeRepositire.Update(employee) > 0 ? true : false;
            }
        }


        public int UpdateEmployee(UpdatedEmployeeDto updatedEmpeDto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(updatedEmpeDto);
            return _employeeRepositire.Update(employee);
        }
    }

}
