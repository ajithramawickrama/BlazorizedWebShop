

namespace MyStore.Persistance.EntityFramework;

internal class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.HasIndex(builder => builder.Id);
        builder.HasIndex(builder => builder.SaleHeaderId);
        builder.HasIndex(builder => builder.ProductId);
        builder.Property(x => x.Qty)
             .HasConversion<double>();
        builder.Property(x => x.UnitPrice)
               .HasConversion<double>();
        builder.Property(x => x.Discount)
              .HasConversion<double>();
    }
}

