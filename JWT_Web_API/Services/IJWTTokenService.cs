using JWT_Web_API.Entities;

namespace JWT_Web_API.Services
{
    public interface IJWTTokenService
    {
        JWTToken Authenticate(User user);
    }
}
