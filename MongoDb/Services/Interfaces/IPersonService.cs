using MongoDb.Entities;

namespace MongoDb.Services.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<Person?>> GetAllAsync();
    Task<Person?> GetByIdAsync(string id);
    Task CreateAsync(Person person);
    Task UpdateAsync(string id, Person person);
    Task DeleteAsync(string id);
    Task DeleteAllAsync();
}