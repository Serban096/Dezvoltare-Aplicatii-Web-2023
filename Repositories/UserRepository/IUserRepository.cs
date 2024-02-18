using Proiect.Models;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByUsername(string username);
    }
}
