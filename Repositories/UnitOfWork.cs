using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StoreExample.Interfaces;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;

namespace StoreExample.Repositories
{
   
        public class UnitOfWork: IUnitOfWork {
            #region // Atributes //
            private readonly DbContext Context;

            private RepositoryAsync<Category> _categories;
            private RepositoryAsync<Product> _products;

            //public DbContext Context => _Context ?? (_Context = Context.st);
            #endregion

            public UnitOfWork(StoreContext context) {
                Context = context ?? throw new ArgumentNullException(nameof(context), "Invalid Entry Context");
            }
            
            public IRepositoryAsync<Category> Categories  => 
                _categories ?? (_categories = new RepositoryAsync<Category>(Context));            
            public IRepositoryAsync<Product> Products  => 
                _products ?? (_products = new RepositoryAsync<Product>(Context));

            public async Task<int> SaveChangesAsync() {
                return await Context.SaveChangesAsync();
            }

            public async Task<IDbContextTransaction> BeginTransactionAsync() {
               return await Context.Database.BeginTransactionAsync();
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