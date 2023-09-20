using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using MyProject2.Models;

namespace MyProject2.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
         
        }

        public DbSet<Product2>? Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product2>().HasData(
                new Product2 { Id=1, Name="Coke", Price=40 },

                new Product2 { Id=2, Name="Sprite", Price=50 },
                new Product2 { Id=3, Name="Sprite", Price=50 });
         }

    }
}
