using System;
using System.Collections.Generic;
using System.Linq;
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

        public IProduct getProduct(int idx)
        {
            var product = UnitOfWork.Products.Get(idx);
            product.Category = (Category) getCategory(product.CategoryIdx);
            return product;
        }

        public IProduct addProduct(Product product)
        {
            if (!UnitOfWork.Categories.Exists(product.CategoryIdx) )throw new Exception("Product Category is not Listed")
                ;
            try
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Products.Add(product);
                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch(Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return product;
        }

        public IProduct updateProduct(Product product)
        {
            if (!UnitOfWork.Categories.Exists(product.CategoryIdx) )throw new Exception("Product Category is not Listed")
                ;
            Product actualProduct = (Product)getProduct(product.Idx);
            try
            {                
                UnitOfWork.BeginTransaction();
                
                actualProduct.Name = product.Name;
                actualProduct.Price = product.Price;
                actualProduct.CategoryIdx = product.CategoryIdx;
                
                UnitOfWork.Products.Update(actualProduct);

                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return actualProduct;
        }

        public IProduct removeProduct(int idx)
        {
            Product product = (Product) getProduct(idx); 
            try
            {                
                UnitOfWork.BeginTransaction();
                UnitOfWork.Products.Remove(product);

                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return product;
        }

        public IProduct searchProduct(string name)
        {
            return UnitOfWork.Products.GetManyQueryable(u => u.Name == name).FirstOrDefault();
        }

        public List<IProduct> listAllProducts()
        {
            var listCategories = listAllCategories();
            List<IProduct> listProducts = new List<IProduct>(UnitOfWork.Products.GetAll().ToList());
            listProducts.ForEach(
                p => p.Category = (Category) listCategories.FirstOrDefault(
                    c => c.Idx == p.CategoryIdx));
            return listProducts;

        }

        public List<Product> listProductByCategory(int categoryIdx)
        {   ICategory category = getCategory(categoryIdx);
            if (category == null )throw new Exception("Category is not Listed")
            ;
            List<Product> listProduct = (List<Product>) UnitOfWork.Products.GetMany(u => u.CategoryIdx == categoryIdx) ;
           
            listProduct.ForEach(u => u.Category = (Category)category);
           
            return listProduct;
        }
        public ICategory getCategory(int idx)
        {
            return UnitOfWork.Categories.Get(idx);
        }

        public ICategory addCategory(Category category)
        {
            try
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Categories.Add(category);
                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch(Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return category;
        }

        public ICategory updateCategory(ICategory category)
        {
            Category actualCategory = (Category)getCategory(category.Idx);
            try
            {                
                actualCategory.Name = category.Name;
                UnitOfWork.BeginTransaction();
                UnitOfWork.Categories.Update(actualCategory);

                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return category;
        }

        public ICategory removeCategory(int idx)
        {
            Category category = (Category) getCategory(idx); 
            try
            {                
                UnitOfWork.BeginTransaction();
                UnitOfWork.Categories.Remove(category);

                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return category;
        }

        public ICategory searchCategory(string name)
        {
            return UnitOfWork.Categories.GetManyQueryable(u => u.Name == name).FirstOrDefault();
        }

        public List<ICategory> listAllCategories()
        {
            return new List<ICategory>(UnitOfWork.Categories.GetAll());
        }
        
    }
}