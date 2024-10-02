using MongoDB.Bson;
using MongoDb.DbContext;
using MongoDB.Driver;
using MongoDb.Repositories.Interfaces;

namespace MongoDb.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    public Repository(MongoDbContext context, string collectionName)
    {
        _collection = context.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        return await _collection.Find(Builders<T>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, T entity)
    {
        ObjectId objectId = ObjectId.Parse(id);
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", objectId), entity);
    }

    public async Task DeleteAsync(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
    }
}