using Microsoft.EntityFrameworkCore;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Interfaces
{
    public class IStoreContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        
    }
}