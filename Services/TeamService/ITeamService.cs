using Proiect.Models.DTOs;

namespace Proiect.Services.TeamService
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetAllTeams();

        TeamDTO GetTeamByName(string name);

        Task CreateTeam(TeamDTO team);
    }
}
