using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreExample.Interfaces;
  
namespace StoreExample.Repositories
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class {
    protected readonly DbContext Context;   
    protected readonly DbSet<TEntity> DbSet;

    public TEntity this[int idx] => Get(idx);

    public Repository(DbContext context) {
      Context = context;
      DbSet = Context.Set<TEntity>();
    }

    public TEntity Get(int idx) {
      return DbSet.Find(idx);
    }

    public TEntity Get(Func<TEntity, bool> predicate) {
      return DbSet.FirstOrDefault(predicate);
    }

    public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include) {
      IQueryable<TEntity> query = this.DbSet;
      query = include.Aggregate(query, (current, inc) => current.Include(inc));
      return query.Where(predicate);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
    {
      return predicate != null ? DbSet.Where(predicate).ToList() : DbSet.ToList();
    }
    public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate) {
      return DbSet.Where(predicate).ToList();
    }

    public IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate) {
      return DbSet.Where(predicate).AsQueryable();
    }
    
    public void Add(TEntity entity) {
      DbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      DbSet.AddRange(entities);
    }

    public void Remove(int idx)
    {
      DbSet.Remove(Get(idx));
    }

    public void Remove(TEntity entity) {
      DbSet.Remove(entity);
    }

    public void Remove(Expression<Func<TEntity, bool>> predicate) {
      var objects = DbSet.Where(predicate).AsQueryable();
      foreach (var obj in objects)
        DbSet.Remove(obj);
    }

    public void RemoveRange(IEnumerable<TEntity> entities) {
      DbSet.RemoveRange(entities);
    }

    public void Update(TEntity entity) {
      DbSet.Update(entity);
    }

    public bool Exists(Func<TEntity, bool> predicate)
    {
      return (Get(predicate) != null);
    }

    public bool Exists(int idx) {
      return DbSet.Find(idx) != null;
    }
    public bool Exists(object primaryKey) {
      return DbSet.Find(primaryKey) != null;
    }
    public TEntity First(Expression<Func<TEntity, bool>> predicate) {
      return DbSet.First(predicate);
    }

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) {
      return DbSet.FirstOrDefault(predicate);
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