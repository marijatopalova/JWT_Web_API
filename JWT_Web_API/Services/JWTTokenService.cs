using JWT_Web_API.Data;
using JWT_Web_API.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Web_API.Services
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public JWTTokenService(IConfiguration configuration, ApplicationDbContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }

        public JWTToken Authenticate(User user)
        {
            if (!_context.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password))
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWTToken:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);

            return new JWTToken { Token = tokenhandler.WriteToken(token) };
        }
    }
}
