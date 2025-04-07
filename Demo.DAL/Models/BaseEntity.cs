using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } // Primary Key by convention

        public int CreatedBy { get; set; } // User ID of the creator

        public DateTime? CreatedOn { get; set; } // Time of create 

        public int LastModifiedBy { get; set; } // User ID of the modifier

        public DateTime? LastModifiedOn { get; set; } // Time of modify

        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
