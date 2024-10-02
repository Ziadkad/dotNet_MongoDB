using MongoDb.Entities;

namespace MongoDb.Repositories.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task DeleteAllAsync();
}