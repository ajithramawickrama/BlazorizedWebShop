

namespace BWS.Data.EFCoreSqllite;

public class BWSDbContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SaleHeader> SaleHaders { get; set; }
    public DbSet<SaleDetail> SaleDetails { get; set; } 
    public BWSDbContext(DbContextOptions<BWSDbContext> options) : base(options)
    {

    }
}

