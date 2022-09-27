using api.models;

namespace api.services;

public interface IUserService
{
    Task<bool> CreateUser(SignupUser user);
}

public class UserService : IUserService
{
    public UserService()
    {

    }

    public async Task<bool> CreateUser(SignupUser user)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}