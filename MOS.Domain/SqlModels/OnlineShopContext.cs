using System;
using Microsoft.EntityFrameworkCore;
using MOS.Domain.Helpers;

namespace MOS.Domain.SqlModels
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        { }

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options) { }

        public virtual DbSet<MasterProduct> MasterProduct { get; set; }
        public virtual DbSet<TransOrder> TransOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigManager.ConfigRoot.GetSection("Data:DBEntities:ConnectionString").Value);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Master_P__B40CC6CDA9CC663E");

                entity.ToTable("Master_Product");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TransOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Trans_Or__C3905BCF0CD1E753");

                entity.ToTable("Trans_Order");

                entity.Property(e => e.CancelledDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveredDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress).IsRequired();

                entity.Property(e => e.OrderedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ReturnedDate).HasColumnType("datetime");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(16, 2)");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
