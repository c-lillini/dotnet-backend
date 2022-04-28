using Microsoft.AspNetCore.Mvc;
using _7_WebApi.Service;

namespace _7_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CrudController : ControllerBase
{
    private readonly IPersonService personService;

    public CrudController(IPersonService personService)
    {
        this.personService = personService;
    }

    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return personService.GetPeople();
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPerson(int id)
    {
        return personService.GetPerson(id);
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        var result = personService.Create(person);

        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Person person)
    {
        var result = personService.Update(id, person);

        if (result)
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
        var result = personService.Delete(id);

        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }



}