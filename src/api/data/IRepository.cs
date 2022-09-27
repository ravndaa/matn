using Microsoft.AspNetCore.Components.Web;

namespace api.data;


public interface IRepository<T> where T : class
{
    Task Insert(T item);
}