using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Models.DTOs.UserDTO;
using Proiect.Models.Enums;
using Proiect.Repositories.UserRepository;

namespace Proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<Models.DTOs.UserDTO.UserLoginResponse> Login(Models.DTOs.UserDTO.UserLoginDTO userDTO)
        {
            var user = await _userRepository.FindByUsername(userDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Password))
            {
                return null;
            }
            return new Models.DTOs.UserDTO.UserLoginResponse(user);

        }

        public async Task<bool> Register(Models.DTOs.UserDTO.UserRegistrationDTO newUser, Role userRole)
        {
            var UserToCreate = new User
            {
                Username = newUser.Username,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = userRole
            };
            _userRepository.CreateAsync(UserToCreate);
            return await _userRepository.SaveAsync();
        }

    }
}
