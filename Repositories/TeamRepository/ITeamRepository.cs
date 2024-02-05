using Proiect.Models;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.TeamRepository
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Team FindByName(string name);
    }
}
