using DigitalShop.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalShop.Mvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
