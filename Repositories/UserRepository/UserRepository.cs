using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public async Task<User> FindByUsername(string username)
        {
            return await _table.FirstOrDefaultAsync(u => u.Username.Equals(username));
        }
    }
}
