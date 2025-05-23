﻿using Demo.DAL.Data.Configerations.EmployeeConfigurations;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configerations
{
    // This class is used to configure the Department entity in the database using Fluent API.
    // why IEntityTypeConfiguration<Department> is used?
    // It is an interface provided by Entity Framework Core that allows you to configure the properties of the Department entity.

    public class DepartmentConfigurations : BassEntityConfigurations<Department> , IEntityTypeConfiguration<Department>
    {
        //implement interface method
        public new void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
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

            base.Configure(builder); // Call the base class method to apply the default configurations
        }
    }

}
