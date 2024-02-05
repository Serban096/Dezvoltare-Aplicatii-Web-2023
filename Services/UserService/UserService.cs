using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
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


        public async Task<List<UserDTO>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(userList);
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.FindByUsername(username);

            return _mapper.Map<UserDTO>(user);
        }
 

    }
}
