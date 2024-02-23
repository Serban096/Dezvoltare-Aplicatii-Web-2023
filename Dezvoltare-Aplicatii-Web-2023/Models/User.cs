using Microsoft.AspNetCore.Identity;
using Proiect.Models.Base;
using Proiect.Models.Enums;

namespace Proiect.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }

        public Role Role { get; set; }
    }
}
