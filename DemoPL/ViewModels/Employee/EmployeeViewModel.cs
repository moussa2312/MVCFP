using Demo.DAL.Models.Emp_Model;
using System.ComponentModel.DataAnnotations;

namespace DemoPL.ViewModels.Employee
{
    public class EmployeeViewModel
    {

            public string Name { get; set; } = string.Empty;

            [Range(22, 30)]
            public int? Age { get; set; }

            [DataType(DataType.Currency)]
            public decimal Salary { get; set; }

            [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
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
            public EmployeeType EmployeeType { get; set; }
        

    }
}
