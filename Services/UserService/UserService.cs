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

        public async Task<User> GetByUsername(string username)
        {
            return await _userRepository.GetByUsername(username);
        }
        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetUserById(id);
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
