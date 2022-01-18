using Microsoft.EntityFrameworkCore;
using OnlineShoping.Data.Models;

namespace OnlineShop.Data.DataLayer
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            :base (options)
        {
            
        }
        public DbSet<Product> Products {get; set;}
    }
}