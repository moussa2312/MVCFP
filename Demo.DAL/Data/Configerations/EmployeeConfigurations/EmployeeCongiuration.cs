using Demo.DAL.Models.Emp_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configerations.EmployeeConfigurations
{
    public class EmployeeCongiuration : BassEntityConfigurations<Employee> , IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");

            builder.Property(E => E.Address).HasColumnType("varchar(150)");

            builder.Property(E => E.Salary).HasColumnType("decimal(10 , 2)");

            //HasConversion from Gender to string when i save to database
            // and reverse it Gender when i get it from database

            builder.Property(E => E.Gender)
                .HasConversion(
                    empGender => empGender.ToString(),
                    rempGender => Enum.Parse<Gender>(rempGender));

            builder.Property(E => E.EmployeeType)
                .HasConversion(
                    empType => empType.ToString(), //to DB
                    rempType => Enum.Parse<EmployeeType>(rempType)); //retrive from DB

            base.Configure(builder); // Call the base class method to apply the default configurations

        }
    }
}
