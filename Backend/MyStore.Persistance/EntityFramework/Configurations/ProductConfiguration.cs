using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Domain.Models;

namespace MyStore.Persistance.EntityFramework
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Product", schema: "Store");
            builder.Property(p => p.Id)
               .UseIdentityColumn();
            builder.Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.DiscountPrice)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.StockInHand)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.MinOrderQry)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.ReorderLevel)
                .HasColumnType("int)");
            builder.Property(o => o.Description)
               .HasColumnType("nvarchar(100)");
        }

       
    }
}
