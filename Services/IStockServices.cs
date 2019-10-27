using System.Collections.Generic;
using System.Linq;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Services
{
    public interface IStockServices
    {
        IProduct getProduct(int idx);
        IProduct addProduct(Product product);
        IProduct updateProduct(Product product);
        IProduct removeProduct(int idx);
        IProduct searchProduct(string name);
        List<IProduct> listAllProducts();
        List<Product> listProductByCategory(int categoryIdx);

        
        ICategory getCategory(int idx);
        ICategory addCategory(Category category);
        ICategory updateCategory(ICategory category);
        ICategory removeCategory(int idx);
        ICategory searchCategory(string name);
        List<ICategory> listAllCategories();
    }
}