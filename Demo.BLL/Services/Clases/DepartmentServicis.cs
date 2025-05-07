using Demo.BLL.DTO;
using Demo.BLL.Factoris;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositries.Classes;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Clases
{
    public class DepartmentServices(IDepartmentRepositire _departmentRepository) : IDepartmentServices
    {
        // private readonly IDepartmentRepositire _departmentRepository = departmentRepository;
        //GetAllDepartments

        public IEnumerable<DepartmentDTO> GetAllDepartment()
        {
            var departments = _departmentRepository.GetAll();

            //Manual mapping
            //var departmentsToReturn = departments.Select(D => new DepartmentDTO
            //{
            //    ID = D.Id,
            //    Name = D.Name,
            //    Code = D.Code,
            //    Description = D.Description,
            //    DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            //});

            //return departmentsToReturn;


            //Extension method mapping
            return departments.Select(D => D.ToDeptDto());
        }

        public DepartmentsDetailsDTO GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            //Manual mapping
            //return department is null ? null : new DepartmentsDetailsDTO(department)
            //{

            //Id = department.Id,
            //Name = department.Name,
            //Code = department.Code,
            //Description = department.Description,
            //CreatedBy = department.CreatedBy,
            //CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
            //LastModifiedBy = department.LastModifiedBy,
            //IsDeleted = department.IsDeleted



            //};

            //Extension method mapping

            return department.ToDeptDetailsDto();

        }


        //Add Department

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToDepartment();
            return _departmentRepository.Add(department);
        }

        //Update Department

        public int UpdateDepartment(UpdateDeptDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToDepartment());
        }

        //Delete Department

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return false;
            }
            else
            {
                int res = _departmentRepository.Delete(department);
                return res > 0 ? true : false;
            }

        }
    }
}
