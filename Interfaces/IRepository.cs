using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreExample.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class {
        TEntity this[int idx] { get; }
            
        TEntity Get(int idx);
    
        TEntity Get(Func<TEntity, bool> predicate);
    
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate);
    
        IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate);
    
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(int idx);
    
        void Remove(TEntity entity);
    
        void Remove(Expression<Func<TEntity, bool>> predicate);
    
        void RemoveRange(IEnumerable<TEntity> entities);
    
        void Update(TEntity entity);

        bool Exists(Func<TEntity, bool> predicate);
    
        bool Exists(int idx);
    
        bool Exists(object primaryKey);
    
        TEntity First(Expression<Func<TEntity, bool>> predicate);
    
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    
        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> criteria);
    
        IQueryable<TEntity> IncludeMultiple(params Expression<Func<TEntity, object>>[] includes);

    }
}