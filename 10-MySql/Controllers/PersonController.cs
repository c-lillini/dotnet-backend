using Microsoft.AspNetCore.Mvc;
using _7_WebApi.Service;

namespace _7_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private PersonService personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return personService.GetPeople();
    }

    [HttpGet("{id}")]
    public Person GetPerson(int id)
    {
        return personService.GetPerson(id);
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        var created = personService.Create(person);
        if (created)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Update(Person person)
    {
        var updated = personService.Update(person);
        if (updated)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = personService.Delete(id);
        if (deleted)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }
}