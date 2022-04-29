using _7_WebApi.Repositories;
using _7_WebApi.Models;

namespace _7_WebApi.Service;

public class PersonService
{

    private PersonRepository personRepository = new PersonRepository();

    public IEnumerable<Person> GetPeople()
    {
        return personRepository.GetPeople();
    }

    public Person GetPerson(int id)
    {
        return personRepository.GetPerson(id);
    }

    public bool Create(Person person)
    {
        if (personRepository.GetPerson(person.Id) == null)
        {
            if ((person.Name.Length > 0) && (person.Age < 18))
            {
                return false;
            }
            else
            {
                return personRepository.Create(person);
            }
        }
        else
        {
            return false;
        }

    }

    public bool Update(Person person)
    {
        return personRepository.Update(person);
    }

    public bool Delete(int id)
    {
        return personRepository.Delete(id);
    }

}