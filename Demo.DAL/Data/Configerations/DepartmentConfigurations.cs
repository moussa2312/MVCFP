using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configerations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {


        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id)
                .UseIdentityColumn(10, 10);

            builder.Property(D => D.Name)
                .HasColumnType("varchar(20)");

            builder.Property(D => D.Code)
                .HasColumnType("varchar(20)");

            builder.Property(D => D.CreatedOn)
                .HasDefaultValueSql("getdate()"); // is not change when inserted

            builder.Property(D => D.LastModifiedOn)
                .HasComputedColumnSql("getdate()"); // is change when inserted


        }
    }

}
