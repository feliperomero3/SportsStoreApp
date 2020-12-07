using Microsoft.EntityFrameworkCore;
using ServerApp.Entities;

namespace ServerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; private set; }
        public DbSet<Supplier> Suppliers { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder => { builder.Property(p => p.Price).HasColumnType("decimal(8, 2)"); });

            modelBuilder.Entity<Product>().HasMany(p => p.Ratings)
                .WithOne(r => r.Product).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().HasOne(p => p.Supplier)
                .WithMany(s => s.Products).OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
