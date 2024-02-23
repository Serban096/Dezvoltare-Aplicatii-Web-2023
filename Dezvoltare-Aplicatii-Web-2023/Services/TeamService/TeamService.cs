using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repositories.TeamRepository;
using Proiect.Repositories.UserRepository;
using Proiect.Services.UserService;
using System.Diagnostics;
using System.Linq;

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
        public List<TeamDTO> GetTeamsByCity(string city)
        {
            var teamList = _teamRepository.GetAllQueryable()
                .Where(t => t.City == city)
                .ProjectTo<TeamDTO>(_mapper.ConfigurationProvider)
                .ToList();
            return _mapper.Map<List<TeamDTO>>(teamList);
        }

        public List<TeamDTO> GetTeamsWithPlayers()
        {
            var teamsWithPlayers =  _teamRepository.GetAllQueryable()
                    .Include(t => t.Players)
                    .ToList();
            return _mapper.Map<List<TeamDTO>>(teamsWithPlayers);
        }

        public async Task<List<TeamDTO>> GetAllTeams()
        {
            var teamList = await _teamRepository.GetAllAsync();
            return _mapper.Map<List<TeamDTO>>(teamList);
        }

        public TeamDTO GetTeamByName(string name)
        {
            var team = _teamRepository.FindByName(name);

            return _mapper.Map<TeamDTO>(team);
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

        public async Task Delete(Guid id)
        {
            var team = _teamRepository.FindById(id);
            if (team == null)
            {
                throw new Exception("Team doesnt exist");
            }
            _teamRepository.Delete(team);
            await _teamRepository.SaveAsync();
        }

        public async Task UpdateTeam(TeamDTO team)
        {
            var oldTeam = _teamRepository.FindById(team.Id);
            if (oldTeam == null)
            {
                throw new Exception("The team doesn't exist");
            }
            if (team.Name != null && team.Name != "")
                oldTeam.Name = team.Name;

            _teamRepository.Update(_mapper.Map<Team>(oldTeam));
            await _teamRepository.SaveAsync();
        }

    }
}
