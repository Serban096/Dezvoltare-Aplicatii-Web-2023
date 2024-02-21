using Proiect.Data;
using Proiect.Models;

namespace Proiect.Helpers.Seeders
{
    public class UsersSeeder
    {
        public readonly Context _context;

        public UsersSeeder(Context context)
        {
            _context = context;
        }

        public void SeedInitialUsers()
        {
            /*if (!_context.Users.Any())
            {
                var user1 = new User
                {
                    FirstName = "Fist name User 1",
                    LastName = "Last name User 1",
                    Email = "user1@mail.com",
                    Username = "user1",
                    Password = "pass1"
                };

                var user2 = new User
                {
                    FirstName = "Fist name User 2",
                    LastName = "Last name User 2",
                    Email = "user2@mail.com",
                    Username = "user2",
                    Password = "pass2"
                };

                _context.Users.Add(user1);
                _context.Users.Add(user2);

                _context.SaveChanges();
            }*/
        }
    }
}
