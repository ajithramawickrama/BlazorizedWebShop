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
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(name: "Country", schema: "Store");
            builder.Property(p => p.Id)
               .UseIdentityColumn();
            builder.Property(o => o.ISOCode)
               .HasColumnType("nvarchar(3)");
            builder.Property(o => o.Name)
               .HasColumnType("nvarchar(100)");
            builder.Property(o => o.Culture)
               .HasColumnType("nvarchar(10)");
        }
    }
}
