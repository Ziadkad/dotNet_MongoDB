using Microsoft.AspNetCore.Mvc;
using MongoDb.Entities;
using MongoDb.Services.Interfaces;

namespace MongoDb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAllAsync()
    {
        IEnumerable<Person?> people = await _personService.GetAllAsync();
        return Ok(people);
    }
    
    [HttpGet("{id}",Name ="GetByIdAsync")]
    public async Task<ActionResult<Person>> GetByIdAsync(string id)
    {
        Person? person = await _personService.GetByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] Person person)
    {
        await _personService.CreateAsync(person);
        return Ok(person);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }
        Person? existingPerson = await _personService.GetByIdAsync(id);
        if (existingPerson == null)
        {
            return NotFound();
        }
        await _personService.UpdateAsync(id, person);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        Person? existingPerson = await _personService.GetByIdAsync(id);
        if (existingPerson == null)
        {
            return NotFound();
        }
        await _personService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAllAsync()
    {
        await _personService.DeleteAllAsync();
        return NoContent();
    }
}