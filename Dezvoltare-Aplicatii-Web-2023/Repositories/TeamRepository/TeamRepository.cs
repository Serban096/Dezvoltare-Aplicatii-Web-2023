using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Repositories.GenericRepository;
using Proiect.Repositories.UserRepository;

namespace Proiect.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(Context context) : base(context)
        {
        }


        public Team FindByName(string name)
        {
            return _table.FirstOrDefault(t => t.Name.Equals(name));
        }


    }
}
