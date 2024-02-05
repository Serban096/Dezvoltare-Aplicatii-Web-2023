using AutoMapper;
using Microsoft.Extensions.Hosting;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repositories.TeamRepository;
using Proiect.Repositories.UserRepository;
using Proiect.Services.UserService;

namespace Proiect.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public ITeamRepository _teamRepository;
        public IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }


        public async Task<List<TeamDTO>> GetAllTeams()
        {
            var teamList = await _teamRepository.GetAllAsync();
            return _mapper.Map<List<TeamDTO>>(teamList);
        }

        public TeamDTO GetTeamByName(string name)
        {
            var user = _teamRepository.FindByName(name);

            return _mapper.Map<TeamDTO>(name);
        }

        public async Task CreateTeam(TeamDTO team)
        {

            var newTeam = new Team()
            {
                Id = Guid.NewGuid(),
                Name = team.Name,
                City = team.City,
            };

            await _teamRepository.CreateAsync(_mapper.Map<Team>(newTeam));
            await _teamRepository.SaveAsync();
        }
    }
}
