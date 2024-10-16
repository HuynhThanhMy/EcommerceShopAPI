using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Order
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(dh => dh.OrderId);
                e.Property(dh => dh.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.Consignee).IsRequired().HasMaxLength(100);
            });

            // Cấu hình bảng OrderDetails
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetails_Order");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_OrderDetails_Product");
            });

            // Cấu hình cho ASP.NET Identity
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
        }
    }
}
