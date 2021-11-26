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
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable(name: "Store", schema: "Store");
            builder.Property(p => p.Id)
                .UseIdentityColumn();
            builder.Property(o => o.Code)
               .HasColumnType("nvarchar(10)");
            builder.Property(o => o.StoreName)
               .HasColumnType("nvarchar(100)");
        }
    }
}
