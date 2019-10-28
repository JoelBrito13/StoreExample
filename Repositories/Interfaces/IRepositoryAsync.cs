using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace StoreExample.Interfaces
{
    public interface IRepositoryAsync<TEntity> where TEntity : class {
        object this[int idx] { get; }
            
        Task<TEntity> GetAsync(int idx);
    
       // Task<TEntity> GetAsync(Func<TEntity, bool> predicate);
    
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
    
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate);
    
        IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate);
    
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        void AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(int idx);
    
        void Remove(TEntity entity);
    
        void Remove(Expression<Func<TEntity, bool>> predicate);
    
        void RemoveRange(IEnumerable<TEntity> entities);
    
        void Update(TEntity entity);

        //Task<bool> ExistsAsync(Func<TEntity, bool> predicate);
    
        Task<bool> ExistsAsync(int idx);
    
        Task<bool> ExistsAsync(object primaryKey);
    
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);
    
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    
        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> criteria);
    
        IQueryable<TEntity> IncludeMultiple(params Expression<Func<TEntity, object>>[] includes);

    }
}