using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO
{
    public class CreatedDepartmentDto
    {
        [Required (ErrorMessage = "Name Is Required!!!")]
        public string Name { get; set; } = string.Empty; // Name of the department
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; } // Time of create

    }
}
