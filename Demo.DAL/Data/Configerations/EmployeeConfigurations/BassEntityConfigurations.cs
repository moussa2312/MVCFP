using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configerations.EmployeeConfigurations
{
    public class BassEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(D => D.CreatedOn)
                .HasDefaultValueSql("GetDate()"); // is not change when inserted

            builder.Property(D => D.LastModifiedOn)
                .HasComputedColumnSql("GetDate()"); // is change when inserted        }
        }
    }

}