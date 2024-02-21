using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userRepository.GetByUsername(username);
        }
        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<string> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

                if (result.Succeeded)
                {
                    return _userRepository.GenerateJwtToken(user);
                }
            }
            throw new Exception("Ai gresit numele sau parola!");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> Register(UserRegistrationDTO userRegistrationDTO)
        {
            var user = new User
            {
                FirstName = userRegistrationDTO.FirstName,
                LastName = userRegistrationDTO.LastName,
                Username = userRegistrationDTO.Username,
                Email = userRegistrationDTO.Email,
                Password = userRegistrationDTO.Password
            };

            var result = await _userManager.CreateAsync(user, userRegistrationDTO.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return _userRepository.GenerateJwtToken(user);
            }

            throw new Exception("Eroare!");
        }
        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task UpdateUser(UserUpdateDTO user)
        {
            var oldUser = await  _userRepository.GetUserById(user.Id);
            if (oldUser == null)
            {
                throw new Exception("The user doesn't exist");
            }
            oldUser.Username = user.Username;
            oldUser.Password = user.Password;
            oldUser.Email = user.Email;
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;

            await _userRepository.Update(_mapper.Map<User>(oldUser));
        }

    }
}
