using api.data;
using api.models;
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

    [Fact]
    public async void Test_Insert_User()
    {
        var db = new SqliteUserRepository(conString);

        await db.Insert(new User { Name = "test", Email = "test@test.no", Password = "passordet" });

    }

    [Fact]
    public async void Test_Insert_User_ShouldFail()
    {
        var db = new SqliteUserRepository(conString);

        await Assert.ThrowsAsync<SqliteException>(async () => await db.Insert(new User { Name = "stian", Email = "asd@asd.no", Password = "passordet" }));
    }

    public void Dispose()
    {
        connection.Close();
        GC.SuppressFinalize(this);
    }

}