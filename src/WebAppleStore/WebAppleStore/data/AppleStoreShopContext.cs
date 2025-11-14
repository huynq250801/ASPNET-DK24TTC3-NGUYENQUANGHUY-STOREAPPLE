using Microsoft.EntityFrameworkCore;
using WebAppleStore.Models;

namespace WebAppleStore.Data
{
    public class AppleStoreShopContext : DbContext
    {
        public AppleStoreShopContext(DbContextOptions<AppleStoreShopContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
