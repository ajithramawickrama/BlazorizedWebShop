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
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(name: "OrderDetail", schema: "Sales");
            builder.Property(p => p.Id)
           .UseIdentityColumn();
            builder.Property(o => o.Qty)
           .HasColumnType("decimal(18,2)");
            builder.Property(o => o.UnitPrice)
           .HasColumnType("decimal(18,2)");
            builder.Property(o => o.Discount)
           .HasColumnType("decimal(18,2)");
        }
    }
}
