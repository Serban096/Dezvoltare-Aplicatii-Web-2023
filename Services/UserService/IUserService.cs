using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Models.DTOs.UserDTO;
using Proiect.Models.Enums;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginDTO userDTO);
        Task<User> GetById(Guid id);
        Task<bool> Register(UserRegistrationDTO newUser, Role userRole);
        Task<List<User>> GetAllUsers();
        Task Delete(Guid id);

        Task UpdateUser(UserLoginResponse user);

    }
}
