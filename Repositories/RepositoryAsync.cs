using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StoreExample.Interfaces;
  
namespace StoreExample.Repositories
{
    public class RepositoryAsync<TEntity>: IRepositoryAsync<TEntity> where TEntity: class {
    protected readonly DbContext Context;   
    protected readonly DbSet<TEntity> DbSet;

    public object this[int idx] =>  GetAsync(idx);

    public RepositoryAsync(DbContext context) {
      Context = context;
      DbSet = Context.Set<TEntity>();
    }

    public async Task<TEntity> GetAsync(int idx) {
      return await DbSet.FindAsync(idx);
    }
/*
    public async Task<TEntity> GetAsync(Func<TEntity, bool> predicate) {
      return await DbSet.FirstOrDefaultAsync<TEntity>(predicate);
    }
*/
    public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include) {
      IQueryable<TEntity> query = DbSet;
      query = include.Aggregate(query, (current, inc) => current.Include(inc));
      return query.Where(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
      return predicate != null ? await DbSet.Where(predicate).ToListAsync() : await DbSet.ToListAsync();
    }
    public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate) {
      return await DbSet.Where(predicate).ToListAsync();
    }

    public IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate) {
      return DbSet.Where(predicate).AsQueryable();
    }
    
    public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) {
      return await DbSet.AddAsync(entity);
    }

    public async void AddRangeAsync(IEnumerable<TEntity> entities)
    {
      await DbSet.AddRangeAsync(entities);
    }

    public async void Remove(int idx)
    {
      DbSet.Remove(await GetAsync(idx));
    }

    public async void Remove(TEntity entity) {
      DbSet.Remove(entity);
    }

    public async void Remove(Expression<Func<TEntity, bool>> predicate) {
      var objects = DbSet.Where(predicate).AsQueryable();
      foreach (var obj in objects)
        DbSet.Remove(obj);
    }

    public async void RemoveRange(IEnumerable<TEntity> entities) {
      DbSet.RemoveRange(entities);
    }

                                 
    public void Update(TEntity entity)
    {
      DbSet.Update(entity);
    }

  /*  public async Task<bool> ExistsAsync(Func<TEntity, bool> predicate)
    {
      return await GetAsync(predicate) != null;
    }
*/
    public async Task<bool> ExistsAsync(int idx) {
      return await DbSet.FindAsync(idx) != null;
    }
    public async Task<bool> ExistsAsync(object primaryKey) {
      return await DbSet.FindAsync(primaryKey) != null;
    }
    public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate) {
      return await DbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
      return await DbSet.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> criteria) {
      return DbSet.Include(criteria).AsQueryable();
    }

    public IQueryable<TEntity> IncludeMultiple(params Expression<Func<TEntity, object>>[] includes) {
      var query = DbSet.AsQueryable();

      if (includes != null) {
        query = includes.Aggregate(query,
          (current, include) => current.Include(include));
      }

      return query;
    }
  }
}