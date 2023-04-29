using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Persistence
{
    public interface IRepository<T> : IQuery<T> where T : Entity
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                   IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                   CancellationToken cancellationToken = default);
        Task<TResult?> GetSelectDetailAsync<TResult>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                      IIncludableQueryable<T, object>>? include = null, Expression<Func<T, TResult>>? selector = null, bool enableTracking = true,
                      CancellationToken cancellationToken = default);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                bool enableTracking = true,
                                CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);


    }
}
