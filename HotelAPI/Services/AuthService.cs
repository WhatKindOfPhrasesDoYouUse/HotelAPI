using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<UserAccount> _passwordHasher;

        public AuthService(IConfiguration configuration, ApplicationDbContext context, PasswordHasher<UserAccount> passwordHasher)
        {
            this._configuration = configuration;
            this._context = context;
            this._passwordHasher = passwordHasher;
        }

        private string GenerateJwtToken(UserAccount user)
        {
            var roles = _context.UsersRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(r => r.Role.Name)
                .ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(120);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(UserAccount user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(UserAccount user, string password)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return verificationResult == PasswordVerificationResult.Success;
        }

        public async Task<string> Login(AuthUserDTO loginDto)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !VerifyPassword(user, loginDto.Password))
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        public async Task<bool> Registration(UserAccount user)
        {
            if (user == null)
            {
                return false;
            }

            var existingUser = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return false;
            }

            user.Password = HashPassword(user, user.Password);

            _context.UserAccounts.Add(user);
            await _context.SaveChangesAsync();

            UserRole userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = 2
            };

            _context.UsersRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
