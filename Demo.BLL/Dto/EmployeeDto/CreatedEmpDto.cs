using Demo.DAL.Models.Emp_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Dto.EmployeeDto
{
    public class CreatedEmpDto
    {
        [Required(ErrorMessage = " name must be not null! ")]
        [MaxLength(50 , ErrorMessage = "Max length should be 50 Character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 Character")]
        public string Name { get; set; } = string.Empty;

        [Range(22, 30)] 
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$" , 
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
    }
}
