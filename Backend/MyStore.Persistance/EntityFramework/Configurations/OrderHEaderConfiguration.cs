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
    internal class OrderHEaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable(name: "OrderHeader", schema: "Sales");
            builder.Property(p => p.Id)
           .UseIdentityColumn();
            builder.Property(o => o.InvoiceValue)
           .HasColumnType("decimal(18,2)");
            builder.Property(o => o.TotalDiscount)
           .HasColumnType("decimal(18,2)");
        }
    }
}
