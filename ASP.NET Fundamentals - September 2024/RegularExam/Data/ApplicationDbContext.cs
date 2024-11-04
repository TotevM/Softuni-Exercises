using DeskMarket.Data.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ProductClient>().HasKey(pc => new { pc.ProductId, pc.ClientId });

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Laptops" },
                    new Category { Id = 2, Name = "Workstations" },
                    new Category { Id = 3, Name = "Accessories" },
                    new Category { Id = 4, Name = "Desktops" },
                    new Category { Id = 5, Name = "Monitors" });
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductClient> ProductsClients { get; set; }
    }
}
