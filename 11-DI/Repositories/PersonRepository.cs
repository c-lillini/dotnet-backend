using _7_WebApi.Context;
using MySql.Data.MySqlClient;

namespace _7_WebApi.Repositories;

public class PersonRepository : IPersonRepository
{

    private readonly AppDb appDb;

    public PersonRepository(AppDb appDb)
    {
        this.appDb = appDb;
    }

    public IEnumerable<Person> GetPeople()
    {
        var result = new List<Person>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,name,age from person";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var person = new Person()
            {
                id = reader.GetInt16("id"),
                Name = reader.GetString("name"),
                Age = reader.GetInt16("age")
            };
            result.Add(person);
        }

        return result;
    }

    public Person GetPerson(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,name,age from person where id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var person = new Person()
            {
                id = reader.GetInt16("id"),
                Name = reader.GetString("name"),
                Age = reader.GetInt16("age")
            };
            return person;
        }

        return null;
    }

    public bool Create(Person person)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into person (id,name,age) values (@id,@name,@age)";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = person.id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "name",
            DbType = System.Data.DbType.String,
            Value = person.Name
        };
        command.Parameters.Add(parameterName);
        var parameterAge = new MySqlParameter()
        {
            ParameterName = "age",
            DbType = System.Data.DbType.Int16,
            Value = person.Age
        };
        command.Parameters.Add(parameterAge);
        return Convert.ToBoolean(command.ExecuteNonQuery());
    }

    public bool Update(int id, Person person)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update person set name=@name,age=@age where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "name",
            DbType = System.Data.DbType.String,
            Value = person.Name
        };
        command.Parameters.Add(parameterName);
        var parameterAge = new MySqlParameter()
        {
            ParameterName = "age",
            DbType = System.Data.DbType.Int16,
            Value = person.Age
        };
        command.Parameters.Add(parameterAge);
        return Convert.ToBoolean(command.ExecuteNonQuery());
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from person where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        return Convert.ToBoolean(command.ExecuteNonQuery());
    }


}