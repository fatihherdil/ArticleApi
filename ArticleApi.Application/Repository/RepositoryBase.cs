using ArticleApi.Application.Interfaces;
using ArticleApi.Domain.Entities;
using ArticleApi.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArticleApi.Application.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase<TEntity>, new()
    {
        protected readonly ArticleApiDbContext DbContext;

        protected readonly DbSet<TEntity> _dbContext;

        public RepositoryBase(ArticleApiDbContext dbContext)
        {
            DbContext = dbContext;
            _dbContext = DbContext.Set<TEntity>();
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _dbContext.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            var entity = _dbContext.FirstOrDefault(e => e.Id == id);
            return entity ?? new TEntity().GetNullInstance();
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> match)
        {
            var entity = _dbContext.FirstOrDefault(match);
            return entity ?? new TEntity().GetNullInstance();
        }

        public virtual ICollection<TEntity> GetAllBy(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Where(match).ToList();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbContext.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbContext.FirstOrDefaultAsync(e => e.Id == id);
            return entity ?? new TEntity().GetNullInstance();
        }

        public virtual async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> match)
        {
            var entity = await _dbContext.FirstOrDefaultAsync(match);
            return entity ?? new TEntity().GetNullInstance();
        }

        public virtual async Task<ICollection<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Where(match).ToListAsync();
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();

            var entityEntry = _dbContext.Remove(entity);
            DbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public TEntity DeleteById(int id)
        {
            var entity = _dbContext.FirstOrDefault(e => e.Id == id);

            if (entity == null) return new TEntity().GetNullInstance();
            var entityEntry = _dbContext.Remove(entity);
            DbContext.SaveChanges();

            return entityEntry.Entity;
        }

        public async Task<TEntity> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return new TEntity().GetNullInstance();

            var entityEntry = _dbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();
            var entityEntry = _dbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();
            var entityEntry = _dbContext.Update(entity);
            DbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();

            var entityEntry = _dbContext.Update(entity);
            await DbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();

            var entityEntry = _dbContext.Add(entity);
            DbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null) return new TEntity().GetNullInstance();

            var entityEntry = await _dbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            var list = entities.ToList();
            if (list.Count <= 0) return -1;

            _dbContext.AddRange(list);
            var count = DbContext.SaveChanges();
            return count;
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var list = entities.ToList();
            if (list.Count <= 0) return -1;

            await _dbContext.AddRangeAsync(list);
            var count = await DbContext.SaveChangesAsync();
            return count;
        }
    }
}
