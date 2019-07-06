using ArticleApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArticleApi.Application.Interfaces
{
    public interface IRepository<T> where T : EntityBase<T>, new()
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T GetBy(Expression<Func<T, bool>> match);
        ICollection<T> GetAllBy(Expression<Func<T, bool>> match);

        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByAsync(Expression<Func<T, bool>> match);
        Task<ICollection<T>> GetAllByAsync(Expression<Func<T, bool>> match);

        T Delete(T entity);
        Task<T> DeleteAsync(T entity);

        T DeleteById(int id);
        Task<T> DeleteByIdAsync(int id);

        T Update(T entity);
        Task<T> UpdateAsync(T entity);

        T Add(T entity);
        Task<T> AddAsync(T entity);

        int AddRange(IEnumerable<T> entities);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
    }
}
