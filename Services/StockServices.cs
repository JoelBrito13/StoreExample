using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreExample.Interfaces;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Services
{
    public class StockServices : IStockServices
    {
        public readonly IUnitOfWork UnitOfWork;

        public StockServices(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ??
                         throw new ArgumentNullException(nameof(unitOfWork), "Fail to Start UnitOfWorks");
        }
        
        
        
        //                  Categories
        public async Task<ICategory> GetCategoryAsync(int idx)
        {
            return await UnitOfWork.Categories.GetAsync(idx);
        }

        public async Task<ICategory> AddCategory(Category category)
        {
            try
            {
                await UnitOfWork.BeginTransactionAsync();
                await UnitOfWork.Categories.AddAsync(category);
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return category;
        }

        public async Task<ICategory> UpdateCategoryAsync(Category category)
        {
            Category actualCategory = (Category)await GetCategoryAsync(category.Idx);
            try
            {                
                actualCategory.Name = category.Name;
                await UnitOfWork.BeginTransactionAsync();
                UnitOfWork.Categories.Update(actualCategory);

                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return actualCategory;
        }

        public async Task<ICategory> RemoveCategoryAsync(int idx)
        {
            Category category = (Category) await GetCategoryAsync(idx); 
            try
            {                
                await UnitOfWork.BeginTransactionAsync();
                UnitOfWork.Categories.Remove(category);

                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return new NullCategory();
        }

        public async Task<ICategory> SearchCategoryAsync(string name)
        {
            return await UnitOfWork.Categories.GetManyQueryable(u => u.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<ICategory>> ListAllCategoriesAsync()
        {
            return new List<ICategory>(await UnitOfWork.Categories.GetAllAsync());
        }
        
        //                  Products
        
        public async Task<IProduct> GetProductAsync(int idx)
        {
            IProduct product = await UnitOfWork.Products.GetAsync(idx);
            product.Category = (Category) await GetCategoryAsync(product.CategoryIdx);
            return product;
        }
    
        public async Task<IProduct> AddProductAsync(Product product)
        {
            if (!await UnitOfWork.Categories.ExistsAsync(product.CategoryIdx) )throw new Exception("Product Category is not Listed")
                ;
            try
            {
                
                await UnitOfWork.BeginTransactionAsync();
                await UnitOfWork.Products.AddAsync(product);
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return product;
        }

        public async Task<IProduct> UpdateProduct(Product product)
        {
            if (! await UnitOfWork.Categories.ExistsAsync(product.CategoryIdx) )throw new Exception("Product Category is not Listed")
                ;
            Product actualProduct = (Product) await GetProductAsync(product.Idx);
            try
            {                
                await UnitOfWork.BeginTransactionAsync();
                
                actualProduct.Name = product.Name;
                actualProduct.Price = product.Price;
                actualProduct.CategoryIdx = product.CategoryIdx;
                
                UnitOfWork.Products.Update(actualProduct);

                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return actualProduct;
        }

        public async Task<IProduct> RemoveProduct(int idx)
        {
            Product product = (Product) await GetProductAsync(idx); 
            try
            {                
                await UnitOfWork.BeginTransactionAsync();
                UnitOfWork.Products.Remove(product);

                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
            return new NullProduct();
        }

        public async Task<IProduct> SearchProductAsync(string name)
        {
            return await UnitOfWork.Products.GetManyQueryable(u => u.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<IProduct>> ListAllProducts()
        {
            var listCategories = await ListAllCategoriesAsync();
            List<Product> listProducts = new List<Product>(await UnitOfWork.Products.GetAllAsync());
            listProducts.ForEach(
                p => p.Category = (Category) listCategories.FirstOrDefault(
                    c => c.Idx == p.CategoryIdx));
            return new List<IProduct>(listProducts);
        }

        public async Task<List<IProduct>> ListProductByCategory(int categoryIdx)
        {   Category category = (Category) await GetCategoryAsync(categoryIdx);
            if (category == null )throw new Exception("Category is not Listed")
            ;
            List<Product> listProduct = (List<Product>) await UnitOfWork.Products.GetManyAsync(u => u.CategoryIdx == categoryIdx) ;
           
            listProduct.ForEach(u => u.Category = category);
           
            return new List<IProduct>(listProduct);
        }
    }
}