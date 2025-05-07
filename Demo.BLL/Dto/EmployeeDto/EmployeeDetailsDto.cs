using Demo.DAL.Models.Emp_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Dto.EmployeeDto
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public string Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
    }
}
