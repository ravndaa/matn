using Dapper;
using Microsoft.Data.Sqlite;

namespace api.tests;

public static class SqliteInMemoryDatabase
{

    public static void CreateUserDb(string conString)
    {
        using var connection = new SqliteConnection(conString);

        connection.Execute(@"CREATE TABLE users (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name text not null,
                password text not null,
                email text not null UNIQUE
            )");

        connection.Execute("INSERT INTO users (name,password,email) VALUES (@name, @password, @email)", new { name = "stian", password = "asd", email = "asd@asd.no" });

    }


}