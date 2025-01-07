using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkProyecto1.Models;

namespace TestEntityFrameworkProyecto1.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Salt).IsRequired();
            });

            // Product Configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            // WishList Configuration
            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasOne(w => w.User)
                      .WithMany(u => u.WishLists)
                      .HasForeignKey(w => w.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // WishListItem Configuration
            modelBuilder.Entity<WishListItem>(entity =>
            {
                entity.HasOne(wi => wi.WishList)
                      .WithMany(w => w.Items)
                      .HasForeignKey(wi => wi.WishListId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(wi => wi.Product)
                      .WithMany(p => p.WishListItems)
                      .HasForeignKey(wi => wi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
