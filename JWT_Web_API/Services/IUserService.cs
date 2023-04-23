using JWT_Web_API.Entities;

namespace JWT_Web_API.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
