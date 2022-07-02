using Microsoft.EntityFrameworkCore;
using DataAccess.Context.Entities;

namespace DataAccess.Context
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
    }
}
