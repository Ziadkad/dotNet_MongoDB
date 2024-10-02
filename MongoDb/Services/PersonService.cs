using MongoDb.Entities;
using MongoDb.Repositories.Interfaces;
using MongoDb.Services.Interfaces;

namespace MongoDb.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<IEnumerable<Person?>> GetAllAsync() => await _personRepository.GetAllAsync();
    public async Task<Person?> GetByIdAsync(string id) => await _personRepository.GetByIdAsync(id);
    public async Task CreateAsync(Person person) => await _personRepository.CreateAsync(person);
    public async Task UpdateAsync(string id, Person person) => await _personRepository.UpdateAsync(id, person);
    public async Task DeleteAsync(string id) => await _personRepository.DeleteAsync(id);
    public async Task DeleteAllAsync() => await _personRepository.DeleteAllAsync();
}