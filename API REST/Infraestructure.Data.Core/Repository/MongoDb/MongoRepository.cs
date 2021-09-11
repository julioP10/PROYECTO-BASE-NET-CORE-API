using Domain.Core.Pagination;
using Domain.Core.Settings;
using Infraestructure.Data.Core.Pagination;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Data.Core.Repository.MongoDb
{
    public class MongoRepository<TCollection, TId>
        where TCollection: class
    {
        protected readonly IMongoClient _client;
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<TCollection> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _collection = _database.GetCollection<TCollection>(typeof(TCollection).Name);
        }
        public void Create(TCollection entity)
        {
            _collection.InsertOne(entity);
        }
        public void Delete(Expression<Func<TCollection, bool>> filter)
        {
            _collection.DeleteOne(filter);
        }

        public async Task<TCollection> GetAsync<TField>(Expression<Func<TCollection, TField>> field, TField value)
        {
            var filter = Builders<TCollection>.Filter.Eq(field, value);
            
            var items = await _collection.FindAsync(filter,
                                    new FindOptions<TCollection, TCollection>
                                    {
                                        Skip = 0,
                                        Limit = 1
                                    });
            return await items.FirstAsync();
        }

        public virtual async Task<IPaginationResult<TCollection>> PaginateAsync(
            string field,
            string value,
            Expression<Func<TCollection, object>> order,
            int start,
            int amountRows)
        {
            var filter = Builders<TCollection>.Filter.Eq(field, value);
            var totalItems = await _collection.CountDocumentsAsync(filter);
            var sort = Builders<TCollection>.Sort.Descending(order);
            var items = await _collection.FindAsync(filter,
                                    new FindOptions<TCollection, TCollection>
                                    {
                                        Skip = start,
                                        Limit = amountRows,
                                        Sort = sort
                                    });

            return new PaginationResult<TCollection>
            {
                Count = (int)totalItems,
                Entities = await items.ToListAsync()
            };
        }

        public virtual async Task<IPaginationResult<TCollection>> PaginateAsync<TField>(
            Expression<Func<TCollection, TField>> field,
            TField value,
            Expression<Func<TCollection, object>> order,            
            int start, 
            int amountRows)
        {
            var filter = Builders<TCollection>.Filter.Eq(field, value);
            var totalItems = await _collection.CountDocumentsAsync(filter);
            var sort = Builders<TCollection>.Sort.Descending(order);
            var items = await _collection.FindAsync(filter,
                                    new FindOptions<TCollection, TCollection>
                                    {
                                        Skip = start,
                                        Limit = amountRows,
                                        Sort = sort
                                    });

            return new PaginationResult<TCollection>
            {
                Count = (int)totalItems,
                Entities = await items.ToListAsync()
            };
        }
    }
}
