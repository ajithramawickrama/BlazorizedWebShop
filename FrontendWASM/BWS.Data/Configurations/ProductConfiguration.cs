

namespace MyStore.Persistance.EntityFramework;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasIndex(t=>t.Id);
        builder.HasIndex(x => x.Code);
        builder.HasIndex(x => x.Description);
        builder.Property(x => x.Description).UseCollation("nocase");
        builder.Property(x => x.StockInHand)
               .HasConversion<double>();
        builder.Property(x => x.UnitPrice)
               .HasConversion<double>();
        builder.Property(x => x.DiscountPrice)
               .HasConversion<double>();
    }

       
}

