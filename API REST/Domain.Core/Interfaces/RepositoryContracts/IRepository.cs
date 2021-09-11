using Domain.Core.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.RepositoryContracts
{
    public interface IRepository<TEntity, in TId> where TEntity : class
    {
        Task<TEntity> GetAsync(TId id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IPaginationResult<TEntity>> PaginateAsync(IPaginationParameters<TEntity> parameters);
    }
}