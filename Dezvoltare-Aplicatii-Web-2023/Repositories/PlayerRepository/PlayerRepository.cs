using Proiect.Data;
using Proiect.Models;
using Proiect.Repositories.GenericRepository;
using Proiect.Repositories.UserRepository;

namespace Proiect.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(Context context) : base(context)
        {
        }


    }
}
