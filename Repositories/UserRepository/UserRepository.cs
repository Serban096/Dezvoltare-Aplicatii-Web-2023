using Microsoft.AspNetCore.Mvc;
using Proiect.Data;
using Proiect.Models;
using Proiect.Repositories.GenericRepository;
using Proiect.Services.UserService;

namespace Proiect.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }


        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
