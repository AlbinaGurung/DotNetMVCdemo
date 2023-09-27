using System.ComponentModel;
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
        public DbSet<Category>? Categories { get; set; }

       
         
            
         

    }
}
