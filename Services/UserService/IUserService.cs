using Proiect.Models.DTOs;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();

        UserDTO GetUserByUsername(string username);
    }
}
