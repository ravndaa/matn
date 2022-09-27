using api.data;
using Microsoft.Data.Sqlite;

namespace api.tests;

public class SqliteUserRepositoryTests : IDisposable
{
    private readonly string conString = $"Data Source=USERDB;Mode=Memory;Cache=Shared";
    private readonly SqliteConnection connection;
    public SqliteUserRepositoryTests()
    {
        connection = new SqliteConnection(conString);
        connection.Open(); // for the connection sharing to work.
        SqliteInMemoryDatabase.CreateUserDb(conString);

    }

    [Fact]
    public async void Test_Get_User()
    {
        var db = new SqliteUserRepository(conString);

        var res = await db.Get(1);
        Assert.NotNull(res);
        Assert.Equal("asd@asd.no", res.Email);
    }

    public void Dispose()
    {
        connection.Close();
        GC.SuppressFinalize(this);
    }

}