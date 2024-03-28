using Demo_ASP.NET_MVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.DAL.Data.Cinfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(E => E.Address).IsRequired();
            builder.Property(E => E.Salary).HasColumnType("decimal(12,2)");
            builder.Property(E => E.Gender).HasConversion(
                (Gender) => Gender.ToString(),
                (genderAssString) => (Gender)Enum.Parse(typeof(Gender), genderAssString, true)
                );
            builder.Property(E => E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
