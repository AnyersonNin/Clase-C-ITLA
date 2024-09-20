using Microsoft.EntityFrameworkCore;
using ShopWeb.Data.Entities;

namespace ShopWeb.Data.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base (options)
        {     
        }

        public DbSet<Products> Products{ get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }



    }
}
