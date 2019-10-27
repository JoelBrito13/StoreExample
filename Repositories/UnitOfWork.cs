using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StoreExample.Interfaces;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Repositories
{
   
        public class UnitOfWork: IUnitOfWork {
            #region // Atributes //
            private readonly DbContext Context;

            private Repository<Category> _Categories;
            private Repository<Product> _Products;

            //public DbContext Context => _Context ?? (_Context = Context.st);
            #endregion

            public UnitOfWork(StoreContext context) {
                Context = context ?? throw new ArgumentNullException(nameof(context), "Invalid Entry Context");
            }
            
            public IRepository<Category> Categories  => _Categories ?? (_Categories = new Repository<Category>(Context));            
            public IRepository<Product> Products  => _Products ?? (_Products = new Repository<Product>(Context));

            public void SaveChanges() {
                Context.SaveChanges();
            }

            public void BeginTransaction() {
                Context.Database.BeginTransaction();
            }

            public void Commit() {
                Context.Database.CurrentTransaction.Commit();
            }

            public void Rollback() {
                Context.Database.CurrentTransaction.Rollback();
            }

            public void Dispose() {
                Context.Dispose();
            }
        }
    
}