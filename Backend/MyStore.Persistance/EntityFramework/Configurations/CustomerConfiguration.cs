using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Persistance.EntityFramework
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(name: "Customer", schema: "Person");
            builder.Property(p => p.Id)
           .UseIdentityColumn();
            builder.Property(o => o.FirstName)
           .HasColumnType("nvarchar(100)");
            builder.Property(o => o.LastName)
           .HasColumnType("nvarchar(200)");
            builder.Property(o => o.Title)
           .HasColumnType("nvarchar(20)");
            builder.Property(o => o.Gender)
           .HasColumnType("nvarchar(20)");
            builder.Property(o => o.Email)
            .HasColumnType("nvarchar(100)");
            builder.Property(o => o.MobileNumber)
            .HasColumnType("nvarchar(12)");
            builder.Property(o => o.Address1)
            .HasColumnType("nvarchar(50)");
            builder.Property(o => o.Address2)
            .HasColumnType("nvarchar(50)");
            builder.Property(o => o.City)
            .HasColumnType("nvarchar(50)");
            builder.Property(o => o.ZipCode)
            .HasColumnType("nvarchar(50)");
            builder.Property(o => o.StateProvince)
            .HasColumnType("nvarchar(50)");
            builder.Property(o => o.Country)
            .HasColumnType("nvarchar(50)");
        }
    }
}
