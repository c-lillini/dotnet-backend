using Microsoft.AspNetCore.Mvc;

namespace _7_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CrudController : ControllerBase
{
    private static Dictionary<int, Person> dict = new Dictionary<int, Person>();

    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return dict.Values.ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPerson(int id)
    {
        if (dict.ContainsKey(id))
        {
            return dict[id];
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        if (dict.ContainsKey(person.id))
        {
            return BadRequest();
        }
        else
        {
            dict.Add(person.id, person);
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Person person)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict[id] = person;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict.Remove(id);
            return Ok();
        }
    }



}