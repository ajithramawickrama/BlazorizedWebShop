using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyStore.PersistanceRE.Models;

namespace MyStore.PersistanceRE.Data
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext()
        {
        }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

   
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=20.205.177.211;Initial Catalog=MyStore;User ID=sa; password=abc@1234; MultipleActiveResultSets=True;ConnectRetryCount=5;ConnectRetryInterval=5");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "Store");

                entity.Property(e => e.Culture).HasMaxLength(10);

                entity.Property(e => e.Isocode)
                    .HasMaxLength(3)
                    .HasColumnName("ISOCode");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Person");

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.LastPurchaseDate).HasColumnType("date");

                entity.Property(e => e.MobileNumber).HasMaxLength(12);

                entity.Property(e => e.StateProvince).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(20);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail", "Sales");

                entity.HasIndex(e => e.OrderHeaderId, "IX_OrderDetail_OrderHeaderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderDetail_ProductId");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderHeader>(entity =>
            {
                entity.ToTable("OrderHeader", "Sales");

                entity.HasIndex(e => e.CustomerId, "IX_OrderHeader_CustomerId");

                entity.HasIndex(e => e.StoreId, "IX_OrderHeader_StoreId");

                entity.Property(e => e.InvoiceValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Store");

                entity.HasIndex(e => e.StoreId, "IX_Product_StoreId");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImgeUrl).HasMaxLength(500);

                entity.Property(e => e.MinOrderQry).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockInHand).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Store");

                entity.HasIndex(e => e.CountryId, "IX_Store_CountryId");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.StoreName).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.CountryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
