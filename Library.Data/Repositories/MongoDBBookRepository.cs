using Library.Entities;
using Library.Entities.MongoDB;
using Library.Entities.MongoDB.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class MongoDBBookRepository : IMongoDBRepository<Book>
    {
        private readonly IMongoCollection<Book> _collection;
        public MongoDBBookRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Book>(databaseSettings.BookCollectionName);
        }

        public async Task<bool> Create(Book entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(Book entity)
        {
            try
            {
                entity.DeletedDate = DateTime.Now;
                entity.IsDeleted = true;
                await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePermanent(string id)
        {
            try
            {
                await _collection.DeleteOneAsync(x => x.Id == id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Book> Get(string id)
        {
            try
            {
                return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                return default;
            }
        }

        public async Task<Book> Get(Expression<Func<Book, bool>> predicate)
        {
            try
            {
                return await _collection.Find(predicate).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                return default;
            }
        }

        public async Task<List<Book>> GetAll(Expression<Func<Book, bool>> predicate)
        {
            try
            {
                return await _collection.Find(predicate).ToListAsync();
            }
            catch (Exception ex)
            {

                return default;
            }
        }

        public async Task<List<Book>> GetAll()
        {
            try
            {
                return await _collection.Find(x => true).ToListAsync();
            }
            catch (Exception)
            {

                return default;
            }
        }

        public async Task<bool> Update(Book entity)
        {
            try
            {
              
                await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
