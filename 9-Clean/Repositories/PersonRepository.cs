namespace _7_WebApi.Repositories;

public class PersonRepository
{

    private static Dictionary<int, Person> dict = new Dictionary<int, Person>();

    public IEnumerable<Person> GetPeople()
    {
        return dict.Values.ToArray();
    }

    public Person GetPerson(int id)
    {
        if (dict.ContainsKey(id))
        {
            return dict[id];
        }
        else
        {
            return null;
        }
    }

    public bool Create(Person person)
    {
        if (dict.ContainsKey(person.id))
        {
            return false;
        }
        else
        {
            dict.Add(person.id, person);
            return true;
        }
    }

    public bool Update(int id, Person person)
    {
        if (!dict.ContainsKey(id))
        {
            return false;
        }
        else
        {
            dict[id] = person;
            return true;
        }
    }

    public bool Delete(int id)
    {
        if (!dict.ContainsKey(id))
        {
            return false;
        }
        else
        {
            dict.Remove(id);
            return true;
        }
    }


}