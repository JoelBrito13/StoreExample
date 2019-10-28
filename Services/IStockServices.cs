using System.Collections.Generic;
using System.Threading.Tasks;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Services
{
    public interface IStockServices
    { 
        //Categories
        Task<ICategory> GetCategoryAsync(int idx);
        Task<ICategory> AddCategory(Category category);
        Task<ICategory> UpdateCategoryAsync(Category category);
        Task<ICategory> RemoveCategoryAsync(int idx);
        Task<ICategory> SearchCategoryAsync(string name);
        Task<List<ICategory>> ListAllCategoriesAsync();
        
        //Products
        Task<IProduct> GetProductAsync(int idx);
        Task<IProduct> AddProductAsync(Product product);
        Task<IProduct> UpdateProduct(Product product);
        Task<IProduct> RemoveProduct(int idx);
        Task<IProduct> SearchProductAsync(string name);
        Task<List<IProduct>> ListAllProducts();
        Task<List<IProduct>> ListProductByCategory(int categoryIdx);
    }
}