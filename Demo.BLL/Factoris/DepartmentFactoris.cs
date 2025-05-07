using Demo.BLL.DTO;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factoris
{
    //Extension method to convert Department to DepartmentDTO
    static public class DepartmentFactories
    {
        public static DepartmentDTO ToDeptDto(this Department D)
        {
            return new DepartmentDTO
            {
                ID = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            };
        }

        public static DepartmentsDetailsDTO ToDeptDetailsDto(this Department D)
        {
            return new DepartmentsDetailsDTO
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedBy = D.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(D.CreatedOn.Value),
                LastModifiedBy = D.LastModifiedBy,
                IsDeleted = D.IsDeleted
            };
        }

        public static Department ToDepartment(this CreatedDepartmentDto D)
        {
            return new Department
            {
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedOn = D.DateOfCreation.ToDateTime(new TimeOnly(0, 0)),

            };
        }

        public static Department ToDepartment(this UpdateDeptDto D)
        {
            return new Department
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedOn = D.DateOfCreation.ToDateTime(new TimeOnly(0, 0)),
            };
        }
    }
}