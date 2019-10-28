using Microsoft.EntityFrameworkCore;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Repositories
{
    public sealed class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options): base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            //Property Configurations
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}