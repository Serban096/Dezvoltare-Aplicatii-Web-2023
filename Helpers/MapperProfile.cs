using AutoMapper;
using Proiect.Models.DTOs;
using Proiect.Models;

namespace Proiect.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserDTO>()
                .ForMember(ud => ud.FullName,
                opts => opts.MapFrom(u => u.FirstName + u.LastName));

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();

            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();
        }
    }
}
