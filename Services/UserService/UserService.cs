using AutoMapper;
using Proiect.Helpers.Jwt;
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
        private readonly IJwt _jwtUtils;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwt jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<UserLoginResponse> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userRepository.FindByUsername(userLoginDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.Password))
            {
                return null;
            }
            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserLoginResponse(user, token);

        }

        public async Task<bool> Register(UserRegistrationDTO newUser, Role userRole)
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

        public async Task Delete(Guid id)
        {
            var user = _userRepository.FindById(id);
            if (user == null)
            {
                throw new Exception("User doesnt exist");
            }
            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUser(UserLoginResponse user)
        {
            var oldUser = _userRepository.FindById(user.Id);
            if (oldUser == null)
            {
                throw new Exception("The user doesn't exist");
            }
            oldUser.Username = user.UserName;

            _userRepository.Update(_mapper.Map<User>(oldUser));
            await _userRepository.SaveAsync();
        }

    }
}
