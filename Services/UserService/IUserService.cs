using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Models.DTOs.UserDTO;
using Proiect.Models.Enums;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<Models.DTOs.UserDTO.UserLoginResponse> Login(Models.DTOs.UserDTO.UserLoginDTO userDTO);
        Task<User> GetById(Guid id);
        Task<bool> Register(Models.DTOs.UserDTO.UserRegistrationDTO newUser, Role userRole);
        Task<List<User>> GetAllUsers();
    }
}
