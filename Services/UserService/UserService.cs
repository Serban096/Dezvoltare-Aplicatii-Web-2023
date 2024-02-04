using AutoMapper;
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


        public async Task<List<UserDto>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public UserDto GetUserByUsername(string username)
        {
            var user = _userRepository.FindByUsername(username);

            return _mapper.Map<UserDto>(user);
        }
    }
}
