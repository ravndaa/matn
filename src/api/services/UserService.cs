using api.data;
using api.models;

namespace api.services;

public interface IUserService
{
    Task<bool> CreateUser(SignupUser user);
}

public class UserService : IUserService
{
    private readonly IRepository<User> _users;
    public UserService(IRepository<User> users)
    {
        _users = users;
    }

    public async Task<bool> CreateUser(SignupUser user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword)) return false;
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.ConfirmPassword)) return false;

            var password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _users.Insert(new User { Email = user.Email, Password = password });
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }

    }
}