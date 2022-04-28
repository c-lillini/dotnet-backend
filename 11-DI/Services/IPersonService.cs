namespace _7_WebApi.Service;

public interface IPersonService
{

    public IEnumerable<Person> GetPeople();
    public Person GetPerson(int id);

    public bool Create(Person person);

    public bool Update(int id, Person person);

    public bool Delete(int id);

}