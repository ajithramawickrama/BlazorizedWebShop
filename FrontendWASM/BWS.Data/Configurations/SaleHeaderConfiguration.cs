

namespace MyStore.Persistance.EntityFramework;

internal class SaleHeaderConfiguration : IEntityTypeConfiguration<SaleHeader>
{
    public void Configure(EntityTypeBuilder<SaleHeader> builder)
    {
        builder.HasIndex(builder => builder.Id);
        builder.HasIndex(builder => builder.TransactionDate);
        builder.HasIndex(builder => builder.StoreId);
        builder.HasIndex(builder => builder.CustomerId);
        builder.Property(x => x.TotalAmount)
              .HasConversion<double>();
        builder.Property(x => x.TotalDiscount)
               .HasConversion<double>();
    }
}

