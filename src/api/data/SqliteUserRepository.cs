using api.models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace api.data;

public interface ISqliteUserRepository : IRepository<User>
{

}

public class SqliteUserRepository : ISqliteUserRepository
{
    private readonly string _conString = string.Empty;
    public SqliteUserRepository(string conString)
    {
        _conString = conString;
    }

    public async Task Insert(User item)
    {
        using var connection = new SqliteConnection(_conString);
        await connection.ExecuteAsync("INSERT INTO users (name, password,email) VALUES (@name, @password, @email)", new { name = item.Name, email = item.Email, password = item.Password });
    }

    public async Task<User?> Get(int id)
    {
        using var connection = new SqliteConnection(_conString);
        var res = await connection.QueryAsync<User>("SELECT * FROM users WHERE id=@id;", new { id });
        return res.FirstOrDefault();
    }
}