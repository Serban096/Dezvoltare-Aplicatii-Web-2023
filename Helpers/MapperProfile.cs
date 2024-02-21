using AutoMapper;
using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Models.DTOs.UserDTO;

namespace Proiect.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<User, UserLoginDTO>();
            CreateMap<UserLoginDTO, User>();

            CreateMap<User, UserRegistrationDTO>();
            CreateMap<UserRegistrationDTO, User>();

            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();

            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();
        }
    }
}
