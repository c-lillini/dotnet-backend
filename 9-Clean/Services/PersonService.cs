using _7_WebApi.Repositories;

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
        return personRepository.Create(person);
    }

    public bool Update(int id, Person person)
    {
        return personRepository.Update(id, person);
    }

    public bool Delete(int id)
    {
        return personRepository.Delete(id);
    }


}