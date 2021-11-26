

namespace MyStore.Persistance.EntityFramework;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasIndex(builder => builder.Id);
        builder.HasIndex(builder => builder.FirstName);
        builder.HasIndex(builder => builder.LastName);
        builder.HasIndex(builder => builder.MobileNumber);
        //builder.HasIndex(builder => builder.Country);
        builder.HasIndex(builder => builder.City);
        //builder.HasIndex(builder => builder.StateProvince);
        builder.HasIndex(builder => builder.Gender);
    }
}

