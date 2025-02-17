using DigitalShop.Mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalShop.Mvc.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
