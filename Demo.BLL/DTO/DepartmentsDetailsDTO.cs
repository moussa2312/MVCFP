using Demo.DAL.Models;

namespace Demo.BLL.DTO
{

    public class DepartmentsDetailsDTO
    {
        //constructor mapping
        //public DepartmentsDetailsDTO(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Code = department.Code;
        //    Description = department.Description;
        //    CreatedBy = department.CreatedBy;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value);
        //    LastModifiedBy = department.LastModifiedBy;
        //    IsDeleted = department.IsDeleted;
        //}

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Name of the department
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CreatedBy { get; set; } // User ID of the creator
        public DateOnly CreatedOn { get; set; } // Time of create 
        public int LastModifiedBy { get; set; } // User ID of the modifier
        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
