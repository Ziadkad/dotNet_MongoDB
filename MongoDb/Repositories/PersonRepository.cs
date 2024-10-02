using MongoDb.DbContext;
using MongoDB.Driver;
using MongoDb.Entities;
using MongoDb.Repositories.Interfaces;

namespace MongoDb.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    private readonly MongoDbContext _context;
    private readonly IMongoCollection<Person> _collection;

    public PersonRepository(MongoDbContext context) : base(context, "PersonCollection")
    {
        _context = context;
        _collection = _context.GetCollection<Person>("PersonCollection");
    }

    public async Task DeleteAllAsync()
    {
        await _collection.DeleteManyAsync(Builders<Person>.Filter.Empty);
    }
}