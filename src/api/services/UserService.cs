using api.models;

namespace api.services;

public interface IUserService
{
    Task CreateUser(SignupUser user);
}

public class UserService : IUserService
{
    public UserService()
    {

    }

    public async Task CreateUser(SignupUser user)
    {
        throw new NotImplementedException();
    }
}