using hr_management_backend.Data;
using hr_management_backend.DTOs.Auth;
using hr_management_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hr_management_backend.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly AppDataContext _context;

        public AuthService(IConfiguration config, AppDataContext context)
        {
            _config = config;
            _context = context;
        }

        public string? Login(UserLoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email);
            if (user == null) return null;
            if (user.Password != loginDto.Password) return null;

            return GenerateJwtToken(user);
        }

        public string? Register(UserRegisterDTO registerDTO)
        {
            // check if email already exist
            var existingUser = _context.Users.SingleOrDefault(u => u.Email == registerDTO.Email);
            if (existingUser != null)
            {
                return null; // or throw an exception / return error message
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            var newUser = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Password = passwordHash,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return GenerateJwtToken(newUser);
        }

            
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
