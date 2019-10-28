using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepositoryAsync<Category> Categories { get; }
        IRepositoryAsync<Product> Products { get; }

        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        void Rollback();
    
    }
}