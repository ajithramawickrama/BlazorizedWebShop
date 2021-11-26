using Microsoft.EntityFrameworkCore;
using MyFirstBlazorApp.Models;

namespace MyFirstBlazorApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasIndex(nameof(Product.Id), nameof(Product.Code));
            modelBuilder.Entity<Product>().HasIndex(x=>x.Description);
            modelBuilder.Entity<Product>().HasIndex(x => x.UnitPrice);
            modelBuilder.Entity<Product>().Property(x => x.Description).UseCollation("nocase");
        }
    }
}
