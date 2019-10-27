using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }

        void SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    
    }
}