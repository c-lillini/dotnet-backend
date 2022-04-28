using MySql.Data.MySqlClient;

namespace _7_WebApi.Context;

public class AppDb
{

    public MySqlConnection Connection { get; }

    public AppDb(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }



}