using Proiect.Models.DTOs;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();

        UserDto GetUserByUsername(string username);
    }
}
