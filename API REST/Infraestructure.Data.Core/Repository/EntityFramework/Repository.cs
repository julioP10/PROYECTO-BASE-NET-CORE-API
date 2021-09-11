using Domain.Core.Interfaces.RepositoryContracts;
using Domain.Core.Pagination;
using Infraestructure.Data.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.CrossCutting.Enums;

namespace Infraestructure.Data.Core
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>, IDisposable
        where TEntity : class
        where TId : IComparable<TId>
    {
        protected DbContext Context { get; }

        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }

        public Repository(DbContext dbContext, DbSet<TEntity> dbSet)
        {
            Context = dbContext;
            DbSet = dbSet;
        }

        #region Public Methods

        public virtual Task<TEntity> GetAsync(TId id)
        {
            return GetAsync(id, null);
        }

        protected async virtual Task<TEntity> GetAsync(TId id,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var keyProperty = Context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties[0];
            int keyId = (int)Convert.ChangeType(id, typeof(int));

            IQueryable<TEntity> dbSet = include != null ? include(DbSet) : (IQueryable<TEntity>)DbSet;

            //TODO: Buscar la forma de refactorizar esto para no estar obligado a tener una llave numérica.
            return await dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, keyProperty.Name) == keyId);
        }

        public async virtual void Create(TEntity entity)
        {
            await CreateAsync(entity);
        }

        protected async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);

            var entry = Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entity)
        {
            if (!DbSet.Local.Any(p => p == entity))
            {
                DbSet.Attach(entity);
                var entry = Context.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return @readonly
                ? DbSet.AsNoTracking()
                : DbSet;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Find(predicate, null);
        }

        protected virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include,
           bool @readonly = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (@readonly)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            return query.Where(predicate);
        }

        protected virtual IQueryable<TView> FindView<TView>(Expression<Func<TView, bool>> predicate)
            where TView : class
        {
            return Context.Set<TView>().Where(predicate);
        }

        public virtual Task<IPaginationResult<TEntity>> PaginateAsync(IPaginationParameters<TEntity> parameters)
        {
            return PaginateAsync(parameters, true);
        }

        protected virtual async Task<IPaginationResult<TEntity>> PaginateAsync(IPaginationParameters<TEntity> parameters, bool @readonly)
        {
            IQueryable<TEntity> listaAPaginar = FilterData(parameters, @readonly);
            return await PaginationAsync(parameters, listaAPaginar);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).CountAsync();
        }

        protected IQueryable<TEntity> FilterData(IPaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            var specificParameters = (PaginationParameters<TEntity>)parameters;

            IQueryable<TEntity> dbSet = specificParameters.Includes != null ? specificParameters.Includes(DbSet) : (IQueryable<TEntity>)DbSet;
            return (@readonly ? dbSet.AsNoTracking() : dbSet).Where(parameters.WhereFilter);
        }

        protected async Task<IPaginationResult<TEntity>> PaginationAsync(IPaginationParameters<TEntity> parameters, IQueryable<TEntity> listaAPaginar)
        {
            return await PaginationAsync<TEntity>(parameters, listaAPaginar);
        }

        protected async Task<IPaginationResult<TNewEntity>> PaginationAsync<TNewEntity>(IPaginationParameters<TNewEntity> parameters,
            IQueryable<TNewEntity> listaAPaginar) where TNewEntity : class
        {
            listaAPaginar = (parameters.OrderType == OrderType.Ascending)
               ? Queryable.OrderBy(listaAPaginar, (dynamic)parameters.ColumnOrder)
               : Queryable.OrderByDescending(listaAPaginar, (dynamic)parameters.ColumnOrder);

            return new PaginationResult<TNewEntity>
            {
                Count = await listaAPaginar.CountAsync(),
                Entities = parameters.AmountRows == -1 ? listaAPaginar : listaAPaginar.Skip(parameters.Start).Take(parameters.AmountRows)
            };
        }

        #endregion Protected Methods

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion Dispose
    }
}