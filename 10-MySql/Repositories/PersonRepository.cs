using _7_WebApi.Context;
using MySql.Data.MySqlClient;
using _7_WebApi.Models;

namespace _7_WebApi.Repositories;

public class PersonRepository
{

    private AppDb appDb = new AppDb();

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
                Id = reader.GetInt16("id"),
                Name = reader.GetString("name"),
                Age = reader.GetInt16("age")
            };
            result.Add(person);
        }
        appDb.Connection.Close();

        return result;
    }

    public Person GetPerson(int? id)
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
                Id = reader.GetInt16("id"),
                Name = reader.GetString("name"),
                Age = reader.GetInt16("age")
            };
            appDb.Connection.Close();
            return person;
        }

        appDb.Connection.Close();
        return null;
    }

    public bool Create(Person person)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into person (name,age) values (@name,@age)";
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
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Person person)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update person set name=@name,age=@age where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = person.Id
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
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
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
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

}