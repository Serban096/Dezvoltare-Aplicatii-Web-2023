using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Proiect.Data;
using Proiect.Models;
using Proiect.Repositories.GenericRepository;
using Proiect.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proiect.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        private readonly IConfiguration _configuration;
        public UserRepository(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<User>? GetUserById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
        public async Task<User>? GetByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task CreateAsync(User user)
        {
            var newUser = await _userManager.CreateAsync(user);
            if (newUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return;
            }
        }

        public async Task Update(User user)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.UpdateAsync(user);
        }

        public async Task Delete(Guid id)
        {
            var userFound = await GetUserById(id);

            await _userManager.DeleteAsync(userFound);
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(24), 
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
